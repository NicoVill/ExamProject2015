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
                IUser usr = new Model_Layer.User(usn, _dbf.PrivLevel);
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

        public string UploadFile(string fn, string path, Stream fs, string fc, string gfn, int id)
        {
            IFile _file = new File(fn, fc);
            
            string msg = _dbf.FileUploadMethod(fn, path, fs, fc, gfn, id);

           if (System.IO.File.Exists(@path))
            {
                System.IO.File.Delete(@path);
            }

           return msg;

        }

        public void DownloadFile(int id)
        {
            _dbf.DownloadFileMethod(id);
        }

        public SqlCommand ViewGrid(int ID)
        {
           return _dbf.ViewGrid(ID);
        }

        public SqlCommand ViewGridLinks(int ID)
        {
            return _dbf.ViewGridLinks(ID);
        }

        public List<Model_Layer.Folders> GetDir(int ParentID = 0)
        {
            DatabaseFacade db = new DatabaseFacade();


            return db.GetDirDB(ParentID);
        }

        public List<Model_Layer.Folders> GetSubDir(int ParentID = 0)
        {
            List<Model_Layer.Folders> ReturnList = new List<Model_Layer.Folders>();
            DatabaseFacade db = new DatabaseFacade();

            foreach (var item in db.GetDirDB(ParentID))
            {
                ReturnList.Add(item);
                foreach (var temp in GetSubDir(item.ID))
                {
                    ReturnList.Add(new Model_Layer.Folders(temp.ID, "-> " + temp.Name));
                }

            }
            return ReturnList;
        }

        public string CreateFolder(string Name, int ParentID)
        {           
            return _dbf.CreateFolderDB(Name, ParentID);
        }

        public int getLastFolderID()
        {
            return Model_Layer.SessionData.LatestFolderID;
        }

        public string RenameFolder(string Name, int ID)
        {
            
            return _dbf.RenameFolderDB(Name, ID);
        }

        public void DeleteFolder(int ID)
        {
            _dbf.DeleteFolderDB(ID);
        }

        public string UploadLink(string Name, string Url)
        {          
            return _dbf.UploadLinkDB(Name, Url);
        }
    }
}