using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO_EF.Data
{
    internal class Sql
    {
        static private readonly string _connectionString = "server=MSI;database=ADONET;Trusted_connection=true;Integrated security=true;";
        static private readonly SqlConnection _connection = new SqlConnection(_connectionString);

        public int ExecuteCommand(string command)
        {
            _connection.Open();
            SqlCommand cmd = new SqlCommand(command,_connection);
            int result = cmd.ExecuteNonQuery();
            _connection.Close();
            return result;
        }
        public DataTable ExecuteQuery(string query)
        {
            _connection.Open();

            SqlDataAdapter dataAdapter = new SqlDataAdapter(query,_connection);
            DataTable table = new DataTable();
            dataAdapter.Fill(table);

            _connection.Close();

            return table;
          
        }
    }
}
