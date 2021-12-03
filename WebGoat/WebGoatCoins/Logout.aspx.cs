using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OWASP.WebGoat.NET.WebGoatCoins
{
    public partial class Logout : System.Web.UI.Page
    {
        ILog log = LogManager.GetLogger("NOTIFY");
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            if(Request.Cookies["customer_login"] != null)
            {
                FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(Request.Cookies["customer_login"].Value);
                string customerEmail = ticket.Name;
                log.Info("User " + customerEmail + " performed a logout.");

            }
            FormsAuthentication.SignOut();
            Session.Clear();
            Session.Abandon();
            Session.RemoveAll();
            Response.Redirect("/Default.aspx");
        }
    }
}