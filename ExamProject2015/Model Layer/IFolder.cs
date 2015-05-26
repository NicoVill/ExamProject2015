using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProject2015
{
    interface IFolder
    {
        int ID { get; set; }
        string Name { get; set; }

        int parentID { get; set; }

        List<IFile> folderFiles;
        List<ILink> folderLinks;

        public IUser CreatorOfFolder;

        string readData();
    }
}
