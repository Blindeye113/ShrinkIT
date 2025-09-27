using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShrinkIT.Data;
public class DatabaseHelper
{
    public static SQLiteConnection GetConnection()
    {
        return new SQLiteConnection(BuildConnectionString());
    }

    private static string BuildConnectionString()
    {
        string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
        string relativePath = @"..\..\..\Data\patientDB.db";
        string dbPath = Path.Combine(baseDirectory, relativePath);
        string fullPath = Path.GetFullPath(dbPath);

        if (!File.Exists(fullPath))
        {
            throw new FileNotFoundException("Database file not found: " + fullPath);
        }

        return $"Data Source={fullPath};Version=3;";
    }
}
