using MemoGameSite.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eMemo.Helpers
{
    /// <summary>
    /// Klasa obsługująca stronę, która wyświetla dane personane użytkownika 
    /// </summary
    public class PersonalData
    {
        private string nick;
        public string Nick
        {
            get { return nick; }
        }

        private string password;
        public string Password
        {
            get { return password; }
            set { password = value; }
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
            set { birthDate = value; }
        }

/*        public string getBirthDate()
        {
            string date = "";

            if (birthDate.Length != 0)
                date = birthDate.Substring(0, 10);

            return date;
        }*/

        public string getBirthDate()
        {
            string date = "";

            if (birthDate != DateTime.MinValue.ToString())
            {
                if (birthDate.Length != 0)
                    date = birthDate.Substring(0, 10);
            }

            return date;
        }

        private string city;
        public string City
        {
            get { return city; }
            set { city = value; }
        }
        
        private string sex;
        public string Sex
        {
            get { return sex; }
            set { sex = value; }
        }

        private bool dataIsComplete = false;
        public bool DataIsComplete
        {
            get { return dataIsComplete; }
            set { dataIsComplete = value; }
        }

        PassField passField;
        DataBaseConnection connection;

        public PersonalData(string nick)
        {
            this.nick = nick;
            DataIsComplete = false;
        }

        public bool getAllDataFromDataBase()
        {
            bool mustConnectToDataBase = false;
            
            if (!DataIsComplete)
            {
                getAllData();
                mustConnectToDataBase = true;
            }

            return mustConnectToDataBase;
        }

        private void getAllData()
        {
            connection = new DataBaseConnection();
            passField = new PassField();

            Password = passField.getPasswordFromDataBase(Nick);
            Name = connection.getStringValueFromDataBaseUsingNick(DataBaseConstants.UserTable.Name, Nick);
            Surname = connection.getStringValueFromDataBaseUsingNick(DataBaseConstants.UserTable.Surname, Nick);
            BirthDate = connection.getStringValueFromDataBaseUsingNick(DataBaseConstants.UserTable.BirthDate, Nick);
            Sex = connection.getStringValueFromDataBaseUsingNick(DataBaseConstants.UserTable.Sex, Nick);
            City = connection.getStringValueFromDataBaseUsingNick(DataBaseConstants.UserTable.City, Nick);

            DataIsComplete = true;
        }
    }
}