using ShrinkIT.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShrinkIT.Interfaces;
public interface IInvoiceRepository
{
    void AddInvoice(Invoice invoice);
    void UpdateInvoice(Invoice invoice);
    void DeleteInvoice(int invoiceID);
    Invoice GetInvoice(int invoiceID);
    List<Invoice> GetAllInvoices();
    List<Invoice> GetInvoicesByClientId(int clientID);
}
