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
            Response.Write("<p> Session ID: " + Model_Layer.SessionData.SessionID);
            //Response.Write("<p> Folder ID: " + Model_Layer.SessionData.LatestFolderID);
            Model_Layer.SessionData.LatestFolderID = 0;
            Response.Write(Model_Layer.SessionData.usrName);
            //Response.Write("<p> Folder ID: " + Model_Layer.SessionData.LatestFolderID);
            if (!IsPostBack)
            {
                MainController c = new MainController();

                foreach (var item in c.GetDir(0))
                {
                    DropDownSchool.Items.Add(new ListItem(item.Name, item.ID.ToString()));
                }
                DropDownYear.Enabled = false;

                

            }

            //int ParentID;
        }


        protected void DropDownSchool_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownYear.Enabled = true;
            int ParentID = int.Parse(DropDownSchool.SelectedValue);
            DropDownSchool.Items.Add(new ListItem("Choose School", null ));
            
            MainController   c = new MainController();
            DropDownYear.Items.Clear();
            foreach (var item in c.GetDir(ParentID))
            {
                DropDownYear.Items.Add(new ListItem(item.Name, item.ID.ToString()));

                ViewGrid(item.ID);
                Model_Layer.SessionData.LatestFolderID = item.ID;
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

            DropDownSchool.Items.Add(new ListItem("Vælg Årgang", null));

            MainController c = new MainController();
            DropDownClass.Items.Clear();
            foreach (var item in c.GetDir(ParentID))
            {
                DropDownClass.Items.Add(new ListItem(item.Name, item.ID.ToString()));

                ViewGrid(item.ID);
                Model_Layer.SessionData.LatestFolderID = item.ID;
                Label1.Text = item.ID.ToString();
            }
            DropDownSubject.Enabled = false;

            Label2.Text = ParentID.ToString();
        }

        protected void DropDownClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownSubject.Enabled = true;
            int ParentID = int.Parse(DropDownClass.SelectedValue);
            DropDownSchool.Items.Add(new ListItem("Vælg Klasse", null));

            MainController   c = new MainController();
            DropDownSubject.Items.Clear();
            foreach (var item in c.GetDir(ParentID))
            {
                DropDownSubject.Items.Add(new ListItem(item.Name, item.ID.ToString()));
                Model_Layer.SessionData.LatestFolderID = item.ID;
                ViewGrid(item.ID);

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

            DropDownSchool.Items.Add(new ListItem("Vælg Fag", null));

            MainController c = new MainController();

            foreach (var item in c.GetDir(ParentID))
            {
                DropDownSubjectFolder.Items.Add(new ListItem(item.Name, item.ID.ToString()));
                Model_Layer.SessionData.LatestFolderID = item.ID;
                ViewGrid(item.ID);

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

        
    }
}