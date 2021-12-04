using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Security.Principal;
using OWASP.WebGoat.NET.App_Code;
using log4net.Config;
using System.Diagnostics;

namespace OWASP.WebGoat.NET
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            //if (Debugger.IsAttached)
            //    BasicConfigurator.Configure();
            //else
                log4net.Config.XmlConfigurator.Configure();
            System.Web.Optimization.BundleTable.Bundles.Add(new System.Web.Optimization.ScriptBundle("~/bundle/js").Include("~/Resources/client-scripts/jquery-1.4.2.min.js", "~/Resources/client-scripts/menu.js", "~/Resources/client-scripts/jquery-ui-1.8.16.custom.min.js", "~/Resources/client-scripts/jquery-ui-1.8.16.custom.min.js", "~/Resources/client-scripts/jquery.autocomplete.js"));

            System.Web.Optimization.BundleTable.Bundles.Add(new System.Web.Optimization.StyleBundle("~/bundle/css").Include("~/Resources/jquery-ui/jquery-ui-1.8.16.custom.css", "~/Resources/jquery-libs/autocomplete/styles.css"));


            Settings.Init(Server);
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            if (Response.Cookies.Count > 0)
                foreach (string s in Response.Cookies.AllKeys)
                    if (s == System.Web.Security.FormsAuthentication.FormsCookieName || s.ToLower().Equals("asp.net_sessionid"))
                        Response.Cookies[s].HttpOnly = false;
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        void Application_PreSendRequestHeaders(Object sender, EventArgs e)
        {
            Response.AddHeader("X-XSS-Protection", "0");
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            //get the role data out of the encrypted cookie and add to current context
            //TODO: get this out of a different cookie

            if (HttpContext.Current.User != null)
            {
                if (HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    if (HttpContext.Current.User.Identity is FormsIdentity)
                    {
                        FormsIdentity id =
                            (FormsIdentity)HttpContext.Current.User.Identity;
                        FormsAuthenticationTicket ticket = id.Ticket;

                        // Get the stored user-data, in this case, our roles
                        string userData = ticket.UserData;
                        string[] roles = userData.Split(',');
                        HttpContext.Current.User = new GenericPrincipal(id, roles);
                    }
                }
            }
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

        protected void Application_EndRequest(object sender, EventArgs e)
        {
            if (Response.Cookies.Count > 0)
            {
                foreach (string s in Response.Cookies.AllKeys)
                {
                    Response.Cookies[s].HttpOnly = false;
                }
            }
        }
    }
}
