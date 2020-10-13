using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace MasterPageDemo
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["LoginInf"];
            HttpCookie admin = Request.Cookies["AdminInf"];
            if (cookie == null)
            {
                Session["name"] = "";
            }
            else
            {
                Session["name"] = cookie.Value.ToString();
            }

            if (admin == null)
            {
                Session["admin"] = "";
            }
            else
            {
                Session["admin"] = admin.Value.ToString();
            }
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}