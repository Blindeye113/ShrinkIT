using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShrinkIT.Domain;
public class Invoice
{
    public int InvoiceID { get; set; }
    public int ClientID { get; set; } // Foreign key to Client
    public DateTime InvoiceDate { get; set; }
    public decimal TotalAmount { get; set; }
}
