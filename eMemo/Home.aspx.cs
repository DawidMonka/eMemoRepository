using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eMemo
{
    public partial class Home : System.Web.UI.Page
    {
        private const string errorMssg = "Przepraszamy, aktualnie aplikacja jest niedostępna.";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void TermsSiteButtonClicked(object sender, EventArgs e)
        {
            Response.Redirect("~/TermsSite.aspx");
        }

        protected void androidClicked(object sender, EventArgs e)
        {
            string filename = "~/Downloads/eMemo.apk";
            downloadFile(filename);
        }

        protected void windowsClicked(object sender, EventArgs e)
        {
            string filename = "~/Downloads/eMemo.zip";
            downloadFile(filename);
        }

        protected void macOsCLicked(object sender, EventArgs e)
        {
            string filename = "~/Downloads/eMemoMac.zip";
            downloadFile(filename);
        }

        private void downloadFile(string filename)
        {
            if (filename != "")
            {
                string path = Server.MapPath(filename);
                System.IO.FileInfo file = new System.IO.FileInfo(path);
                if (file.Exists)
                {
                    Response.Clear();
                    Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name);
                    Response.AddHeader("Content-Length", file.Length.ToString());
                    Response.ContentType = "application/octet-stream";
                    Response.WriteFile(file.FullName);
                    Response.End();
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + errorMssg + "');", true);
                }
            }
        }

    }
}