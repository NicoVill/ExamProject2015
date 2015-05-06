using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace ExamProject2015
{
    public partial class UploadPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MainController _cnt = new MainController();



        }

        protected void Upload(object sender, EventArgs e)
        {

            string a = HttpRuntime.AppDomainAppPath;

            string[] b = a.Split('\\');

            string c = "";
            for (int i = 0; i < (b.Count() - 3); i++)
            {
                c += b[i] + "\\";
            }
            c += "tmp\\";

            Label1.Text = c;

            string Filename = FileUpload1.PostedFile.FileName;

            c += Filename;

            FileUpload1.SaveAs(c);







            //string filename, contentType;
            //Stream fs;
            //if (FileUpload1.PostedFile != null)
            //{
            //    contentType = FileUpload1.PostedFile.ContentType;
            //    filename = FileUpload1.PostedFile.FileName;
            //    fs = FileUpload1.PostedFile.InputStream;
            //}
        }
    }
}