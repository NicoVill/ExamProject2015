using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

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

        public void UploadFile(string fn, string path, Stream fs, string fc)
        {
            File _file = new File(fn, fc);

            _dbf.FileUploadMethod(fn, path, fs, fc);

           if (System.IO.File.Exists(@path))
            {
                System.IO.File.Delete(@path);
            }


        }

        public void DownloadFile(int id)
        {
            _dbf.DownloadFileMethod(id);
        }

    }
}