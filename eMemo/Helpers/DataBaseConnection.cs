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
        /// <summary>
        /// Definicja ConnectionString
        /// </summary>
        private static string mySqlConnectionString = "MySqlConnectionString";

        /// <summary>
        /// Połączenie z bazą MySql
        /// </summary>
        private MySqlConnection connection;

        public MySqlConnection Connection
        {
            get { return connection; }
            set { connection = value; }
        }

        /// <summary>
        /// Konstruktor klasy
        /// </summary>
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

        /// <summary>
        /// Metoda otwierająca połączenie
        /// </summary>
        public void openConnection()
        {
            Connection.Open();
        }

        /// <summary>
        /// Metoda zamykająca połączenie
        /// </summary>
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

        /// <summary>
        /// Metoda sprawdzająca, czy połączenie jest otwarte
        /// </summary>
        /// <returns></returns>
        public bool isConnectionOpen()
        {
            return connection.State == ConnectionState.Open;       
        }

        /// <summary>
        /// Metoda zwracająca wartość z kolumny zleżnie od warości nick 
        /// </summary>
        /// <param name="columnName"></param>
        /// <param name="nick"></param>
        /// <returns></returns>
        public string getStringValueFromDataBaseUsingNick(string columnName, string nick)
        {
            return getStringValueFromDataBase(selectQueryUsingNick(columnName, nick));
        }

        /// <summary>
        /// Metoda budująca zapytanie dla zadanej nazwy kolumny i wartości nick
        /// </summary>
        /// <param name="columnName"></param>
        /// <param name="nick"></param>
        /// <returns></returns>
        private string selectQueryUsingNick(string columnName, string nick)
        {
            string querryPt1 = "SELECT ";
            string querryPt2 = "  FROM " + DataBaseConstants.UserTableName + 
                               " WHERE " + DataBaseConstants.UserTable.Nick + " = ";

            return querryPt1 + columnName + querryPt2 + "'" + nick + "'";
        }

        /// <summary>
        /// Metoda zwracająca DataSet z bazy
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
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