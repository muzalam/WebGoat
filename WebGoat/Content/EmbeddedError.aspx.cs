using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OWASP.WebGoat.NET
{
    public partial class EmbeddedError : System.Web.UI.Page
    {
        public static string message = "There are no errors ... Only embedded errors...";

        protected void Page_Load(object sender, EventArgs e)
        {
            lblMessage.Text = message;
        }

        protected void addbtn_Click()
        {

        }
    }
}