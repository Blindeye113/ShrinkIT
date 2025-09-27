using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShrinkIT.Domain;
public class InvoiceItem
{
    public int ItemID { get; set; }
    public string ItemName { get; set; }
    public string ItemCode { get; set; }
    public decimal ItemPrice { get; set; }
}
