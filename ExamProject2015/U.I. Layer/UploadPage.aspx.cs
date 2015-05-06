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
            if (FileUpload1.PostedFile != null)
            {
                Label1.Text = FileUpload1.PostedFile.FileName;
                Label2.Text = FileUpload1.FileName;
            }
        }
    }
}