using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamProject2015.Model_Layer
{
    public class Folders : IFolder
    {
        public int ID { get; set; }
        public string Name { get; set; }

        List<IFile> folderFiles;
        List<ILink> folderLinks;

        public User CreatorOfFolder;

        public Folders(int ID, string Name, string username)
        {
            folderFiles = new List<IFile>();
            folderLinks = new List<ILink>();
            CreatorOfFolder.userName = username;
            this.ID = ID;
            this.Name = Name;
        }


        public string readData()
        {
            return "Name: " + Name + "ID: " + ID;
        }
    }
}