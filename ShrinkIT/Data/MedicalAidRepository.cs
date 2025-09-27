using ShrinkIT.Domain;
using ShrinkIT.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShrinkIT.Data;
public class MedicalAidRepository : IMedicalAidRepository
{
    public void AddMedicalAid(MedicalAid medicalAid)
    {
        using (var conn = DatabaseHelper.GetConnection())
        {
            conn.Open();
            string query = "INSERT INTO MedicalAid (ClientID, MedicalAidName, MedicalAidNumber) VALUES (@ClientID, @MedicalAidName, @MedicalAidNumber)";
            using (var cmd = new SQLiteCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@ClientID", medicalAid.ClientID);
                cmd.Parameters.AddWithValue("@MedicalAidName", medicalAid.MedicalAidName);
                cmd.Parameters.AddWithValue("@MedicalAidNumber", medicalAid.MedicalAidNumber);
                cmd.ExecuteNonQuery();
            }
        }
    }

    public void UpdateMedicalAid(MedicalAid medicalAid)
    {
        using (var conn = DatabaseHelper.GetConnection())
        {
            conn.Open();
            string query = "UPDATE MedicalAid SET ClientID = @ClientID, MedicalAidName = @MedicalAidName, MedicalAidNumber = @MedicalAidNumber WHERE MedicalAidID = @MedicalAidID";
            using (var cmd = new SQLiteCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@ClientID", medicalAid.ClientID);
                cmd.Parameters.AddWithValue("@MedicalAidName", medicalAid.MedicalAidName);
                cmd.Parameters.AddWithValue("@MedicalAidNumber", medicalAid.MedicalAidNumber);
                cmd.Parameters.AddWithValue("@MedicalAidID", medicalAid.MedicalAidID);
                cmd.ExecuteNonQuery();
            }
        }
    }

    public void DeleteMedicalAid(int medicalAidID)
    {
        using (var conn = DatabaseHelper.GetConnection())
        {
            conn.Open();
            string query = "DELETE FROM MedicalAid WHERE MedicalAidID = @MedicalAidID";
            using (var cmd = new SQLiteCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@MedicalAidID", medicalAidID);
                cmd.ExecuteNonQuery();
            }
        }
    }

    public MedicalAid GetMedicalAid(int medicalAidID)
    {
        using (var conn = DatabaseHelper.GetConnection())
        {
            conn.Open();
            string query = "SELECT * FROM MedicalAid WHERE MedicalAidID = @MedicalAidID";
            using (var cmd = new SQLiteCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@MedicalAidID", medicalAidID);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new MedicalAid
                        {
                            MedicalAidID = Convert.ToInt32(reader["MedicalAidID"]),
                            ClientID = Convert.ToInt32(reader["ClientID"]),
                            MedicalAidName = reader["MedicalAidName"].ToString(),
                            MedicalAidNumber = reader["MedicalAidNumber"].ToString()
                        };
                    }
                }
            }
        }
        return null;
    }

    public List<MedicalAid> GetAllMedicalAids()
    {
        var medicalAids = new List<MedicalAid>();
        using (var conn = DatabaseHelper.GetConnection())
        {
            conn.Open();
            string query = "SELECT * FROM MedicalAid";
            using (var cmd = new SQLiteCommand(query, conn))
            {
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        medicalAids.Add(new MedicalAid
                        {
                            MedicalAidID = Convert.ToInt32(reader["MedicalAidID"]),
                            ClientID = Convert.ToInt32(reader["ClientID"]),
                            MedicalAidName = reader["MedicalAidName"].ToString(),
                            MedicalAidNumber = reader["MedicalAidNumber"].ToString()
                        });
                    }
                }
            }
        }
        return medicalAids;
    }

    public MedicalAid GetMedicalAidByClientId(int clientId)
    {
        using (var conn = DatabaseHelper.GetConnection())
        {
            conn.Open();
            string query = "SELECT * FROM MedicalAid WHERE ClientID = @ClientID";
            using (var cmd = new SQLiteCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@ClientID", clientId);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new MedicalAid
                        {
                            MedicalAidID = Convert.ToInt32(reader["MedicalAidID"]),
                            ClientID = Convert.ToInt32(reader["ClientID"]),
                            MedicalAidName = reader["MedicalAidName"].ToString(),
                            MedicalAidNumber = reader["MedicalAidNumber"].ToString()
                        };
                    }
                }
            }
        }
        return null;
    }
}
