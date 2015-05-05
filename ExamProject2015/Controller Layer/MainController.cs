using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace ExamProject2015
{
    public class MainController
    {
        DatabaseFacade _dbf = new DatabaseFacade();

        public bool Login (string usn, string pass)
        {
            
            return _dbf.LogIn(usn, pass);
        }

        public string PrintMsg()
        {
            return _dbf.PrintErrorMsg();
        }
    }
}