using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OWASP.WebGoat.NET.App_Code.DB;
using OWASP.WebGoat.NET.App_Code;
using System.Web.Security;

namespace OWASP.WebGoat.NET.WebGoatCoins
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        private IDbProvider du = Settings.CurrentDbProvider;
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonChangePassword_Click(object sender, EventArgs e)
        {
            if(txtPassword1.Text != null && txtPassword2.Text != null && txtPassword1.Text == txtPassword2.Text)
            {
                //get customer ID
                FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(Request.Cookies["customer_login"].Value);
                string customerEmail = ticket.Name;
                string customerNumber = ticket.UserData;

                if (customerNumber != null)
                {
                    string output = du.UpdateCustomerPassword(int.Parse(customerNumber), txtPassword1.Text);
                    labelMessage.Text = output;
                }
            }
            else
            {
                labelMessage.Text = "Passwords do not match!  Please try again!";
            }

        }
    }
}