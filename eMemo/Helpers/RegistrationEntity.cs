using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace MemoGameSite.Helpers
{
    /// <summary>
    /// Klasa odpowiedzialna za obsługę rejestracji użytkownika
    /// </summary>
    public class RegistrationEntity
    {
        private bool readyToRegistrate;
        private const string insertUserQuery = "INSERT INTO Uzytkownik " +
            "(nick, haslo, imie, nazwisko, dataRej, miasto, dataUr, plec) " +
            "VALUES (@nick, @pass, @name, @surname, @sign_date, @city, @birth_date, @sex)";
        private string nick;

        public string Nick
        {
            get { return nick; }
            set { nick = value; }
        }
        private string pass;

        public string Pass
        {
            get { return pass; }
            set { pass = value; }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string surname;

        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }
        private string birthDate;

        public string BirthDate
        {
            get { return birthDate; }
            set { birthDate = value; }
        }
        private string sex;

        public string Sex
        {
            get { return sex; }
            set { sex = value; }
        }
        private string city;

        public string City
        {
            get { return city; }
            set { city = value; }
        }
        private DateTime signDate;

        public DateTime SignDate
        {
            get { return signDate; }
            set { signDate = value; }
        }

        private bool acceptTerms = false;

        public bool AcceptTerms
        {
            get{return acceptTerms;}
            set{acceptTerms = value;}
        }

        public string InsertUserQuery   
        {
            get { return insertUserQuery; }
        }



        public RegistrationEntity(bool readyToRegistrate)
        {
            this.readyToRegistrate = readyToRegistrate;
        }

        public bool IsReadyToRegistrate()
        {
            return readyToRegistrate;
        }

        public bool isValueEmpty(string value)
        {
            if (value != null)
                return value.Equals(String.Empty);
            else
                return true;
        }

        public bool noValueIsEmpty()
        {
            return !isValueEmpty(Nick)
                && !isValueEmpty(Pass)
                && acceptTerms; 
            //&& !isValueEmpty(Name) &&   //te wartości nie są wymagane
                //!isValueEmpty(Surname) &&
                //!isValueEmpty(Sex) &&
                //!isValueEmpty(City);
        }

        /// <summary>
        /// Metoda zapisująca nowego użytkownika w bazie danych
        /// </summary>
        /// <param name="dataBaseConnection"></param>
        /// <returns></returns>
        public bool insertNewUser(DataBaseConnection dataBaseConnection)
        {
            bool result = false;
            
            try
            {
                dataBaseConnection.openConnection();
                
                MySqlCommand insertCommand = new MySqlCommand(insertUserQuery, dataBaseConnection.Connection);
                insertCommand.Parameters.AddWithValue("@nick", Nick);
                insertCommand.Parameters.AddWithValue("@pass", Pass);
                insertCommand.Parameters.AddWithValue("@name", Name);
                insertCommand.Parameters.AddWithValue("@surname", Surname);
                insertCommand.Parameters.AddWithValue("@birth_date", BirthDate);
                insertCommand.Parameters.AddWithValue("@sex", Sex);
                insertCommand.Parameters.AddWithValue("@city", City);
                insertCommand.Parameters.AddWithValue("@sign_date", SignDate);
                insertCommand.ExecuteNonQuery();
                
                dataBaseConnection.closeConnection();
                result = true;
            }
            catch(OperationCanceledException e) {}

            return result;
        }
    }
}