using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MemoGameSite.Helpers
{
    /// <summary>
    /// Klasa obsługująca pole Hasło na stronie logowania
    /// </summary>
    public class PassField
    {
        private string selectPass = "SELECT haslo FROM Uzytkownik WHERE nick ='";

        private DataBaseConnection dataBaseConnection;

        public PassField()
        {
            dataBaseConnection = new DataBaseConnection();
        }

        public string CheckPass
        {
            get { return selectPass; }
            set { selectPass = value; }
        }

        /// <summary>
        /// Mtoda sprawdzająca czy hasło jest prawidłowe
        /// </summary>
        /// <param name="nick"></param>
        /// <param name="pass"></param>
        /// <returns></returns>
        public bool isPasswordCorrect(string nick, string pass)
        {
            return (getPasswordFromDataBase(nick).Equals(pass));
        }

        /// <summary>
        /// Metoda pobierająca hasło z bazy danych na podstawie nicka użytkownika
        /// </summary>
        /// <param name="nick"></param>
        /// <returns></returns>
        public string getPasswordFromDataBase(string nick)
        {
            string selectQuerry = CheckPass + nick + "'";

            //dataBaseConnection.openConnection();
            string value = dataBaseConnection.getStringValueFromDataBase(selectQuerry);
            //dataBaseConnection.closeConnection();

            return value;
        }

        /// <summary>
        /// Metoda sprawdzająca czy string (password) jest pusty
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool isEmpty(string password)
        {
            return password.Equals(String.Empty);
        }

        public bool isPasswordCorrectlyConfirmed(string pass, string conf)
        {
            return pass.Equals(conf);
        }
    }
}