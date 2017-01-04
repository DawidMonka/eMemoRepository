using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using eMemo.Helpers;
using MySql.Data.MySqlClient;
using MemoGameSite.Helpers;



namespace eMemo.Helpers
{
    /// <summary>
    /// Klasa obsługująca zarządzanie kontami użytkowników przez administratora
    /// </summary>
    public class UsersManagement
    {
        private DataBaseConnection connection;
        private const string deleteScoresQuery = "DELETE FROM rozgrywa WHERE gracz = @nick";
        private const string deleteUserQuery = "DELETE FROM uzytkownik WHERE nick = @nick";
        public UsersManagement()
        {
            connection = new DataBaseConnection();
            
    }
        /// <summary>
        /// metoda zwraca zbiór danych z użytkowników - nick i data rejestracji z wyłączeniem administratora
        /// </summary>
        /// <returns></returns>
        public DataSet getUsers()
        {
            //string cmdtText = "SELECT nick, dataRej FROM uzytkownik order by nick";
            string cmdtText = String.Format("SELECT {0}, {1} FROM {2} where {3} != 'Admin' order by {4}",
               DataBaseConstants.UserTable.Nick,
               DataBaseConstants.UserTable.RegDate,
               DataBaseConstants.UserTableName,
               DataBaseConstants.UserTable.Nick,
               DataBaseConstants.UserTable.Nick
                );
            return connection.getDataSetFromDataBase(cmdtText);
        }
        /// <summary>
        /// metoda usuwająca wyniki użytkownika i dane użytkownika o podanym nicku
        /// </summary>
        /// <param name="nick"></param>
        /// <returns></returns>
        public bool deleteUser(string nick)
        {

            bool result = false;

            try
            {
                connection.openConnection();

                MySqlCommand deleteCommandForScores = new MySqlCommand(deleteScoresQuery, connection.Connection);
                MySqlCommand deleteCommandForUser = new MySqlCommand(deleteUserQuery, connection.Connection);
                deleteCommandForScores.Parameters.AddWithValue("nick", nick);
                deleteCommandForUser.Parameters.AddWithValue("nick", nick);
                deleteCommandForScores.ExecuteNonQuery();
                deleteCommandForUser.ExecuteNonQuery();

                connection.closeConnection();
                result = true;
            }
            catch (OperationCanceledException e) {

            }

            return result;
        }
    }
}