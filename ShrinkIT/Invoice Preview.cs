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
public partial class Invoice_Preview : Form
{
    private readonly IInvoiceRepository _invoiceRepository;
    private readonly IClientRepository _clientRepository;
    private readonly IInvoiceItemRepository _invoiceItemRepository;
    private readonly IInvoiceLineItemRepository _invoiceLineItemRepository;
    private Invoice _invoice;

    public Invoice_Preview(int invoiceId)
    {
        InitializeComponent();
        _invoiceRepository = new InvoiceRepository();
        _clientRepository = new ClientRepository();
        _invoiceItemRepository = new InvoiceItemRepository();
        _invoiceLineItemRepository = new InvoiceLineItemRepository();

        LoadInvoice(invoiceId);
    }

    private void LoadInvoice(int invoiceId)
    {
        _invoice = _invoiceRepository.GetInvoice(invoiceId);
        if (_invoice == null)
        {
            MessageBox.Show("Invoice not found.");
            this.Close();
            return;
        }

        var client = _clientRepository.GetClient(_invoice.ClientID);
        var invoiceItems = _invoiceLineItemRepository.GetAllInvoiceLineItems()
            .Where(item => item.InvoiceID == _invoice.InvoiceID)
            .ToList();

        // Display invoice details
        txtInvoiceID.Text = _invoice.InvoiceID.ToString();
        txtClientName.Text = $"{client.FirstName} {client.LastName}";
        txtInvoiceDate.Text = _invoice.InvoiceDate.ToString("yyyy-MM-dd");
        txtTotalAmount.Text = _invoice.TotalAmount.ToString("C");

        // Display invoice items
        var itemsWithDetails = invoiceItems.Select(item => new
        {
            ItemName = _invoiceItemRepository.GetInvoiceItem(item.ItemID).ItemName,
            Quantity = item.Quantity,
            Price = _invoiceItemRepository.GetInvoiceItem(item.ItemID).ItemPrice,
            LineTotal = item.LineTotal
        }).ToList();

        dgvInvoiceItems.DataSource = itemsWithDetails;
    }

    private void btnSaveInvoice_Click(object sender, EventArgs e)
    {
        if (_invoice == null)
        {
            MessageBox.Show("No invoice to save.");
            return;
        }

        var client = _clientRepository.GetClient(_invoice.ClientID);
        var invoiceItems = _invoiceLineItemRepository.GetAllInvoiceLineItems()
            .Where(item => item.InvoiceID == _invoice.InvoiceID)
            .ToList();

        string invoiceContent = $"Invoice ID: {_invoice.InvoiceID}\n";
        invoiceContent += $"Client: {client.FirstName} {client.LastName}\n";
        invoiceContent += $"Date: {_invoice.InvoiceDate:yyyy-MM-dd}\n\n";
        invoiceContent += "Items:\n";
        foreach (var item in invoiceItems)
        {
            var invoiceItem = _invoiceItemRepository.GetInvoiceItem(item.ItemID);
            invoiceContent += $"{invoiceItem.ItemName} - {item.Quantity} x {invoiceItem.ItemPrice:C} = {item.LineTotal:C}\n";
        }
        invoiceContent += $"\nTotal Amount: {_invoice.TotalAmount:C}";

        string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        string fileName = $"Invoice_{_invoice.InvoiceID}.txt";
        string filePath = Path.Combine(desktopPath, "Invoices", fileName);

        string invoicesFolder = Path.Combine(desktopPath, "Invoices");
        if (!Directory.Exists(invoicesFolder))
        {
            Directory.CreateDirectory(invoicesFolder);
        }

        File.WriteAllText(filePath, invoiceContent);

        MessageBox.Show($"Invoice saved to {filePath}");
    }

    private void btnClose_Click(object sender, EventArgs e)
    {
        this.Close();
    }
}
