﻿using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using eMemo.Helpers;

namespace eMemo
{
    public partial class SiteMaster : MasterPage
    {
        private const string AntiXsrfTokenKey = "__AntiXsrfToken";
        private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";
        private string _antiXsrfTokenValue;

        protected void Page_Init(object sender, EventArgs e)
        {
            // The code below helps to protect against XSRF attacks
            var requestCookie = Request.Cookies[AntiXsrfTokenKey];
            Guid requestCookieGuidValue;
            if (requestCookie != null && Guid.TryParse(requestCookie.Value, out requestCookieGuidValue))
            {
                // Use the Anti-XSRF token from the cookie
                _antiXsrfTokenValue = requestCookie.Value;
                Page.ViewStateUserKey = _antiXsrfTokenValue;
            }
            else
            {
                // Generate a new Anti-XSRF token and save to the cookie
                _antiXsrfTokenValue = Guid.NewGuid().ToString("N");
                Page.ViewStateUserKey = _antiXsrfTokenValue;

                var responseCookie = new HttpCookie(AntiXsrfTokenKey)
                {
                    HttpOnly = true,
                    Value = _antiXsrfTokenValue
                };
                if (FormsAuthentication.RequireSSL && Request.IsSecureConnection)
                {
                    responseCookie.Secure = true;
                }
                Response.Cookies.Set(responseCookie);
            }

            Page.PreLoad += master_Page_PreLoad;
        }

        protected void master_Page_PreLoad(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Set Anti-XSRF token
                ViewState[AntiXsrfTokenKey] = Page.ViewStateUserKey;
                ViewState[AntiXsrfUserNameKey] = Context.User.Identity.Name ?? String.Empty;
            }
            else
            {
                // Validate the Anti-XSRF token
                if ((string)ViewState[AntiXsrfTokenKey] != _antiXsrfTokenValue
                    || (string)ViewState[AntiXsrfUserNameKey] != (Context.User.Identity.Name ?? String.Empty))
                {
                    throw new InvalidOperationException("Validation of Anti-XSRF token failed.");
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)    
        {
            //gdy użytkonik jest zalogowany
            if (MySession.Current.isUserLoggedIn())
            {
                //ustawienie widoczności przycisków menu
                ranking.Visible = true;
                mojeDane.Visible = true;
                mojeWyniki.Visible = true;
                wylogujLinkButton.Visible = true;
                logowanie.Visible = false;
                rejestracja.Visible = false;
            }

            //gdy użytkownik to Administrator
            if (MySession.Current.LoginNick.Equals(DataBaseConstants.AdminNick))
            {
                //ustawienie widoczności przycisków menu
                ranking.Visible = true;
                mojeDane.Visible = false;
                mojeWyniki.Visible = false;
                daneUzytkownikow.Visible = true;
                wylogujLinkButton.Visible = true;
                logowanie.Visible = false;
                rejestracja.Visible = false;
            }
        }

        protected void Unnamed_LoggingOut(object sender, EventArgs e)
        {
            MySession.Current.LoggOffUser();

            //ustawienie widoczności przycisków menu
            ranking.Visible = false;
            mojeDane.Visible = false;
            mojeWyniki.Visible = false;
            wyloguj.Visible = false;
            logowanie.Visible = true;
            rejestracja.Visible = true;
            //Context.GetOwinContext().Authentication.SignOut();
        }

        protected void LoggOut_Click(object sender, EventArgs e)
        {
            MySession.Current.LoggOffUser();

            //ustawienie widoczności przycisków menu
            ranking.Visible = false;
            mojeDane.Visible = false;
            mojeWyniki.Visible = false;
            daneUzytkownikow.Visible = false;
            wylogujLinkButton.Visible = false;
            logowanie.Visible = true;
            rejestracja.Visible = true;
            Response.Redirect("~/Home.aspx");
            //Context.GetOwinContext().Authentication.SignOut();
        }
    }

}