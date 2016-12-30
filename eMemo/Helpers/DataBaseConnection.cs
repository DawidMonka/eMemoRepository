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
        private static string mySqlConnectionString = "MySqlConnectionString";
        private MySqlConnection connection;

        public MySqlConnection Connection
        {
            get { return connection; }
            set { connection = value; }
        }

        public DataBaseConnection()
        {
            connection = new MySqlConnection(System.Configuration.ConfigurationManager.
                ConnectionStrings[mySqlConnectionString].ConnectionString);
        }

        public string ConnectionName
        {
            get { return mySqlConnectionString; }
            set { mySqlConnectionString = value; }
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

        public DataSet getDataSetFromDataBase(string query)
        {
            openConnection();
            MySqlCommand cmde = new MySqlCommand(query, connection);
            MySqlDataAdapter da = new MySqlDataAdapter(cmde);
            DataSet ds = new DataSet();
            da.Fill(ds);
            closeConnection();

            return ds;
        }
    }  
}