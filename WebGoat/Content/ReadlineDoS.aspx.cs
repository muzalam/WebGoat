using System;
using System.Web;
using System.Web.UI;
using System.IO;

namespace OWASP.WebGoat.NET
{
    public partial class ReadlineDoS : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            /*lblFileContent.Text = String.Empty;
            Stream fileContents = file1.PostedFile.InputStream;
        
            using (StreamReader reader = new StreamReader(fileContents))
            {
                while (!reader.EndOfStream)
                {
                    lblFileContent.Text += reader.ReadLine() + "<br />";
                }
            }
            */
            if(file1.HasFile)
            {
                if(file1.PostedFile.ContentLength< 20728650)
                {
                    string filename = Path.GetFileName(file1.FileName);
                    string Extension = Path.GetExtension(file1.FileName);
                    if (Extension == ".xls" || Extension == ".pdf" || Extension == ".txt")
                    file1.SaveAs(Server.MapPath("~/WebGoatCoins/uploads/") + filename);
                }
            }
            else
            {
                lblFileContent.Text = "File too large";
            }
            
            {
                //bool nameValidated = validateUerInput(filename);
                // if (nameValidated == true)
                // {



            }
        }
    }
}

