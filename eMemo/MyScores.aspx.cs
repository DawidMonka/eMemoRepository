using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MemoGameSite.Helpers;
using eMemo.Helpers;

namespace eMemo
{
    /// <summary>
    /// Strona Moje wyniki prezentująca wyniki zalogowanego użytkownika
    /// </summary>
    public partial class MyScores : System.Web.UI.Page
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
                int wielkosc = Convert.ToInt32(Wielkosc.SelectedItem.Value);
                string tryb = Tryb.SelectedItem.Value;

                Results results = new Results();
                DataSet ds = new DataSet();

                ds = results.getResultsByNick(wielkosc, tryb, MySession.Current.LoginNick);

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
            }
            else
                Response.Redirect("~/Home.aspx");
        }

        protected void gridview1_SelectedIndexChanged(object sender, EventArgs e)
        {

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

            ds = results.getResultsByNick(wielkosc, tryb, MySession.Current.LoginNick);

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