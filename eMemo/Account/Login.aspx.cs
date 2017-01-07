using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using eMemo.Models;
using MemoGameSite.Helpers;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System.Web.Security;
using eMemo.Helpers;

namespace eMemo.Account
{
    /// <summary>
    /// Strona logowania
    /// </summary>
    public partial class Login : Page
    {
    //    private bool ActivateCookie(string userName, string password, bool rememberMe)
    //    {
    //        if (Membership.ValidateUser(userName, password))
    //        {
    //            CookieHelper newCookieHelper =
    //            new CookieHelper(HttpContext.Request, HttpContext.Response);
    //            newCookieHelper.SetLoginCookie(userName, password, rememberMe);
    //            return true;
    //        }
    //        else
    //        {
    //            return false;
    //        }
    //    }

    }
}