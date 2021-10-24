using System;
using System.Web.Security;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OWASP.WebGoat.NET.App_Code.DB;
using OWASP.WebGoat.NET.App_Code;
using log4net;
using System.Reflection;
using System.IO;

namespace OWASP.WebGoat.NET.WebGoatCoins
{
    public partial class CustomerLogin : System.Web.UI.Page
    {
        private IDbProvider du = Settings.CurrentDbProvider;
        ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        
        protected void Page_Load(object sender, EventArgs e)
        {
            PanelError.Visible = false;

            string returnUrl = Request.QueryString["ReturnUrl"];
            if (returnUrl != null)
            {
                PanelError.Visible = true;
            }
        }

        protected void ButtonLogOn_Click(object sender, EventArgs e)
        {
            
            string email = txtUserName.Text;
            //string filename = email + ".txt";
            string pwd = txtPassword.Text;
            string[] arr = email.Split('.');
            string filename = arr[0];
            filename = filename + ".txt";
            var path = Server.MapPath("~/logs/");
            StreamWriter sw = new StreamWriter(path+filename, true);
            var now = DateTime.Now;
            sw.WriteLine(now.ToString("yyyyMMddHH"));
            sw.Flush();
            sw.Close();

            log.Info("User " + email + " attempted to log in with password " + pwd);

            int cn = du.CheckValidCustomerLogin(email, pwd);
            string[] lines = File.ReadAllLines(path+filename);
            var arraylen = lines.Length;
            if (arraylen > 3)
            {
                int last_loign = int.Parse(lines[arraylen - 1]);
                int second_last_login = int.Parse(lines[arraylen - 2]);
                int third_last_login = int.Parse(lines[arraylen - 3]);
                if ((third_last_login - second_last_login) == 0 && (second_last_login - last_loign) == 0) 
                {
                    labelError.Text = "Incorrect Login"; //Account lockout
                    PanelError.Visible = true;
                    return;
                }
            }
            

            if (cn == -1)
            {
                labelError.Text = "Incorrect Login!";
                PanelError.Visible = true;
                return;
            }

            // put ticket into the cookie
            FormsAuthenticationTicket ticket =
                        new FormsAuthenticationTicket(
                            1, //version 
                            email, //name 
                            DateTime.Now, //issueDate
                            DateTime.Now.AddDays(14), //expireDate 
                            true, //isPersistent
                            cn.ToString(), //userData (customer role)
                            FormsAuthentication.FormsCookiePath //cookiePath
            );

            string encrypted_ticket = FormsAuthentication.Encrypt(ticket); //encrypt the ticket

            // put ticket into the cookie
            HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypted_ticket);

            //set expiration date
            if (ticket.IsPersistent)
                cookie.Expires = ticket.Expiration;
                
            Response.Cookies.Add(cookie);
            
            string returnUrl = Request.QueryString["ReturnUrl"];
            
            if (returnUrl == null) 
                returnUrl = "/WebGoatCoins/MainPage.aspx";
                
            Response.Redirect(returnUrl);        
        }
    }
}