using System;
using System.Web;
using System.Web.UI;
using System.Text.RegularExpressions;

namespace OWASP.WebGoat.NET
{
    public partial class RegexDoS : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Code from https://www.owasp.org/index.php/Regular_expression_Denial_of_Service_-_ReDoS
        /// </summary>
        protected void btnCheckUsername_Click(object sender, EventArgs e)
        {
            string userName = txtUsername.Text;
            string available = txtAvailable.Text;
            string regex = "^(([A-Za-z])+.)+[A-Za-z]([0-9])+$";

            Regex testUsername = new Regex(regex);
            Match match = testUsername.Match(userName);
            if (match.Success)
            {
                lblError.Text = "Username does not meet acceptable standards.";
            }
            else
            {
                lblError.Text = "Good username.";
            }
        }
    }
}

