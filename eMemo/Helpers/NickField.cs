using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using eMemo.Helpers;


namespace MemoGameSite.Helpers
{
    /// <summary>
    /// Klasa obsługująca pole Nick na stronie logowania
    /// </summary>
    public class NickField
    {
        private string adminNick = DataBaseConstants.AdminNick;
        private const string querryForNickCheck = "SELECT COUNT(*) FROM Uzytkownik WHERE nick='";
        
        private DataBaseConnection dataBaseConnection;

        public NickField()
        {
            dataBaseConnection = new DataBaseConnection();
        }

        /// <summary>
        /// Metoda sprawdzająca, czy nick należy do Administratora
        /// </summary>
        /// <param name="nick"></param>
        /// <returns></returns>
        public bool isAdminNick(string nick)
        {
            return nick.Equals(adminNick);
        }

        /// <summary>
        /// Metoda sprawdzająca czy podany nick jest w bazie danych
        /// </summary>
        /// <param name="nick"></param>
        /// <returns></returns>
        public bool checkIfNickInDataBase(string nick)
        {
            bool result = false;
            
            string checkQuerry = querryForNickCheck + nick + "'";

            //dataBaseConnection.openConnection();
            int row = Convert.ToInt32(dataBaseConnection.getStringValueFromDataBase(checkQuerry));
            //dataBaseConnection.closeConnection();

            if (row == 1)
                result = true;

            return result;
        }

        /// <summary>
        /// Metoda sprawdzająca, czy string jest pusty
        /// </summary>
        /// <param name="nick"></param>
        /// <returns></returns>
        public bool isEmpty(string nick)
        {
            return nick.Equals(String.Empty);
        }
    }
}