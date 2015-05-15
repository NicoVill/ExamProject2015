using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.IO;


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

        public void FileUploadMethod(string fn, string path, Stream fs, string fc, string gfn)
        {

            string givingFilename = gfn;
            string filename = fn;
            string contentType = fc;
            using (fs)
            {
                using (BinaryReader br = new BinaryReader(fs))
                {
                    byte[] bytes = br.ReadBytes((Int32)fs.Length);

                    using (SqlConnection con = new SqlConnection("server=ealdb1.eal.local;database=EJL86_DB;uid=ejl86_usr;password=Baz1nga86;"))
                    {

                        

                        SqlCommand cmd = new SqlCommand("UploadFile", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        {

                            cmd.Connection = con;

                            cmd.Parameters.AddWithValue("@GName", givingFilename);
                            cmd.Parameters.AddWithValue("@Name", filename);
                            cmd.Parameters.AddWithValue("@ContentType", contentType);
                            cmd.Parameters.AddWithValue("@Data", bytes);
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                    }
                }
            }
            //System.Web.HttpContext.Current.Response.Redirect(Request.Url.AbsoluteUri);
        }

        public void DownloadFileMethod(int id)
        {
            int ID = id;
            byte[] bytes;
            string fileName, contentType;

            using (
                SqlConnection con =
                    new SqlConnection("server=ealdb1.eal.local;database=EJL86_DB;uid=ejl86_usr;password=Baz1nga86;"))
            {
                SqlCommand cmd = new SqlCommand("DownloadFile", con);
                cmd.CommandType = CommandType.StoredProcedure;

            

                cmd.Parameters.AddWithValue("@ID", ID);
                cmd.Connection = con;
                con.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    sdr.Read();
                    bytes = (byte[])sdr["Data"];
                    contentType = sdr["ContentType"].ToString();
                    fileName = sdr["Name"].ToString();
                }
                con.Close();
            }
            
            System.Web.HttpContext.Current.Response.Clear();
            System.Web.HttpContext.Current.Response.Buffer = true;
            System.Web.HttpContext.Current.Response.Charset = "";
            System.Web.HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            System.Web.HttpContext.Current.Response.ContentType = contentType;
            System.Web.HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName);
            System.Web.HttpContext.Current.Response.BinaryWrite(bytes);
            System.Web.HttpContext.Current.Response.Flush();
            System.Web.HttpContext.Current.Response.End();
        }

        public SqlCommand ViewGrid (int ID)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Database"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("ViewFiles", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@ID", ID);

            return cmd;
        }



        public List<Model_Layer.Folders> GetDirDB(int ParentID = 0)
        {
            List<Model_Layer.Folders> FolderRead = new List<Model_Layer.Folders>();
            SqlConnection con =
                    new SqlConnection("server=ealdb1.eal.local;database=EJL86_DB;uid=ejl86_usr;password=Baz1nga86;");

            con.Open();
            SqlCommand cmd = new SqlCommand("GetDir", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@ParentID", ParentID));
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.HasRows && rdr.Read())
            {
                int ID = int.Parse(rdr["ID"].ToString());
                string Name = rdr["Name"].ToString();


                FolderRead.Add(new Model_Layer.Folders(ID, Name));
            }
            con.Close();
            con.Dispose();

            return FolderRead;
        }
    }
} 