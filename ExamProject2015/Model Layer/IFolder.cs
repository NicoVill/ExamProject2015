using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProject2015
{
    public interface IFolder
    {
        int ID { get; set; }
        string Name { get; set; }

        int parentID { get; set; }

        List<IFile> folderFiles{ get; set; }
        List<ILink> folderLinks { get; set; }

        IUser CreatorOfFolder { get; set; }

        string readData();
    }
}
