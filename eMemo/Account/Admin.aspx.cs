using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MemoGameSite.Helpers;
using System.Data;
using MySql.Data.MySqlClient;


namespace eMemo.Account
{
    public partial class Admin : System.Web.UI.Page
    {
        
        
        protected void Page_Load(object sender, EventArgs e)
        {
            DataBaseConnection connection = new DataBaseConnection();
            connection.openConnection();
            string cmdtText = "SELECT nick, dataRej FROM uzytkownik order by nick";
            MySqlCommand cmde = new MySqlCommand(cmdtText, connection.Connection);
            MySqlDataAdapter da = new MySqlDataAdapter(cmde);
            DataSet ds = new DataSet();
            da.Fill(ds);
            connection.closeConnection();


            gridview1.DataSource = ds;
            gridview1.DataBind();

        }
        
        protected void OnPageIndexChanging(object sender,GridViewPageEventArgs e)
        {
            gridview1.PageIndex = e.NewPageIndex;
            gridview1.DataBind();
        }

        public void OnConfirm(object sender, CommandEventArgs e)
        {
            string nick = e.CommandArgument as string;
            /**
            Remove nick
            */
        }
    }
}