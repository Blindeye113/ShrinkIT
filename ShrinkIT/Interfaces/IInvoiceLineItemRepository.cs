using ShrinkIT.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShrinkIT.Interfaces;
public interface IInvoiceLineItemRepository
{
    void AddInvoiceLineItem(InvoiceLineItem invoiceLineItem);
    void UpdateInvoiceLineItem(InvoiceLineItem invoiceLineItem);
    void DeleteInvoiceLineItem(int lineItemID);
    InvoiceLineItem GetInvoiceLineItem(int lineItemID);
    List<InvoiceLineItem> GetAllInvoiceLineItems();
    void DeleteInvoiceLineItemsByInvoiceId(int invoiceId);
    List<InvoiceLineItem> GetInvoiceLineItemsByInvoiceId(int invoiceId);
}
