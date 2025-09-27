using ShrinkIT.Data;
using ShrinkIT.Domain;
using ShrinkIT.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShrinkIT;
public partial class Invoice_Management : Form
{
    private readonly IClientRepository _clientRepository;
    private readonly IInvoiceRepository _invoiceRepository;
    private readonly IInvoiceItemRepository _invoiceItemRepository;
    private readonly IInvoiceLineItemRepository _invoiceLineItemRepository;
    private Invoice _selectedInvoice;
    private List<InvoiceLineItem> _currentInvoiceItems;

    public Invoice_Management()
    {
        InitializeComponent();
        _clientRepository = new ClientRepository();
        _invoiceRepository = new InvoiceRepository();
        _invoiceItemRepository = new InvoiceItemRepository();
        _invoiceLineItemRepository = new InvoiceLineItemRepository();
        _currentInvoiceItems = new List<InvoiceLineItem>();

        LoadClients();
        LoadInvoiceItems();
        LoadInvoicesForClient((int)cmbClients.SelectedValue);
    }

    private void LoadClients()
    {
        var clients = _clientRepository.GetAllClients();
        cmbClients.DataSource = clients;
        cmbClients.DisplayMember = "FullName"; // Add a FullName property to the Client class
        cmbClients.ValueMember = "ClientID";
    }

    private void LoadInvoiceItems()
    {
        var items = _invoiceItemRepository.GetAllInvoiceItems();
        cmbItems.DataSource = items;
        cmbItems.DisplayMember = "ItemName";
        cmbItems.ValueMember = "ItemID";
    }

    private void ClearForm()
    {
        cmbClients.SelectedIndex = -1;
        dtpInvoiceDate.Value = DateTime.Now;
        txtTotalAmount.Clear();
        _currentInvoiceItems.Clear();
        dgvInvoiceItems.DataSource = null;
        _selectedInvoice = null;
    }

    private void btnAddItem_Click(object sender, EventArgs e)
    {
        if (cmbItems.SelectedItem == null || string.IsNullOrEmpty(txtQuantity.Text))
        {
            MessageBox.Show("Please select an item and enter a quantity.");
            return;
        }

        // Get the selected item
        var selectedItem = (InvoiceItem)cmbItems.SelectedItem;

        // Parse the quantity
        if (!int.TryParse(txtQuantity.Text, out int quantity))
        {
            MessageBox.Show("Please enter a valid quantity.");
            return;
        }

        // Calculate the line total
        decimal lineTotal = selectedItem.ItemPrice * quantity;

        // Create a new InvoiceLineItem
        var lineItem = new InvoiceLineItem
        {
            ItemName = selectedItem.ItemName,
            ItemID = selectedItem.ItemID,
            Quantity = quantity,
            LineTotal = lineTotal,
        };

        // Add the line item to the current invoice items
        _currentInvoiceItems.Add(lineItem);

        // Refresh the DataGridView
        RefreshInvoiceItemsGrid();

        // Update the total amount
        UpdateTotalAmount();
    }

    private void RefreshInvoiceItemsGrid()
    {
        // Bind the current invoice items to the DataGridView
        dgvInvoiceItems.DataSource = null;
        dgvInvoiceItems.DataSource = _currentInvoiceItems;

        // Optionally, format the columns
        dgvInvoiceItems.Columns["ItemName"].HeaderText = "Item Name";
        dgvInvoiceItems.Columns["ItemName"].DisplayIndex = 0;
        dgvInvoiceItems.Columns["ItemName"].Width = 160;
        dgvInvoiceItems.Columns["Quantity"].HeaderText = "Quantity";
        dgvInvoiceItems.Columns["Quantity"].DisplayIndex = 1;
        dgvInvoiceItems.Columns["LineTotal"].HeaderText = "Line Total";
        dgvInvoiceItems.Columns["LineTotal"].DisplayIndex = 2;
        dgvInvoiceItems.Columns["LineTotal"].DefaultCellStyle.Format = "C"; // Format as currency

        dgvInvoiceItems.Columns["LineItemID"].Visible = false; // Hide LineItemID
        dgvInvoiceItems.Columns["InvoiceID"].Visible = false; // Hide InvoiceID
        dgvInvoiceItems.Columns["ItemID"].Visible = false;

       
    }

