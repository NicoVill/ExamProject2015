using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProject2015
{
    interface IFile
    {
        public string name { get; set; }
        public DateTime dateOfCreation { get; set; }
        public string fileType { get; set; }

        string readData();

    }
}
