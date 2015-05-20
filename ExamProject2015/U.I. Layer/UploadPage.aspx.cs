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
            //ViewGrid();
            Response.Write(Model_Layer.SessionData.LatestFolderID);
        }

        protected void Upload(object sender, EventArgs e)
        {
            UploadFile();
        }

        private void UploadFile()
        {
            string a = HttpRuntime.AppDomainAppPath;
            
            string uploadLocation = UploadHelper.createUploadLocationString(a);
            string Filename = FileUpload1.PostedFile.FileName;
            string pathToCheck = uploadLocation + Filename;
            

            UploadHelper.checkIfFIleExists(uploadLocation, Filename);

            if (UploadHelper.checkIfFIleExists(uploadLocation, Filename) == false)
            {               
                Label2.Text = "Der er allerede en fil med dette navn";
            }
            else
            {
                Label2.Text = "Filen blev uploaded";
            }

            uploadLocation += Filename;
            string givingFilename = txtb_FileName.Text;
            FileUpload1.SaveAs(uploadLocation);


            Stream fs = FileUpload1.PostedFile.InputStream;
            string FileContent = FileUpload1.PostedFile.ContentType;

            Label2.Text = UploadHelper.calcSize(FileUpload1.PostedFile.ContentLength);

            _cnt.UploadFile(Filename, uploadLocation, fs, FileContent, givingFilename, Model_Layer.SessionData.LatestFolderID);
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