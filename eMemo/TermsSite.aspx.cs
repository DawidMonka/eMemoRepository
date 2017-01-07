using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eMemo
{

    /// <summary>
    /// Strona wyświetlająca Regulamin serwisu
    /// </summary>
    public partial class TermsSite : System.Web.UI.Page
    {
        static string prevPage = string.Empty;

        /// <summary>
        /// Metoda osługująca ładowanie strony
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.UrlReferrer != null)
                    prevPage = Request.UrlReferrer.ToString();
            }
        }

        /// <summary>
        /// Metoda obsługująca przycisk Powrót
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnBack_Click(object sender, EventArgs e)
        {
            if (!prevPage.Equals(String.Empty))
            {
                Response.Redirect(prevPage);
            }
            else
                Response.Redirect("~/Home.aspx");
        }
    }
}