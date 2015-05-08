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
                Controller c = new Controller();

                foreach (var item in c.GetDir(0))
                {
                    DropDownSchool.Items.Add(new ListItem(item.Name, item.ID.ToString()));
                }
                DropDownList1.Enabled = false;
            }
        }



        protected void DropDownSchool_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList1.Enabled = true;
            int ParentID = int.Parse(DropDownSchool.SelectedValue);
            //DropDownList1.ClearSelection;

            Controller c = new Controller();

            foreach (var item in c.GetDir(ParentID))
            {
                DropDownList1.Items.Add(new ListItem(item.Name, item.ID.ToString()));
            }
            DropDownList2.Enabled = false;


        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList2.Enabled = true;
            int ParentID = int.Parse(DropDownList1.SelectedValue);
            //DropDownList1.ClearSelection;

            Controller c = new Controller();

            foreach (var item in c.GetDir(ParentID))
            {
                DropDownList2.Items.Add(new ListItem(item.Name, item.ID.ToString()));
            }
            DropDownList3.Enabled = false;


        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList3.Enabled = true;
            int ParentID = int.Parse(DropDownList2.SelectedValue);
            //DropDownList1.ClearSelection;

            Controller c = new Controller();

            foreach (var item in c.GetDir(ParentID))
            {
                DropDownList3.Items.Add(new ListItem(item.Name, item.ID.ToString()));
            }
            DropDownList4.Enabled = false;


        }

        protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList4.Enabled = true;
            int ParentID = int.Parse(DropDownList3.SelectedValue);
            //DropDownList1.ClearSelection;

            Controller c = new Controller();

            foreach (var item in c.GetDir(ParentID))
            {
                DropDownList4.Items.Add(new ListItem(item.Name, item.ID.ToString()));
            }



        }

        protected void DropDownList4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}