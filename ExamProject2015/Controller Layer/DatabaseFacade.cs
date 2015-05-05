using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace ExamProject2015
{
    public class DatabaseFacade
    {
        public string username { get; set; }
        public string password { get; set; }

        public int PrivLevel { get; set; }

        public bool auth = false;
        private string errormsg;
        public bool LogIn(string user, string pass)
        {
            bool Authenticate = false;

            SqlConnection conn = null;
            SqlDataReader rdr = null;


            try
            {

                conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Database"].ConnectionString);
                conn.Open();
            }
            catch (Exception ex)
            {
                errormsg = "No Connection to server";
                return false;
            }

            try
            {
                SqlCommand cmd = new SqlCommand("AuthenticateLogin", conn);
                cmd.CommandType = CommandType.StoredProcedure;


                SqlParameter paramUserName = new SqlParameter("@Username", user);
                paramUserName.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(paramUserName);

                SqlParameter paramPassword = new SqlParameter("@Password", pass);
                paramPassword.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(paramPassword);

                SqlParameter paramAuthenticate = new SqlParameter("@Authenticated", false);
                paramAuthenticate.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(paramAuthenticate);

                SqlParameter paramRole = new SqlParameter("@PrivLevel", 0);
                paramRole.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(paramRole);
                object test = cmd.Parameters["@PrivLevel"].Value;

                //cmd.Parameters["@Authenticate"].Value = Authenticate;

                cmd.ExecuteNonQuery();

                int Auth = Convert.ToInt32(cmd.Parameters["@Authenticated"].Value);
                if (Auth == 0)
                    Authenticate = false;
                else
                    Authenticate = true;

                PrivLevel = Convert.ToInt32(cmd.Parameters["@PrivLevel"].Value);
            }
            catch (Exception ex)
            {
                errormsg = "Forkert brugernavn eller password";
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

            return Authenticate;
        }

        public string PrintErrorMsg()
        {
            return errormsg;
        }
    }
}