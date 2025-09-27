using ShrinkIT.Domain;
using ShrinkIT.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShrinkIT.Data;
public class InvoiceLineItemRepository : IInvoiceLineItemRepository
{
    public void AddInvoiceLineItem(InvoiceLineItem invoiceLineItem)
    {
        using (var conn = DatabaseHelper.GetConnection())
        {
            conn.Open();
            string query = "INSERT INTO InvoiceLineItems (InvoiceID, ItemID, Quantity, LineTotal) VALUES (@InvoiceID, @ItemID, @Quantity, @LineTotal)";
            using (var cmd = new SQLiteCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@InvoiceID", invoiceLineItem.InvoiceID);
                cmd.Parameters.AddWithValue("@ItemID", invoiceLineItem.ItemID);
                cmd.Parameters.AddWithValue("@Quantity", invoiceLineItem.Quantity);
                cmd.Parameters.AddWithValue("@LineTotal", invoiceLineItem.LineTotal);
                cmd.ExecuteNonQuery();
            }
        }
    }

    public void UpdateInvoiceLineItem(InvoiceLineItem invoiceLineItem)
    {
        using (var conn = DatabaseHelper.GetConnection())
        {
            conn.Open();
            string query = "UPDATE InvoiceLineItems SET InvoiceID = @InvoiceID, ItemID = @ItemID, Quantity = @Quantity, LineTotal = @LineTotal WHERE LineItemID = @LineItemID";
            using (var cmd = new SQLiteCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@InvoiceID", invoiceLineItem.InvoiceID);
                cmd.Parameters.AddWithValue("@ItemID", invoiceLineItem.ItemID);
                cmd.Parameters.AddWithValue("@Quantity", invoiceLineItem.Quantity);
                cmd.Parameters.AddWithValue("@LineTotal", invoiceLineItem.LineTotal);
                cmd.Parameters.AddWithValue("@LineItemID", invoiceLineItem.LineItemID);
                cmd.ExecuteNonQuery();
            }
        }
    }

    public void DeleteInvoiceLineItem(int lineItemID)
    {
        using (var conn = DatabaseHelper.GetConnection())
        {
            conn.Open();
            string query = "DELETE FROM InvoiceLineItems WHERE LineItemID = @LineItemID";
            using (var cmd = new SQLiteCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@LineItemID", lineItemID);
                cmd.ExecuteNonQuery();
            }
        }
    }

    public InvoiceLineItem GetInvoiceLineItem(int lineItemID)
    {
        using (var conn = DatabaseHelper.GetConnection())
        {
            conn.Open();
            string query = "SELECT * FROM InvoiceLineItems WHERE LineItemID = @LineItemID";
            using (var cmd = new SQLiteCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@LineItemID", lineItemID);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new InvoiceLineItem
                        {
                            LineItemID = Convert.ToInt32(reader["LineItemID"]),
                            InvoiceID = Convert.ToInt32(reader["InvoiceID"]),
                            ItemID = Convert.ToInt32(reader["ItemID"]),
                            Quantity = Convert.ToInt32(reader["Quantity"]),
                            LineTotal = Convert.ToDecimal(reader["LineTotal"])
                        };
                    }
                }
            }
        }
        return null;
    }

    public List<InvoiceLineItem> GetAllInvoiceLineItems()
    {
        var invoiceLineItems = new List<InvoiceLineItem>();
        using (var conn = DatabaseHelper.GetConnection())
        {
            conn.Open();
            string query = "SELECT * FROM InvoiceLineItems";
            using (var cmd = new SQLiteCommand(query, conn))
            {
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        invoiceLineItems.Add(new InvoiceLineItem
                        {
                            LineItemID = Convert.ToInt32(reader["LineItemID"]),
                            InvoiceID = Convert.ToInt32(reader["InvoiceID"]),
                            ItemID = Convert.ToInt32(reader["ItemID"]),
                            Quantity = Convert.ToInt32(reader["Quantity"]),
                            LineTotal = Convert.ToDecimal(reader["LineTotal"])
                        });
                    }
                }
            }
        }
        return invoiceLineItems;
    }

    public void DeleteInvoiceLineItemsByInvoiceId(int invoiceId)
    {
        using (var conn = DatabaseHelper.GetConnection())
        {
            conn.Open();
            string query = "DELETE FROM InvoiceLineItems WHERE InvoiceID = @InvoiceID";
            using (var cmd = new SQLiteCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@InvoiceID", invoiceId);
                cmd.ExecuteNonQuery();
            }
        }
    }

    public List<InvoiceLineItem> GetInvoiceLineItemsByInvoiceId(int invoiceId)
    {
        var invoiceLineItems = new List<InvoiceLineItem>();
        using (var conn = DatabaseHelper.GetConnection())
        {
            conn.Open();
            string query = "SELECT il.*,ii.ItemName FROM InvoiceLineItems AS il " +
                            "INNER JOIN InvoiceItems AS ii ON ii.ItemID = il.ItemID " +
                            "WHERE InvoiceID = @InvoiceID";
            using (var cmd = new SQLiteCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@InvoiceID", invoiceId);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        invoiceLineItems.Add(new InvoiceLineItem
                        {
                            ItemName = reader["ItemName"].ToString(),
                            LineItemID = Convert.ToInt32(reader["LineItemID"]),
                            InvoiceID = Convert.ToInt32(reader["InvoiceID"]),
                            ItemID = Convert.ToInt32(reader["ItemID"]),
                            Quantity = Convert.ToInt32(reader["Quantity"]),
                            LineTotal = Convert.ToDecimal(reader["LineTotal"])
                        });
                    }
                }
            }
        }
        return invoiceLineItems;
    }
}
