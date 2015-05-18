using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Data.SqlClient;
using System.Data;


namespace ExamProject2015
{
    public class MainController
    {
        DatabaseFacade _dbf = new DatabaseFacade();
        
        

        public bool Login (string usn, string pass)
        {
            
            return _dbf.LogIn(usn, pass);
        }

        public string PrintMsg()
        {
            return _dbf.PrintErrorMsg();
        }

        public void UploadFile(string fn, string path, Stream fs, string fc, string gfn, int id)
        {
            File _file = new File(fn, fc);

            _dbf.FileUploadMethod(fn, path, fs, fc, gfn, id);

           if (System.IO.File.Exists(@path))
            {
                System.IO.File.Delete(@path);
            }


        }

        public void DownloadFile(int id)
        {
            _dbf.DownloadFileMethod(id);
        }

        public SqlCommand ViewGrid(int ID)
        {
           return _dbf.ViewGrid(ID);
        }

        public List<Model_Layer.Folders> GetDir(int ParentID = 0)
        {
            DatabaseFacade db = new DatabaseFacade();


            return db.GetDirDB(ParentID);



        }

    }
}