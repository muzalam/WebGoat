using OWASP.WebGoat.NET.App_Code;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using log4net;
using System.Text;
using log4net;

namespace OWASP.WebGoat.NET
{
    public partial class LogInjection : System.Web.UI.Page
    {
        ILog log = LogManager.GetLogger("NOTIFY");
        protected void Page_Load(object sender, EventArgs e)
        {
            lblResultMessage.Text = "";
        }

        public void btnSubmit_Click(object sender, EventArgs args)
        {
            string result = "Ticket Successfully Submitted!";
            //byte[] msgBytes = Encoding.Unicode.GetBytes(txtBoxMsg.Text);
            //log.DebugFormat("{0}", Encoding.Unicode.GetString(msgBytes));
            lblResultMessage.Text = result;
        }

    }
}