using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace ExamProject2015
{
    public partial class UploadPage : System.Web.UI.Page
    {
        MainController _cnt = new MainController();
        protected void Page_Load(object sender, EventArgs e)
        {
            ViewGrid();
        }

        protected void Upload(object sender, EventArgs e)
        {
            UploadFile();
        }

        private void UploadFile()
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
            string pathToCheck = c + Filename;
            string tempfileName = "";

            if (System.IO.File.Exists(c))
            {
                int counter = 2;

                while (System.IO.File.Exists(c))
                {
                    tempfileName = counter.ToString() + Filename;

                    pathToCheck = c + tempfileName;

                    counter++;
                }

                Filename = tempfileName;

                Label2.Text = "Der er allerede en fil med dette navn";
            }
            else
            {
                Label2.Text = "Filen blev uploaded";
            }

            c += Filename;
            string givingFilename = txtb_FileName.Text;
            FileUpload1.SaveAs(c);


            Stream fs = FileUpload1.PostedFile.InputStream;
            string FileContent = FileUpload1.PostedFile.ContentType;


            _cnt.UploadFile(Filename, c, fs, FileContent, givingFilename);
        }

        private void ViewGrid()
        {
            SqlConnection conn = null;
            SqlDataReader rdr = null;

            try
            {
                conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Database"].ConnectionString);
                conn.Open();
                SqlCommand cmd = new SqlCommand("ViewFiles", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                GridView.DataSource = cmd.ExecuteReader();
                GridView.DataBind();
            }
            catch (Exception ex)
            {
            
            Label1.Text += ex.Message;
        }
        finally
        {
            if (conn != null)
            {
                conn.Close();
            }
            if (rdr != null)
            {
                rdr.Close();
            }
        }
            
        }
        protected void GridView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void DownloadFile(object sender, EventArgs e)
        {
            int ID = int.Parse((sender as LinkButton).CommandArgument);

            Label1.Text = ID.ToString();

            _cnt.DownloadFile(ID);
        }
    }
}