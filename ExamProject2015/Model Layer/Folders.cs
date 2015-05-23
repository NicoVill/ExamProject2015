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


        public Folders(int ID, string Name)
        {
            this.ID = ID;
            this.Name = Name;
        }


        public string readData()
        {
            return "Name: " + Name + "ID: " + ID;
        }
    }
}