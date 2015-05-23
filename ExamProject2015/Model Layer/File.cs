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
        string name { get; set; }
        DateTime dateOfCreation { get; set; }

        string fileType { get; set; }

        public File (string n, string ftype)
        {
            this.name = n;
            this.fileType = ftype;

            dateOfCreation = new DateTime();
            dateOfCreation = DateTime.Today;
        }
    }
}