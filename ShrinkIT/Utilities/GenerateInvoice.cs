using ShrinkIT.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShrinkIT.Utilities;
public class GenerateInvoice
{
    public bool CreateAndSaveInvoice(string clientName, List<InvoiceLineItem> invoiceItems, float totalAmount)
    {
        string invoiceContent = $"Invoice for {clientName}\n\n";
        invoiceContent += $"Date: {DateTime.Now}\n";
        invoiceContent += "Items:\n";
        foreach (var item in invoiceItems)
        {
            //invoiceContent += $"{item.ItemName} - {item.Quantity} x {item.ItemPrice} = {item.LineTotal}\n";
        }
        invoiceContent += $"Total Amount: {totalAmount}";

        string filePath = Path.Combine("Invoices", $"Invoice_{DateTime.Now:yyyyMMddHHmmss}.txt");
        File.WriteAllText(filePath, invoiceContent);
        return true;
    }
}
