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

            DropDownYear.Items.Clear();
            DropDownYear.Enabled = true;
            
            MainController   c = new MainController();
            
            DropDownYear.Items.Add(new ListItem("Vælg Årgang", ParentID.ToString()));

            ViewGrid(ParentID);
            Model_Layer.SessionData.LatestFolderID = ParentID;


            foreach (var item in c.GetDir(ParentID))
            {
                DropDownYear.Items.Add(new ListItem(item.Name, item.ID.ToString()));

                
                //Label1.Text = item.ID.ToString();
            }
            DropDownClass.Enabled = false;
            DropDownClass.ClearSelection();

           // Label2.Text = ParentID.ToString();
        }

        protected void DropDownYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownClass.Items.Clear();
            DropDownClass.Enabled = true;
            int ParentID = int.Parse(DropDownYear.SelectedValue);

            

            MainController c = new MainController();
            
            DropDownClass.Items.Add(new ListItem("Vælg Klasse", ParentID.ToString()));

            ViewGrid(ParentID);
            Model_Layer.SessionData.LatestFolderID = ParentID;

            foreach (var item in c.GetDir(ParentID))
            {
                DropDownClass.Items.Add(new ListItem(item.Name, item.ID.ToString()));

                
                //Label1.Text = item.ID.ToString();
            }
            DropDownSubject.Enabled = false;

            //Label2.Text = ParentID.ToString();
        }

        protected void DropDownClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownSubject.Items.Clear();
            DropDownSubject.Enabled = true;
            int ParentID = int.Parse(DropDownClass.SelectedValue);
            

            MainController   c = new MainController();
            
            DropDownSubject.Items.Add(new ListItem("Vælg Fag", ParentID.ToString()));

            ViewGrid(ParentID);
            Model_Layer.SessionData.LatestFolderID = ParentID;

            foreach (var item in c.GetDir(ParentID))
            {
                DropDownSubject.Items.Add(new ListItem(item.Name, item.ID.ToString()));
                

                //Label1.Text = item.ID.ToString();
            }
            DropDownSubjectFolder.Enabled = false;

            //Label2.Text = ParentID.ToString();
        }

        protected void DropDownSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownSubjectFolder.Items.Clear(); 
            DropDownSubjectFolder.Enabled = true;
            int ParentID = int.Parse(DropDownSubject.SelectedValue);
                     

            MainController c = new MainController();

            DropDownSubjectFolder.Items.Add(new ListItem("Vælg Mappe", int.Parse(DropDownSubject.SelectedValue).ToString()));

            foreach (var item in c.GetSubDir(ParentID))
            {
                DropDownSubjectFolder.Items.Add(new ListItem(item.Name, item.ID.ToString()));
                //Label1.Text = item.ID.ToString(); 
            }

            ViewGrid(ParentID);
            Model_Layer.SessionData.LatestFolderID = ParentID;

            //Label2.Text = ParentID.ToString();

        }

        protected void DropDownSubjectFolder_SelectedIndexChanged(object sender, EventArgs e)
        {
            //DropDownSchool.Items.Add(new ListItem("Vælg Mappe", null));
            //Model_Layer.SessionData.LatestFolderID = item.ID;
        }

        protected void DownloadFile(object sender, EventArgs e)
        {
            MainController _cnt = new MainController();
            int ID = int.Parse((sender as LinkButton).CommandArgument);



            //Label1.Text = ID.ToString();

            _cnt.DownloadFile(ID);
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

               label_Grid.Text += ex.Message;
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
            if (txtb_FolderName.Text.Count() > 0)
            {
                MainController c = new MainController();
                c.CreateFolder(txtb_FolderName.Text, c.getLastFolderID());
            }
            else
            {
                label_CreateFolder.Text = "Skriv et navn";
            }
        }

        protected void btn_RenameFolder_Click(object sender, EventArgs e)
        {
            if (RenameFolderTxt.Text.Count() > 0)
            {
                MainController c = new MainController();
                c.RenameFolder(RenameFolderTxt.Text, c.getLastFolderID());
            }
            else
            {
                label_RenameFolder.Text = "Skriv et navn";
            }

            
        }

        protected void btn_Delete_Click(object sender, EventArgs e)
        {
            MainController c = new MainController();
            c.DeleteFolder(c.getLastFolderID());
        }

        
    }
}