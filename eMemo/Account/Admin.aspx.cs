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


namespace eMemo.Account
{
    /// <summary>
    /// Strona Administratora
    /// </summary>
    public partial class Admin : System.Web.UI.Page
    {
        
        /// <summary>
        /// Ładowanie strony
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (MySession.Current.LoginNick.Equals(DataBaseConstants.AdminNick))
            {
                //DataBaseConnection connection = new DataBaseConnection();
                //connection.openConnection();
                //string cmdtText = "SELECT nick, dataRej FROM uzytkownik order by nick";
                //MySqlCommand cmde = new MySqlCommand(cmdtText, connection.Connection);
                //MySqlDataAdapter da = new MySqlDataAdapter(cmde);
                //DataSet ds = new DataSet();
                //da.Fill(ds);
                //connection.closeConnection();
                UsersManagement usersmanagement = new UsersManagement();
                DataSet ds = new DataSet();
                ds = usersmanagement.getUsers();
                gridview1.DataSource = ds;
                gridview1.DataBind();
            }
            else
                Response.Redirect("~/Home.aspx");

        }

        /// <summary>
        /// Zmiana indeksu strony
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void OnPageIndexChanging(object sender,GridViewPageEventArgs e)
        {
            gridview1.PageIndex = e.NewPageIndex;
            gridview1.DataBind();
        }

        /// <summary>
        /// Potwierdzenie usunięcia użytkownika
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnConfirm(object sender, CommandEventArgs e)
        {
            string nick = e.CommandArgument as string; 
            UsersManagement usersmanagement = new UsersManagement();
            usersmanagement.deleteUser(nick);
            DataSet ds = new DataSet();
            ds = usersmanagement.getUsers();
            gridview1.DataSource = ds;
            gridview1.DataBind();
        }
    }
}