using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPA_Desktop_CC
{

    public class ConnectDatabase
    {
        private string username = "root";
        private string password = "";
        private string database = "kong_bu_bank";
        private string host = "localhost";

        private string connectionStr;
        private MySqlConnection connection;
        private MySqlCommand cmd;
        private static ConnectDatabase Instance;

        public static ConnectDatabase getInstance()
        {
            if(Instance == null)
            {
                Instance = new ConnectDatabase();
            }
            return Instance;
        }

        private ConnectDatabase()
        {
            connectionStr = "SERVER="+host+";database="+database+";UID="+username+";PASSWORD="+password+";";
            connection = new MySqlConnection(connectionStr);
        }

        public DataTable executeQuery(string query)
        {
            DataTable dt = new DataTable();

            connection.Open();
            cmd = new MySqlCommand(query, connection);
            dt.Load(cmd.ExecuteReader());

            connection.Close();
            return dt;
        }

        public void executeUpdate(string query)
        {
            connection.Open();

            cmd = new MySqlCommand(query, connection);

            cmd.ExecuteReader();
            connection.Close();

        }

    }
}