    private void UpdateTotalAmount()
    {
        // Calculate the total amount by summing up all line totals
        decimal totalAmount = _currentInvoiceItems.Sum(item => item.LineTotal);

        // Display the total amount in the txtTotalAmount textbox
        txtTotalAmount.Text = totalAmount.ToString("C"); // Format as currency
    }

    private void btnRemoveItem_Click(object sender, EventArgs e)
    {
        if (dgvInvoiceItems.SelectedRows.Count > 0)
        {
            var selectedLineItem = (InvoiceLineItem)dgvInvoiceItems.SelectedRows[0].DataBoundItem;
            _currentInvoiceItems.Remove(selectedLineItem);
            RefreshInvoiceItemsGrid();
            UpdateTotalAmount();
        }
    }

    private void btnCreateInvoice_Click(object sender, EventArgs e)
    {
        if (cmbClients.SelectedItem == null || _currentInvoiceItems.Count == 0)
        {
            MessageBox.Show("Please select a client and add at least one item.");
            return;
        }

        var invoice = new Invoice
        {
            ClientID = (int)cmbClients.SelectedValue,
            InvoiceDate = dtpInvoiceDate.Value,
            TotalAmount = decimal.Parse(txtTotalAmount.Text.Replace("£", ""))
        };

        _invoiceRepository.AddInvoice(invoice);

        // Add line items
        foreach (var lineItem in _currentInvoiceItems)
        {
            lineItem.InvoiceID = invoice.InvoiceID;
            _invoiceLineItemRepository.AddInvoiceLineItem(lineItem);
        }

        MessageBox.Show("Invoice created successfully!");
        ClearForm();
    }

    private void btnUpdateInvoice_Click(object sender, EventArgs e)
    {
        if (_selectedInvoice == null)
        {
            MessageBox.Show("Please select an invoice to update.");
            return;
        }

        _selectedInvoice.ClientID = (int)cmbClients.SelectedValue;
        _selectedInvoice.InvoiceDate = dtpInvoiceDate.Value;
        _selectedInvoice.TotalAmount = decimal.Parse(txtTotalAmount.Text.Replace("$", ""));

        _invoiceRepository.UpdateInvoice(_selectedInvoice);

        // Update line items
        _invoiceLineItemRepository.DeleteInvoiceLineItemsByInvoiceId(_selectedInvoice.InvoiceID);
        foreach (var lineItem in _currentInvoiceItems)
        {
            lineItem.InvoiceID = _selectedInvoice.InvoiceID;
            _invoiceLineItemRepository.AddInvoiceLineItem(lineItem);
        }

        MessageBox.Show("Invoice updated successfully!");
        ClearForm();
    }

    private void btnDeleteInvoice_Click(object sender, EventArgs e)
    {
        if (_selectedInvoice == null)
        {
            MessageBox.Show("Please select an invoice to delete.");
            return;
        }

        _invoiceRepository.DeleteInvoice(_selectedInvoice.InvoiceID);
        MessageBox.Show("Invoice deleted successfully!");
        ClearForm();
    }

    private void btnSaveInvoice_Click(object sender, EventArgs e)
    {
        if (_selectedInvoice == null)
        {
            MessageBox.Show("Please select an invoice to save.");
            return;
        }

        var client = _clientRepository.GetClient(_selectedInvoice.ClientID);
        var invoiceItems = _invoiceLineItemRepository.GetAllInvoiceLineItems()
            .Where(item => item.InvoiceID == _selectedInvoice.InvoiceID)
            .ToList();

        string invoiceContent = $"Invoice for {client.FirstName} {client.LastName}\n\n";
        invoiceContent += $"Date: {_selectedInvoice.InvoiceDate:yyyy-MM-dd}\n";
        invoiceContent += "Items:\n";
        foreach (var item in invoiceItems)
        {
            var invoiceItem = _invoiceItemRepository.GetInvoiceItem(item.ItemID);
            invoiceContent += $"{invoiceItem.ItemName} - {item.Quantity} x {invoiceItem.ItemPrice:C} = {item.LineTotal:C}\n";
        }
        invoiceContent += $"Total Amount: {_selectedInvoice.TotalAmount:C}";

        string filePath = Path.Combine("Invoices", $"Invoice_{_selectedInvoice.InvoiceID}.txt");
        File.WriteAllText(filePath, invoiceContent);

        MessageBox.Show($"Invoice saved to {filePath}");
    }

