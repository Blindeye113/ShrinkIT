using ShrinkIT.Domain;
using ShrinkIT.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShrinkIT.Data;
public class InvoiceRepository : IInvoiceRepository
{
    public void AddInvoice(Invoice invoice)
    {
        using (var conn = DatabaseHelper.GetConnection())
        {
            conn.Open();
            string query = "INSERT INTO Invoices (ClientID, InvoiceDate, TotalAmount) VALUES (@ClientID, @InvoiceDate, @TotalAmount); SELECT last_insert_rowid();";
            using (var cmd = new SQLiteCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@ClientID", invoice.ClientID);
                cmd.Parameters.AddWithValue("@InvoiceDate", invoice.InvoiceDate.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@TotalAmount", invoice.TotalAmount);
                int invoiceID = Convert.ToInt32(cmd.ExecuteScalar());

                invoice.InvoiceID = invoiceID;
            }
        }
    }

    public void UpdateInvoice(Invoice invoice)
    {
        using (var conn = DatabaseHelper.GetConnection())
        {
            conn.Open();
            string query = "UPDATE Invoices SET ClientID = @ClientID, InvoiceDate = @InvoiceDate, TotalAmount = @TotalAmount WHERE InvoiceID = @InvoiceID";
            using (var cmd = new SQLiteCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@ClientID", invoice.ClientID);
                cmd.Parameters.AddWithValue("@InvoiceDate", invoice.InvoiceDate.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@TotalAmount", invoice.TotalAmount);
                cmd.Parameters.AddWithValue("@InvoiceID", invoice.InvoiceID);
                cmd.ExecuteNonQuery();
            }
        }
    }

    public void DeleteInvoice(int invoiceID)
    {
        using (var conn = DatabaseHelper.GetConnection())
        {
            conn.Open();
            string query = "DELETE FROM Invoices WHERE InvoiceID = @InvoiceID";
            using (var cmd = new SQLiteCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@InvoiceID", invoiceID);
                cmd.ExecuteNonQuery();
            }
        }
    }

    public Invoice GetInvoice(int invoiceID)
    {
        using (var conn = DatabaseHelper.GetConnection())
        {
            conn.Open();
            string query = "SELECT * FROM Invoices WHERE InvoiceID = @InvoiceID";
            using (var cmd = new SQLiteCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@InvoiceID", invoiceID);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Invoice
                        {
                            InvoiceID = Convert.ToInt32(reader["InvoiceID"]),
                            ClientID = Convert.ToInt32(reader["ClientID"]),
                            InvoiceDate = Convert.ToDateTime(reader["InvoiceDate"]),
                            TotalAmount = Convert.ToDecimal(reader["TotalAmount"])
                        };
                    }
                }
            }
        }
        return null;
    }

    public List<Invoice> GetAllInvoices()
    {
        var invoices = new List<Invoice>();
        using (var conn = DatabaseHelper.GetConnection())
        {
            conn.Open();
            string query = "SELECT * FROM Invoices";
            using (var cmd = new SQLiteCommand(query, conn))
            {
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        invoices.Add(new Invoice
                        {
                            InvoiceID = Convert.ToInt32(reader["InvoiceID"]),
                            ClientID = Convert.ToInt32(reader["ClientID"]),
                            InvoiceDate = Convert.ToDateTime(reader["InvoiceDate"]),
                            TotalAmount = Convert.ToDecimal(reader["TotalAmount"])
                        });
                    }
                }
            }
        }
        return invoices;
    }

    public List<Invoice> GetInvoicesByClientId(int clientID)
    {
        var invoices = new List<Invoice>();
        using (var conn = DatabaseHelper.GetConnection())
        {
            conn.Open();
            string query = "SELECT * FROM Invoices WHERE ClientID = @ClientID";
            using (var cmd = new SQLiteCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@ClientID", clientID);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        invoices.Add(new Invoice
                        {
                            InvoiceID = Convert.ToInt32(reader["InvoiceID"]),
                            ClientID = Convert.ToInt32(reader["ClientID"]),
                            InvoiceDate = Convert.ToDateTime(reader["InvoiceDate"]),
                            TotalAmount = Convert.ToDecimal(reader["TotalAmount"])
                        });
                    }
                }
            }
        }
        return invoices;
    }
}
