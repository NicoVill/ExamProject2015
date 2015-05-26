using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamProject2015
{
    public class Login
    {
        public string userName { get; set; }

        public string password { get; set; }

        public IUser connectionUser;
    }
}