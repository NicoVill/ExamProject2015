using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExamProject2015
{
    public partial class FrontPage : System.Web.UI.Page
    {
        MainController _cnt = new MainController();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_Login_Click(object sender, EventArgs e)
        {
            if (txtb_Username.Text.Count() > 0)
            {
                if (_cnt.Login(txtb_Username.Text, txtb_Password.Text) == true)
                {
                    Response.Write("<p> Session ID: " + Model_Layer.SessionData.SessionID);
                    Model_Layer.SessionData.usrName = txtb_Username.Text;

                    lbl_msg.Text = "Login Succesful";
                    Response.Redirect("MainPage.aspx");
                }
                else
                {
                    lbl_msg.Text = "Login Failed: " + _cnt.PrintMsg();
                }
            }
            else
            {
                lbl_msg.Text = "Skriv et username";
            }
            
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}