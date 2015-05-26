using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProject2015
{
    interface IFile
    {
         string name { get; set; }
         DateTime dateOfCreation { get; set; }
         string fileType { get; set; }

         public string userID { get; set; }

         int parentID { get; set; }

         IFolder locationFolder;
        string readData();

    }
}
