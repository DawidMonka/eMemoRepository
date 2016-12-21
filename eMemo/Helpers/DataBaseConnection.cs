using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;
using eMemo.Helpers;

namespace MemoGameSite.Helpers 
{
    /// <summary>
    /// Klasa obsługująca połączenie z bazą danych
    /// </summary>
    public class DataBaseConnection
    {
        private string connectionName;
        private MySqlConnection connection;
        private const string server = "localhost";
        private const string database = "memogamedatabase";
        private const string uid = "root";
        private const string password = "Demby88!";

        //private const string server = "mysql3.gear.host";
        //private const string database = "ememodbmysql";
        //private const string uid = "ememodbmysql";
        //private const string password = "eMemo!";

        public MySqlConnection Connection
        {
            get { return connection; }
            set { connection = value; }
        }

        public DataBaseConnection()
        {
            connectionName = "SERVER=" + server + ";" + "DATABASE=" +
                             database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionName);
        }

        public string ConnectionName
        {
            get { return connectionName; }
            set { connectionName = value; }
        }

        public void openConnection()
        {
            Connection.Open();
        }

        public void closeConnection()
        {
            Connection.Close();
        }

        /// <summary>
        /// Metoda pobierająca wartość z bazy danych na podstawie zapytania
        /// </summary>
        /// <param name="querry"></param>
        /// <returns></returns>
        public string getStringValueFromDataBase(string querry)
        {
            string result = "";

            openConnection();
            MySqlCommand command = new MySqlCommand(querry, connection);
            result = command.ExecuteScalar().ToString();
            closeConnection();

            return result;
        }

        public bool isConnectionOpen()
        {
            return connection.State == ConnectionState.Open;       
        }

        public string getStringValueFromDataBaseUsingNick(string columnName, string nick)
        {
            return getStringValueFromDataBase(selectQueryUsingNick(columnName, nick));
        }

        private string selectQueryUsingNick(string columnName, string nick)
        {
            string querryPt1 = "SELECT ";
            string querryPt2 = "  FROM " + DataBaseConstants.UserTableName + 
                               " WHERE " + DataBaseConstants.UserTable.Nick + " = ";

            return querryPt1 + columnName + querryPt2 + "'" + nick + "'";
        }
    }  
}