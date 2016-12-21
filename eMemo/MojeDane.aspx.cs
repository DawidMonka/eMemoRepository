using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MemoGameSite.Helpers;
using System.Data;
using MySql.Data.MySqlClient;
using eMemo.Helpers;

namespace eMemo
{
    public partial class MojeDane : System.Web.UI.Page
    {
        private PassField passField;
        private DataBaseConnection connection;
        private PersonalData personalData;
        private const string hiddenPass = "*******";
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                passField = new PassField();
                connection = new DataBaseConnection();
                displayAllUserData();

                //personalData = MySession.Current.PersonalData;
                //personalData.getAllDataFromDataBase();
                //displayUserData();
            }
        }

        private void displayAllUserData()
        {
            //NICK
            string userNick = MySession.Current.LoginNick;
            nick.Text = userNick;
            
            //PASS
            string password = passField.getPasswordFromDataBase(MySession.Current.LoginNick);
            pass.Text = hiddenPass;

            //NAME & SURNAME
            name.Text = connection.getStringValueFromDataBaseUsingNick(DataBaseConstants.UserTable.Name, userNick);
            surname.Text = connection.getStringValueFromDataBaseUsingNick(DataBaseConstants.UserTable.Surname, userNick);

            //BIRTH DATE
            //aby wyświetlić datę, trzeba wyciąć godzinę, którą zwraca zapytanie do bazy
            string fullDate = connection.getStringValueFromDataBaseUsingNick(DataBaseConstants.UserTable.BirthDate, userNick);
            if(fullDate.Length != 0)
                datepicker.Text = fullDate.Substring(0, 10);

            //SEX
            if (connection.getStringValueFromDataBaseUsingNick(DataBaseConstants.UserTable.Sex, userNick).Equals(DataBaseConstants.SexValue.Male))
                male.Checked = true;
            else
                female.Checked = true;

            //CITY
            cityList.SelectedValue = connection.getStringValueFromDataBaseUsingNick(DataBaseConstants.UserTable.City, userNick);
        }

        //private void displayUserData()
        //{
        //    nick.Text = personalData.Nick;
        //    pass.Text = hiddenPass;
        //    name.Text = personalData.Name;
        //    surname.Text = personalData.Surname;
        //    datepicker.Text = personalData.getBirthDate();

        //    if (personalData.Sex.Equals(DataBaseConstants.SexValue.Male))
        //        male.Checked = true;
        //    else
        //        female.Checked = true;

        //    cityList.SelectedValue = personalData.City;
        //}

        protected void updateButton_Click(object sender, EventArgs e)
        {

        }

        protected void showPass_Click(object sender, EventArgs e)
        {
            if(showPass.Text.Equals("Pokaż hasło"))
            {
                pass.Text = personalData.Password;
                showPass.Text = "Ukryj hasło";
            }
            else
            {
                pass.Text = hiddenPass;
                showPass.Text = "Pokaż hasło";
            }
        }
    }
}