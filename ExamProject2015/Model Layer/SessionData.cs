﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamProject2015.Model_Layer
{
    static public class SessionData
    {
        public static int LatestFolderID
        {
            get
            {
                if (System.Web.HttpContext.Current.Session["LatestFolderID"] != null)
                    return int.Parse(System.Web.HttpContext.Current.Session["LatestFolderID"].ToString());
                else
                    return -1;
            }
            set
            {
                System.Web.HttpContext.Current.Session["LatestFolderID"] = value;
            }
        }

        public static string SessionID { get { return HttpContext.Current.Session.SessionID.ToString().ToUpper(); } }

        public static DateTime TimeOfLogin { get; set; }

        public static string usrName
        {
            get
            {
                if (System.Web.HttpContext.Current.Session["usrName"] != null)
                    return (System.Web.HttpContext.Current.Session["usrName"].ToString());
                else
                    return "No Username";
            }
            set
            {
                System.Web.HttpContext.Current.Session["usrName"] = value;
            }
        }

        public static int privLevel
        {
            get
            {
                if (System.Web.HttpContext.Current.Session["privLevel"] != null)
                    return int.Parse((System.Web.HttpContext.Current.Session["privLevel"].ToString()));
                else
                    return -1;
            }
            set
            {
                System.Web.HttpContext.Current.Session["PrivLevel"] = value;
            }
        }

        public static int SessionUserID
        {
            get
            {
                if (System.Web.HttpContext.Current.Session["SessionUserID"] != null)
                    return int.Parse((System.Web.HttpContext.Current.Session["SessionUserID"].ToString()));
                else
                    return -1;
            }
            set
            {
                System.Web.HttpContext.Current.Session["SessionUserID"] = value;
            }
        }

        public static string getPrivLevel ()
        {
            if (privLevel == 1)
                return "Lærer";
            else if (privLevel == 2)
                return "Admin";
            else if (privLevel == 3)
                return "Elev";

            return "Invalid Privilege Level";
        }

        public static string printData ()
        {
            return "User: " + usrName + " | " + getPrivLevel();
        }
    }
}