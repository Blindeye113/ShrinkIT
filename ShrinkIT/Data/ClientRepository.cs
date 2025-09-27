using ShrinkIT.Domain;
using ShrinkIT.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShrinkIT.Data;
public class ClientRepository : IClientRepository
{
    public void AddClient(Client client)
    {
        using (var conn = DatabaseHelper.GetConnection())
        {
            conn.Open();
            string query = "INSERT INTO Clients (FirstName, LastName, Email, Phone) VALUES (@FirstName, @LastName, @Email, @Phone)";
            using (var cmd = new SQLiteCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@FirstName", client.FirstName);
                cmd.Parameters.AddWithValue("@LastName", client.LastName);
                cmd.Parameters.AddWithValue("@Email", client.Email);
                cmd.Parameters.AddWithValue("@Phone", client.Phone);
                cmd.ExecuteNonQuery();
            }
        }
    }

    public void UpdateClient(Client client)
    {
        using (var conn = DatabaseHelper.GetConnection())
        {
            conn.Open();
            string query = "UPDATE Clients SET FirstName = @FirstName, LastName = @LastName, Email = @Email, Phone = @Phone WHERE ClientID = @ClientID";
            using (var cmd = new SQLiteCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@FirstName", client.FirstName);
                cmd.Parameters.AddWithValue("@LastName", client.LastName);
                cmd.Parameters.AddWithValue("@Email", client.Email);
                cmd.Parameters.AddWithValue("@Phone", client.Phone);
                cmd.Parameters.AddWithValue("@ClientID", client.ClientID);
                cmd.ExecuteNonQuery();
            }
        }
    }

    public void DeleteClient(int clientID)
    {
        using (var conn = DatabaseHelper.GetConnection())
        {
            conn.Open();
            string query = "DELETE FROM Clients WHERE ClientID = @ClientID";
            using (var cmd = new SQLiteCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@ClientID", clientID);
                cmd.ExecuteNonQuery();
            }
        }
    }

    public Client GetClient(int clientID)
    {
        using (var conn = DatabaseHelper.GetConnection())
        {
            conn.Open();
            string query = "SELECT * FROM Clients WHERE ClientID = @ClientID";
            using (var cmd = new SQLiteCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@ClientID", clientID);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Client
                        {
                            ClientID = Convert.ToInt32(reader["ClientID"]),
                            FirstName = reader["FirstName"].ToString(),
                            LastName = reader["LastName"].ToString(),
                            Email = reader["Email"].ToString(),
                            Phone = reader["Phone"].ToString()
                        };
                    }
                }
            }
        }
        return null;
    }

    public List<Client> GetAllClients()
    {
        var clients = new List<Client>();
        using (var conn = DatabaseHelper.GetConnection())
        {
            conn.Open();
            string query = "SELECT * FROM Clients";
            using (var cmd = new SQLiteCommand(query, conn))
            {
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        clients.Add(new Client
                        {
                            ClientID = Convert.ToInt32(reader["ClientID"]),
                            FirstName = reader["FirstName"].ToString(),
                            LastName = reader["LastName"].ToString(),
                            Email = reader["Email"].ToString(),
                            Phone = reader["Phone"].ToString()
                        });
                    }
                }
            }
        }
        return clients;
    }
}
