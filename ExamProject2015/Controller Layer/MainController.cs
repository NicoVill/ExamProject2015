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
            if (_dbf.LogIn(usn, pass) == true)
            {
                Model_Layer.User usr = new Model_Layer.User(usn, _dbf.PrivLevel);
                Model_Layer.SessionData.privLevel = _dbf.PrivLevel;

                return _dbf.LogIn(usn, pass);
                
            }
            else
            {
                return false;

            }
        }

        public string getSessionData()
        {
            return Model_Layer.SessionData.printData();
        }

        public int checkPrivLevel()
        {
            return Model_Layer.SessionData.privLevel;
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

        public void CreateFolder(string Name, int ParentID)
        {           
            _dbf.CreateFolderDB(Name, ParentID);
        }

        public int getLastFolderID()
        {
            return Model_Layer.SessionData.LatestFolderID;
        }

        public void RenameFolder(string Name, int ID)
        {
            
            _dbf.RenameFolderDB(Name, ID);
        }

        public void DeleteFolder(int ID)
        {
            
            _dbf.DeleteFolderDB(ID);
        }

        public void UploadLink(string Name, string Url)
        {          
            _dbf.UploadLinkDB(Name, Url);
        }
    }
}