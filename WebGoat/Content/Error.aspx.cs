using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OWASP.WebGoat.NET.App_Code;

namespace OWASP.WebGoat.NET
{
    public partial class Error : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                try
                {
                    string filename = Path.GetFileName(FileUpload1.FileName);
                    string filepath = Server.MapPath("~/WebGoatCoins/uploads/") + filename;
                    FileUpload1.SaveAs(filepath);
                    FileValidator.ValidateFile(filepath);
                    long firstNum = 0;
                    long secondNum = 0;
                    using (StreamReader sr = new StreamReader(filepath))
                    {
                        firstNum = Int64.Parse(sr.ReadLine());
                        secondNum = Int64.Parse(sr.ReadLine());
                    }
                    long sum = firstNum + secondNum;
                    labelUpload.Text = "<div class='success' style='text-align:center'>The sum is " + sum + "</div>";
                    File.Delete(filepath);

                }
                catch (Exception ex)
                {
                    labelUpload.Text = "<div class='error' style='text-align:center'> (┛ಠ_ಠ)┛彡┻━┻ File processing failed: " + ex.Message + "</div>";
                }
                finally
                {
                    labelUpload.Visible = true;
                }
            }
        }
    }
}