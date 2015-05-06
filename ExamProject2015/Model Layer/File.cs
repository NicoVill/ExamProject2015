using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ExamProject2015
{
    public class File
    {
        public void FileUploadMethod()
        {


            string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
            string contentType = FileUpload1.PostedFile.ContentType;
            using (Stream fs = FileUpload1.PostedFile.InputStream)
            {
                using (BinaryReader br = new BinaryReader(fs))
                {
                    byte[] bytes = br.ReadBytes((Int32)fs.Length);

                    using (SqlConnection con = new SqlConnection("server=ealdb1.eal.local;database=EJL86_DB;uid=ejl86_usr;password=Baz1nga86;"))
                    {
                        //string query = "insert into FileUploadTest values (@Name, @ContentType, @Data)";
                        //using (SqlCommand cmd = new SqlCommand(query))
                        string query = "if not exists (select * from FileUploadTest Where Name = @Name)";

                        SqlCommand cmd = new SqlCommand("UploadFile", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        {

                            cmd.Connection = con;

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
            System.Web.HttpContext.Current.Response.Redirect(Request.Url.AbsoluteUri);
        }

        public void DownloadFileMethod()
        {
            int ID = int.Parse((sender as LinkButton).CommandArgument);
            byte[] bytes;
            string fileName, contentType;

            using (
                SqlConnection con =
                    new SqlConnection("server=ealdb1.eal.local;database=EJL86_DB;uid=ejl86_usr;password=Baz1nga86;"))
            //{
            //    using (SqlCommand cmd = new SqlCommand())
            {
                SqlCommand cmd = new SqlCommand("AddNewOffer", con);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.CommandText = "select Name, Data, ContentType from FileUploadTest where ID=@ID";
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
            //}
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
    }
}