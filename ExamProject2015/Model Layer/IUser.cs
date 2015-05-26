using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProject2015
{
    interface IUser
    {
        string userName { get; set; }

        int privLevel { get; set; }

        DateTime birthday { get; set; }

        string Email { get; set; }

        string name { get; set; }
        string readData();

        Login connectionLogin;
    }
}