    private void btnPreviewInvoice_Click(object sender, EventArgs e)
    {
        if (_selectedInvoice == null)
        {
            MessageBox.Show("Please select an invoice to preview.");
            return;
        }

        var previewForm = new Invoice_Preview(_selectedInvoice.InvoiceID);
        previewForm.ShowDialog();
    }

    private void dgvInvoices_SelectionChanged(object sender, EventArgs e)
    {
        if (dgvInvoices.SelectedRows.Count > 0)
        {
            var selectedRow = dgvInvoices.SelectedRows[0];
            _selectedInvoice = (Invoice)selectedRow.DataBoundItem;

            // Load invoice details
            cmbClients.SelectedValue = _selectedInvoice.ClientID;
            dtpInvoiceDate.Value = _selectedInvoice.InvoiceDate;
            txtTotalAmount.Text = _selectedInvoice.TotalAmount.ToString("C");

            // Load invoice items
            _currentInvoiceItems = _invoiceLineItemRepository.GetInvoiceLineItemsByInvoiceId(_selectedInvoice.InvoiceID)
                .Where(item => item.InvoiceID == _selectedInvoice.InvoiceID)
                .ToList();
            RefreshInvoiceItemsGrid();
        }
    }

    private void dgvInvoiceItems_SelectionChanged(object sender, EventArgs e)
    {
        if (dgvInvoiceItems.SelectedRows.Count > 0)
        {
            // Get the selected row
            var selectedRow = dgvInvoiceItems.SelectedRows[0];

            // Retrieve the selected item details
            var itemName = selectedRow.Cells["ItemName"].Value.ToString();
            var quantity = selectedRow.Cells["Quantity"].Value.ToString();
            var price = selectedRow.Cells["Price"].Value.ToString();
            var lineTotal = selectedRow.Cells["LineTotal"].Value.ToString();

            // Display the selected item details (optional)
            MessageBox.Show($"Selected Item:\n\n" +
                            $"Name: {itemName}\n" +
                            $"Quantity: {quantity}\n" +
                            $"Price: {price}\n" +
                            $"Line Total: {lineTotal}", "Item Details");
        }
    }

    private void CalculateLineTotal(object sender, EventArgs e)
    {
        // Try to parse the quantity and price
        if (decimal.TryParse(txtQuantity.Text, out decimal quantity) &&
            decimal.TryParse(txtPrice.Text, out decimal price))
        {
            // Calculate the line total
            decimal lineTotal = quantity * price;

            // Display the line total in the txtLineTotal textbox
            txtLineTotal.Text = lineTotal.ToString("C"); // Format as currency
        }
        else
        {
            // If parsing fails, clear the line total
            txtLineTotal.Clear();
        }
    }

    private void txtQuantity_TextChanged(object sender, EventArgs e)
    {
        if (!int.TryParse(txtQuantity.Text, out int quantity))
        {
            MessageBox.Show("Please enter a valid quantity.");
            txtQuantity.Clear();
            return;
        }

        CalculateLineTotal(sender, e);
    }

    private void txtPrice_TextChanged(object sender, EventArgs e)
    {
        if (!decimal.TryParse(txtPrice.Text, out decimal price))
        {
            MessageBox.Show("Please enter a valid price.");
            txtPrice.Clear();
            return;
        }

        CalculateLineTotal(sender, e);
    }

    private void cmbItems_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (cmbItems.SelectedItem != null)
        {
            var selectedItem = (InvoiceItem)cmbItems.SelectedItem;
            txtPrice.Text = selectedItem.ItemPrice.ToString(); // Display the item price
            txtQuantity.Text = "1";
        }
    }

    private void cmbClients_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (cmbClients.SelectedValue != null)
        {
            if (cmbClients.SelectedValue is int clientID)
            {
                LoadInvoicesForClient(clientID);
            }
                
        }
    }

    private void LoadInvoicesForClient(int clientID)
    {
        // Fetch invoices for the selected client
        var invoices = _invoiceRepository.GetInvoicesByClientId(clientID);

        // Bind the data to the DataGridView
        dgvInvoices.DataSource = invoices;

        // Format the columns (optional)
        dgvInvoices.Columns["InvoiceID"].HeaderText = "Invoice ID";
        dgvInvoices.Columns["InvoiceDate"].HeaderText = "Invoice Date";
        dgvInvoices.Columns["TotalAmount"].HeaderText = "Total Amount";
        dgvInvoices.Columns["TotalAmount"].DefaultCellStyle.Format = "C"; // Format as currency
    }
}
