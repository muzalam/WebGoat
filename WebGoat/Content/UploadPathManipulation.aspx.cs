using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace OWASP.WebGoat.NET
{
    public partial class UploadPathManipulation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
       /* public bool validateUerInput(String name)
        {
            var positiveRegex = new System.Text.RegularExpressions.Regex(@"^(([a-zA-Z]:)|(\\{2}\w+)\$?)(\\(\w[\w].*))(.txt|.TXT|.xls|.XLS|.pdf)$");
            if (!positiveRegex.IsMatch(name))
            {
                return false;
            }
            else
            {
                return true;
            }
        }*/
            protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)

            {
                string filename = Path.GetFileName(FileUpload1.FileName);
                string Extension = Path.GetExtension(FileUpload1.FileName);
                if (Extension == ".xls" || Extension == ".pdf" || Extension == ".txt")
                {
                    //bool nameValidated = validateUerInput(filename);
                    // if (nameValidated == true)
                    // {


                    try
                    {


                        FileUpload1.SaveAs(Server.MapPath("~/WebGoatCoins/uploads/") + filename);
                        labelUpload.Text = "<div class='success' style='text-align:center'>The file " + FileUpload1.FileName + " has been saved in to the WebGoatCoins/uploads directory</div>";


                    }
                    catch (Exception ex)
                    {
                        labelUpload.Text = "<div class='error' style='text-align:center'>Upload Failed: " + ex.Message + "</div>";
                    }
                    finally
                    {
                        labelUpload.Visible = true;
                    }
                }
               
                else
                {
                    labelUpload.Text = "<div class='error' style='text-align:center'>Upload Failed: </div>";
                }
               
            }
        }
    }
}