using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace ExamProject2015
{
    public partial class MainPage : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            MainController _cnt = new MainController();

            Response.Write("<p>" + _cnt.getSessionData());

            if (!IsPostBack)
            {
                Model_Layer.SessionData.LatestFolderID = 0;
                DropDownSchool.Items.Add(new ListItem("Vælg Skole", null));
                MainController c = new MainController();

                foreach (var item in c.GetDir(0))
                {
                    DropDownSchool.Items.Add(new ListItem(item.Name, item.ID.ToString()));
                }
                DropDownYear.Enabled = false;             
            }
            
            if (_cnt.checkPrivLevel() == 3)
            {
                btn_upload.Enabled = false;
            }
            
        }


        protected void DropDownSchool_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ParentID = int.Parse(DropDownSchool.SelectedValue);
            
            DropDownYear.Enabled = true;
            
            MainController   c = new MainController();
            DropDownYear.Items.Clear();
            DropDownYear.Items.Add(new ListItem("Vælg Årgang", ParentID.ToString()));

            ViewGrid(ParentID);
            Model_Layer.SessionData.LatestFolderID = ParentID;


            foreach (var item in c.GetDir(ParentID))
            {
                DropDownYear.Items.Add(new ListItem(item.Name, item.ID.ToString()));

                
                Label1.Text = item.ID.ToString();
            }
            DropDownClass.Enabled = false;
            DropDownClass.ClearSelection();

            Label2.Text = ParentID.ToString();
        }

        protected void DropDownYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownClass.Enabled = true;
            int ParentID = int.Parse(DropDownYear.SelectedValue);

            

            MainController c = new MainController();
            DropDownClass.Items.Clear();
            DropDownClass.Items.Add(new ListItem("Vælg Klasse", ParentID.ToString()));

            ViewGrid(ParentID);
            Model_Layer.SessionData.LatestFolderID = ParentID;

            foreach (var item in c.GetDir(ParentID))
            {
                DropDownClass.Items.Add(new ListItem(item.Name, item.ID.ToString()));

                
                Label1.Text = item.ID.ToString();
            }
            DropDownSubject.Enabled = false;

            Label2.Text = ParentID.ToString();
        }

        protected void DropDownClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownSubject.Enabled = true;
            int ParentID = int.Parse(DropDownClass.SelectedValue);
            

            MainController   c = new MainController();
            DropDownSubject.Items.Clear();
            DropDownSubject.Items.Add(new ListItem("Vælg Fag", ParentID.ToString()));

            ViewGrid(ParentID);
            Model_Layer.SessionData.LatestFolderID = ParentID;

            foreach (var item in c.GetDir(ParentID))
            {
                DropDownSubject.Items.Add(new ListItem(item.Name, item.ID.ToString()));
                

                Label1.Text = item.ID.ToString();
            }
            DropDownSubjectFolder.Enabled = false;

            Label2.Text = ParentID.ToString();
        }

        protected void DropDownSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownSubjectFolder.Enabled = true;
            int ParentID = int.Parse(DropDownSubject.SelectedValue);
            DropDownSubjectFolder.Items.Clear();

            DropDownSubjectFolder.Items.Add(new ListItem("Vælg Mappe", ParentID.ToString()));

            MainController c = new MainController();

            ViewGrid(ParentID);
            Model_Layer.SessionData.LatestFolderID = ParentID;

            foreach (var item in c.GetDir(ParentID))
            {
                DropDownSubjectFolder.Items.Add(new ListItem(item.Name, item.ID.ToString()));
                

                Label1.Text = item.ID.ToString();
            }

            

            Label2.Text = ParentID.ToString();

        }

        protected void DownloadFile(object sender, EventArgs e)
        {
            MainController _cnt = new MainController();
            int ID = int.Parse((sender as LinkButton).CommandArgument);



            Label1.Text = ID.ToString();

            _cnt.DownloadFile(ID);
        }

        protected void DropDownSubjectFolder_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownSchool.Items.Add(new ListItem("Vælg Mappe", null));
            //Model_Layer.SessionData.LatestFolderID = item.ID;
        }

        private void ViewGrid(int ID)
        {
            SqlConnection conn = null;
            SqlDataReader rdr = null;
            MainController _cnt = new MainController();
            try
            {

                GridView.DataSource = _cnt.ViewGrid(ID).ExecuteReader();
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Label1.Text = Model_Layer.Folders.getID().ToString();

            
        }

        protected void GridView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btn_upload_Click(object sender, EventArgs e)
        {
            Response.Redirect("UploadPage.aspx");
        }

        

        protected void btn_CreateFolder_Click(object sender, EventArgs e)
        {
            MainController c = new MainController();
            c.CreateFolder(txtb_FolderName.Text, c.getLastFolderID());
        }

        protected void RenameFolderBtn_Click(object sender, EventArgs e)
        {
            MainController c = new MainController();
            c.RenameFolder(RenameFolderTxt.Text, c.getLastFolderID());
        }
    }
}