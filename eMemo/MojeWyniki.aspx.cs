﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MemoGameSite.Helpers;

namespace eMemo
{
    public partial class MojeWyniki : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int wielkosc = Convert.ToInt32(Wielkosc.SelectedItem.Value);
            string tryb = Tryb.SelectedItem.Value;

            Results results = new Results(wielkosc);
            DataSet ds = new DataSet();

            ds = results.getResultByNick();

            gridview1.DataSource = ds;
            gridview1.DataBind();

        }

        protected void gridview1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnApply_Click(Object sender, EventArgs e)
        {


            int wielkosc = Convert.ToInt32(Wielkosc.SelectedItem.Value);
            string tryb = Tryb.SelectedItem.Value;

            Results results = new Results(wielkosc);
            DataSet ds = new DataSet();

            if (tryb == "na czas")
            {
                ds = results.getResultsByTimeByNick();
            }
            if (tryb == "na punkty")
            {
                ds = results.getResultsByPointsByNick();
            }

            gridview1.DataSource = ds;
            gridview1.DataBind();


            

        }
    }
}