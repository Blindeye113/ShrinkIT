using iText.IO.Image;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using ShrinkIT.Data;
using ShrinkIT.Domain;
using ShrinkIT.Interfaces;
using System;
using System.IO;
using Image = iText.Layout.Element.Image;

public class PdfInvoiceGenerator
{
    private readonly IClientRepository _clientRepository;
    private readonly IInvoiceLineItemRepository _invoiceLineItemRepository;
    private readonly IInvoiceItemRepository _invoiceItemRepository;

    public PdfInvoiceGenerator()
    {
        _clientRepository = new ClientRepository();
        _invoiceLineItemRepository = new InvoiceLineItemRepository();
        _invoiceItemRepository = new InvoiceItemRepository();
    }

    public void GenerateInvoice(Invoice invoice, string filePath)
    {
        // Create a PDF writer
        using (PdfWriter writer = new PdfWriter(filePath))
        {
            // Initialize PDF document
            using (PdfDocument pdf = new PdfDocument(writer))
            {
                // Initialize document
                Document document = new Document(pdf);

                // Add header
                AddHeader(document);

                // Add client details
                AddClientDetails(document, invoice);

                // Add invoice details
                AddInvoiceDetails(document, invoice);

                // Add invoice items table
                AddInvoiceItemsTable(document, invoice);

                // Add footer
                AddFooter(document);

                // Close the document
                document.Close();
            }
        }
    }

    private void AddHeader(Document document)
    {
        // Add logo and header text
        Paragraph header = new Paragraph()
            .Add(new Image(ImageDataFactory.Create("path/to/logo.png")).SetWidth(100).SetHeight(100))
            .Add(new Text("Anuschka Mouton\nOccupational Therapist\nHPCSA: OT0023574\nPR: 6612164\n").SetBold())
            .Add(new Text("Invoice").SetFontSize(20).SetBold());

        document.Add(header);
    }

    private void AddClientDetails(Document document, Invoice invoice)
    {
        var client = _clientRepository.GetClient(invoice.ClientID);
        // Add client details
        Paragraph clientDetails = new Paragraph()
            .Add($"Mr {client.FullName}\n")
            .Add($"{client.Address}\n")
            .Add($"Cell: {client.Phone}\n")
            .Add($"Email: {client.Email}\n");

        document.Add(clientDetails);
    }

    private void AddInvoiceDetails(Document document, Invoice invoice)
    {
        // Add invoice details
        Paragraph invoiceDetails = new Paragraph()
            .Add($"Date: {invoice.InvoiceDate:dd MMMM yyyy}\n")
            .Add($"Invoice #: {invoice.InvoiceID}\n");

        document.Add(invoiceDetails);
    }

    private void AddInvoiceItemsTable(Document document, Invoice invoice)
    {
        var lineItems = _invoiceLineItemRepository.GetInvoiceLineItemsByInvoiceId(invoice.InvoiceID);
        var invoiceItems = _invoiceItemRepository.GetAllInvoiceItems();
        // Create a table for invoice items
        Table table = new Table(UnitValue.CreatePercentArray(5)).UseAllAvailableWidth();

        // Add table headers
        table.AddHeaderCell("Date");
        table.AddHeaderCell("Code");
        table.AddHeaderCell("Description");
        table.AddHeaderCell("Units");
        table.AddHeaderCell("Unit Cost");
        table.AddHeaderCell("Sub-total");

        // Add invoice items
        foreach (var item in lineItems)
        {
            table.AddCell(invoice.InvoiceDate.ToString("dd/MM/yyyy"));
            table.AddCell(invoiceItems.Where(i => i.ItemID == item.ItemID).Select(i => i.ItemCode).First().ToString());
            table.AddCell(item.ItemName);
            table.AddCell(item.Quantity.ToString());
            table.AddCell(invoiceItems.Where(i => i.ItemID == item.ItemID).Select(i => i.ItemPrice).First().ToString("C"));
            table.AddCell(item.LineTotal.ToString("C"));
        }


        // Add total row
        table.AddCell("").AddCell("").AddCell("").AddCell("Total").AddCell(invoice.TotalAmount.ToString("C"));

        document.Add(table);
    }

    private void AddFooter(Document document)
    {
        // Add footer with account details
        Paragraph footer = new Paragraph()
            .Add("Account details: Bank -- FNB, Account name -- A Mouton, Account number -- 62399934902, Branch code 250655\n")
            .Add("Proof of Payment to: admin@piff.co.za");

        document.Add(footer);
    }
}