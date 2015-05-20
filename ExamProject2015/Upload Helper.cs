using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace ExamProject2015
{
    public static class UploadHelper
    {
        public static string createUploadLocationString (string l)
        {
            string newLocationString = "";

            string[] b = l.Split('\\');
            string c = "";
            for (int i = 0; i < (b.Count() - 3); i++)
            {
                c += b[i] + "\\";
            }

            c += "tmp\\";

            newLocationString = c;

            return newLocationString;
        }

        public static bool checkIfFIleExists(string uploadLocation, string Filename)
        {
            string tempfileName = "";
            string pathToCheck = uploadLocation + Filename;

            if (System.IO.File.Exists(uploadLocation))
            {
                int counter = 2;

                while (System.IO.File.Exists(uploadLocation))
                {
                    tempfileName = counter.ToString() + Filename;

                    pathToCheck = uploadLocation + tempfileName;

                    counter++;
                }

                Filename = tempfileName;

                return false;
            }
            else
            {
                return true;
            }

        }

        public static string calcSize(int location)
        {
            int size = location / 1024;

            return size.ToString();
        
        }
    }

    
}