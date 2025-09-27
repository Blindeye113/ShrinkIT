using ShrinkIT.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShrinkIT.Interfaces;
public interface IInvoiceItemRepository
{
    void AddInvoiceItem(InvoiceItem invoiceItem);
    void UpdateInvoiceItem(InvoiceItem invoiceItem);
    void DeleteInvoiceItem(int itemID);
    InvoiceItem GetInvoiceItem(int itemID);
    List<InvoiceItem> GetAllInvoiceItems();
}
