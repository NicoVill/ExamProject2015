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
                errormsg = "No Connection to server:  " + ConfigurationManager.ConnectionStrings["Database"].ConnectionString.ToString() + "\n ex:  " + ex.ToString();
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
                object privLevel = cmd.Parameters["@PrivLevel"].Value;

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
                errormsg = "Forkert brugernavn eller password "  + ex.ToString();
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

        public void FileUploadMethod(string fn, string path, Stream fs, string fc, string gfn, int id)
        {

            string givingFilename = gfn;
            string filename = fn;
            string contentType = fc;
            int FolderID = id;
            using (fs)
            {
                using (BinaryReader br = new BinaryReader(fs))
                {
                    byte[] bytes = br.ReadBytes((Int32)fs.Length);

                    using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Database"].ConnectionString))
                    {

                        

                        SqlCommand cmd = new SqlCommand("UploadFile", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        {

                            cmd.Connection = con;

                            cmd.Parameters.AddWithValue("@GName", givingFilename);
                            cmd.Parameters.AddWithValue("@Name", filename);
                            cmd.Parameters.AddWithValue("@ContentType", contentType);
                            cmd.Parameters.AddWithValue("@Data", bytes);
                            cmd.Parameters.AddWithValue("@ID", id);
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
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Database"].ConnectionString))
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
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Database"].ConnectionString);

            con.Open();
            SqlCommand cmd = new SqlCommand("db_owner.GetDir", con);
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

        public void CreateFolderDB(string Name, int ParentID)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Database"].ConnectionString);

            con.Open();
            SqlCommand cmd = new SqlCommand("db_owner.CreateFolder", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Name", Name));
            cmd.Parameters.Add(new SqlParameter("@ParentID", ParentID));
            cmd.ExecuteNonQuery();

            con.Close();
            con.Dispose();
        }

        public void RenameFolderDB(string Name, int ID)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Database"].ConnectionString);

            con.Open();
            SqlCommand cmd = new SqlCommand("db_owner.RenameFolder", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Name", Name));
            cmd.Parameters.Add(new SqlParameter("@ID", ID));
            cmd.ExecuteNonQuery();

            con.Close();
            con.Dispose();
        }

        public void DeleteFolderDB(int ID)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Database"].ConnectionString);

            con.Open();
            SqlCommand cmd = new SqlCommand("db_owner.DeleteFolder", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@ID", ID));

            int ErrorMessage = cmd.ExecuteNonQuery();

            con.Close();
            con.Dispose();
         }
        

        public void UploadLinkDB(string Name, string Url)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Database"].ConnectionString);

            con.Open();
            SqlCommand cmd = new SqlCommand("db_owner.UploadLink", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Name", Name));
            cmd.Parameters.Add(new SqlParameter("@Url", Url));
            cmd.ExecuteNonQuery();

            con.Close();
            con.Dispose();
        }
    }
} 