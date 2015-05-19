using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamProject2015.Model_Layer
{
    public class User
    {
        public string userName { get; set; }

        public int privLevel { get; set; }

        public User (string userName, int privL)
        {
            this.userName = userName;
        }
    }
}