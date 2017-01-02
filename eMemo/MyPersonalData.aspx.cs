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
    public partial class MyPersonalData : Page
    {
        private PersonalData personalData;
        private const string hiddenPass = "*******";
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (MySession.Current.isUserLoggedIn())
            {
                personalData = MySession.Current.PersonalData;

                if (!Page.IsPostBack)
                {
                    personalData.getAllDataFromDataBase();
                    displayUserData();
                }
            }
            else
                Response.Redirect("~/Home.aspx");

        }

        private void displayUserData()
        {
            nick.Text = personalData.Nick;
            pass.Text = hiddenPass;
            name.Text = personalData.Name;
            surname.Text = personalData.Surname;
            datepicker.Text = personalData.getBirthDate();

            if (personalData.Sex.Equals(DataBaseConstants.SexValue.Male))
                male.Checked = true;
            else
                female.Checked = true;

            cityList.SelectedValue = personalData.City;
        }

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