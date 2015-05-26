using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamProject2015.Model_Layer
{
    public class User : IUser
    {
        public string userName { get; set; }

        public int privLevel { get; set; }

        public User (string userName, int privL)
        {
            this.userName = userName;
        }


        public string readData()
        {
            return "Username: " + userName + " | " + SessionData.getPrivLevel();
        }


        public DateTime birthday
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string Email
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string name
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }


        public Login connectionLogin
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}