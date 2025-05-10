using System;
using System.Data.SqlClient;

namespace OrnekProje
{
    public static class Database
    {
        public static SqlConnection Connection;

        public static void InitializeConnection()
        {
            string connectionString = "Server=192.168.1.175,1433;Database=NYPdb;User ID=sulo;Password=abc123987";
            Connection = new SqlConnection(connectionString);
            Connection.Open();
        }

        public static void CloseConnection()
        {
            if (Connection != null && Connection.State == System.Data.ConnectionState.Open)
                Connection.Close();
        }
    }
}