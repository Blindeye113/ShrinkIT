using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShrinkIT.Domain;
public class InvoiceLineItem
{
    public int LineItemID { get; set; }
    public int InvoiceID { get; set; } // Foreign key to Invoice
    public int ItemID { get; set; } // Foreign key to InvoiceItem
    public int Quantity { get; set; }
    public decimal LineTotal { get; set; }

    public string? ItemName { get; set; }

}
