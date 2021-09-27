using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using OWASP.WebGoat.NET.App_Code.DB;
using OWASP.WebGoat.NET.App_Code;

namespace OWASP.WebGoat.NET
{
	public partial class SQLInjection : System.Web.UI.Page
	{
    
        private IDbProvider du = Settings.CurrentDbProvider;
        
		protected void Page_Load (object sender, EventArgs e)
		{

		}
        public bool validateUerInput(String name)
        {
            var positiveRegex = new System.Text.RegularExpressions.Regex(@"^[A-Za-z0-9]*$");
            if (!positiveRegex.IsMatch(name))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
            protected void btnFind_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            bool nameValidated = validateUerInput(name);
            if (nameValidated == true)
            {
                DataSet ds = du.GetEmailByName(name);
                if (ds != null)
                {
                    grdEmail.DataSource = ds.Tables[0];
                    grdEmail.DataBind();
                }
            }
 
            

           
		}
	}
}