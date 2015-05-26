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
    public class File : IFile
    {
        public string name { get; set; }
        public DateTime dateOfCreation { get; set; }

        public string fileType { get; set; }

        public File (string n, string ftype)
        {
            this.name = n;
            this.fileType = ftype;

            dateOfCreation = new DateTime();
            dateOfCreation = DateTime.Today;
        }

        public string readData()
        {
            return "Fil Navn: " + name + "Oprettelse Dato" + dateOfCreation.ToString() + "Fil type" + fileType;
        }


        public string userID
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public int parentID
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        //public IFolder locationFolderFile
        //{
        //    get
        //    {
        //        throw new NotImplementedException();
        //    }
        //    set
        //    {
        //        throw new NotImplementedException();
        //    }
        //}


        public IFolder locationFolderFile
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}