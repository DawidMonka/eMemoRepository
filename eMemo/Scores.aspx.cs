using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;
using MemoGameSite.Helpers;
using eMemo.Helpers;


namespace eMemo 
{
    /// <summary>
    /// Strona prezentująca Ranking wyników
    /// </summary>
    public partial class Scores : System.Web.UI.Page
    {
        /// <summary>
        /// Ładowanie strony
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (MySession.Current.isUserLoggedIn())
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
                ds = results.getResults(wielkosc, tryb);


                //Results results = new Results(wielkosc);
                //DataSet ds = new DataSet();

                //ds = results.getResultsByTime();
                if (tryb == "na czas")
                {
                    gridview1.Columns[3].Visible = false;
                    gridview1.Columns[4].Visible = true;
                    gridview1.Columns[5].Visible = true;
                }
                if (tryb == "na punkty")
                {
                    gridview1.Columns[3].Visible = true;
                    gridview1.Columns[4].Visible = false;
                    gridview1.Columns[5].Visible = false;
                }


                gridview1.DataSource = ds;
                gridview1.DataBind();

                //BoundField test = new BoundField();
                //test.DataField = "New DATAfield Name";
                //test.Headertext = "New Header";
                //CustomersGridView.Columns.Add(test);
            }
            else
                Response.Redirect("~/Home.aspx");

        }

        protected void Selection_Change(Object sender, EventArgs e)
        {

            // Set the background color for days in the Calendar control
            // based on the value selected by the user from the 
            // DropDownList control.
           

        }

        /// <summary>
        /// Obsługa przycisku Zatwierdź
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            if (tryb == "na czas")
            {
                gridview1.Columns[3].Visible = false;
                gridview1.Columns[4].Visible = true;
                gridview1.Columns[5].Visible = true;
            }
            if (tryb == "na punkty")
            {
                gridview1.Columns[3].Visible = true;
                gridview1.Columns[4].Visible = false;
                gridview1.Columns[5].Visible = false;
            }

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

        /// <summary>
        /// Zmiana indeksu strony
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridview1.PageIndex = e.NewPageIndex;
            gridview1.DataBind();
        }
    }
}