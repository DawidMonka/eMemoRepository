using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;
using MemoGameSite.Helpers;


namespace eMemo 
{
    public partial class Wyniki : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //DataBaseConnection connection = new DataBaseConnection();
            //connection.openConnection();
            //string cmdtText = "SELECT gracz, dataRozgrywa, lPkt, czasTrwania, lRuchow FROM rozgrywa order by dataRozgrywa desc limit 10";
            //MySqlCommand cmde = new MySqlCommand(cmdtText, connection.Connection);
            //MySqlDataAdapter da = new MySqlDataAdapter(cmde);
            //DataSet ds = new DataSet();
            //da.Fill(ds);
            //gridview1.DataSource = ds;
            //gridview1.DataBind();

            //connection.closeConnection();

            int wielkosc = Convert.ToInt32(Wielkosc.SelectedItem.Value);
            string tryb = Tryb.SelectedItem.Value;
            Results results = new Results();
            DataSet ds = new DataSet();
            ds = results.getResults(wielkosc,tryb);


            //Results results = new Results(wielkosc);
            //DataSet ds = new DataSet();

            //ds = results.getResultsByTime();

            gridview1.DataSource = ds;
            gridview1.DataBind();

            //BoundField test = new BoundField();
            //test.DataField = "New DATAfield Name";
            //test.Headertext = "New Header";
            //CustomersGridView.Columns.Add(test);

        }

        protected void Selection_Change(Object sender, EventArgs e)
        {

            // Set the background color for days in the Calendar control
            // based on the value selected by the user from the 
            // DropDownList control.
           

        }

        protected void btnApply_Click(Object sender, EventArgs e)
        {
            int wielkosc = Convert.ToInt32(Wielkosc.SelectedItem.Value);
            string tryb = Tryb.SelectedItem.Value;

            Results results = new Results();
            DataSet ds = new DataSet();
            ds = results.getResults(wielkosc, tryb);

            //if (tryb == "na czas")
            //{
            //    ds = results.getResultsByTime();    
            //}
            //if(tryb == "na punkty")
            //{
            //    ds = results.getResultsByPoints();
            //}

            gridview1.DataSource = ds;
            gridview1.DataBind();

            //DataBaseConnection connection = new DataBaseConnection();
            //connection.openConnection();
            //string cmdtText = "SELECT gracz, czasTrwania, lRuchow, lPkt, dataRozgrywa FROM rozgrywa where nrPlanszy ="+wielkosc+" and trybGry = '"+tryb+"'order by dataRozgrywa desc limit 10";
            //MySqlCommand cmde = new MySqlCommand(cmdtText, connection.Connection);
            //MySqlDataAdapter da = new MySqlDataAdapter(cmde);
            //DataSet ds = new DataSet();
            //da.Fill(ds);
            //gridview1.DataSource = ds;
            //gridview1.DataBind();
            

            ////close connection
            //connection.closeConnection();

        }
    }
}