using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExamProject2015
{
    public partial class MainPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MainController c = new MainController();

                foreach (var item in c.GetDir(0))
                {
                    DropDownSchool.Items.Add(new ListItem(item.Name, item.ID.ToString()));
                }
                DropDownYear.Enabled = false;
            }
        }



        protected void DropDownSchool_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownYear.Enabled = true;
            int ParentID = int.Parse(DropDownSchool.SelectedValue);
            
            
            MainController   c = new MainController();
            DropDownYear.Items.Clear();
            foreach (var item in c.GetDir(ParentID))
            {
                DropDownYear.Items.Add(new ListItem(item.Name, item.ID.ToString()));
            }
            DropDownClass.Enabled = false;
            DropDownClass.ClearSelection();


        }

        protected void DropDownYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownClass.Enabled = true;
            int ParentID = int.Parse(DropDownYear.SelectedValue);
            

            MainController c = new MainController();
            DropDownClass.Items.Clear();
            foreach (var item in c.GetDir(ParentID))
            {
                DropDownClass.Items.Add(new ListItem(item.Name, item.ID.ToString()));
            }
            DropDownSubject.Enabled = false;
            

        }

        protected void DropDownClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownSubject.Enabled = true;
            int ParentID = int.Parse(DropDownClass.SelectedValue);
            

            MainController   c = new MainController();
            DropDownSubject.Items.Clear();
            foreach (var item in c.GetDir(ParentID))
            {
                DropDownSubject.Items.Add(new ListItem(item.Name, item.ID.ToString()));
            }
            DropDownSubjectFolder.Enabled = false;


        }

        protected void DropDownSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownSubjectFolder.Enabled = true;
            int ParentID = int.Parse(DropDownSubject.SelectedValue);
            DropDownSubjectFolder.Items.Clear();

            MainController c = new MainController();

            foreach (var item in c.GetDir(ParentID))
            {
                DropDownSubjectFolder.Items.Add(new ListItem(item.Name, item.ID.ToString()));
            }



        }

        protected void DropDownSubjectFolder_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}