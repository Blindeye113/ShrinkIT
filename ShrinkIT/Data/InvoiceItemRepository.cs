using ShrinkIT.Domain;
using ShrinkIT.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShrinkIT.Data;
public class InvoiceItemRepository : IInvoiceItemRepository
{
    public void AddInvoiceItem(InvoiceItem invoiceItem)
    {
        using (var conn = DatabaseHelper.GetConnection())
        {
            conn.Open();
            string query = "INSERT INTO InvoiceItems (ItemName, ItemPrice) VALUES (@ItemName, @ItemPrice)";
            using (var cmd = new SQLiteCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@ItemName", invoiceItem.ItemName);
                cmd.Parameters.AddWithValue("@ItemPrice", invoiceItem.ItemPrice);
                cmd.ExecuteNonQuery();
            }
        }
    }

    public void UpdateInvoiceItem(InvoiceItem invoiceItem)
    {
        using (var conn = DatabaseHelper.GetConnection())
        {
            conn.Open();
            string query = "UPDATE InvoiceItems SET ItemName = @ItemName, ItemPrice = @ItemPrice WHERE ItemID = @ItemID";
            using (var cmd = new SQLiteCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@ItemName", invoiceItem.ItemName);
                cmd.Parameters.AddWithValue("@ItemPrice", invoiceItem.ItemPrice);
                cmd.Parameters.AddWithValue("@ItemID", invoiceItem.ItemID);
                cmd.ExecuteNonQuery();
            }
        }
    }

    public void DeleteInvoiceItem(int itemID)
    {
        using (var conn = DatabaseHelper.GetConnection())
        {
            conn.Open();
            string query = "DELETE FROM InvoiceItems WHERE ItemID = @ItemID";
            using (var cmd = new SQLiteCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@ItemID", itemID);
                cmd.ExecuteNonQuery();
            }
        }
    }

    public InvoiceItem GetInvoiceItem(int itemID)
    {
        using (var conn = DatabaseHelper.GetConnection())
        {
            conn.Open();
            string query = "SELECT * FROM InvoiceItems WHERE ItemID = @ItemID";
            using (var cmd = new SQLiteCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@ItemID", itemID);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new InvoiceItem
                        {
                            ItemID = Convert.ToInt32(reader["ItemID"]),
                            ItemName = reader["ItemName"].ToString(),
                            ItemPrice = Convert.ToDecimal(reader["ItemPrice"])
                        };
                    }
                }
            }
        }
        return null;
    }

    public List<InvoiceItem> GetAllInvoiceItems()
    {
        var invoiceItems = new List<InvoiceItem>();
        using (var conn = DatabaseHelper.GetConnection())
        {
            conn.Open();
            string query = "SELECT * FROM InvoiceItems";
            using (var cmd = new SQLiteCommand(query, conn))
            {
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        invoiceItems.Add(new InvoiceItem
                        {
                            ItemID = Convert.ToInt32(reader["ItemID"]),
                            ItemName = reader["ItemName"].ToString(),
                            ItemPrice = Convert.ToDecimal(reader["ItemPrice"])
                        });
                    }
                }
            }
        }
        return invoiceItems;
    }
}
