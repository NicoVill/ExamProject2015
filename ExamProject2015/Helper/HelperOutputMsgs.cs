using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamProject2015
{
    public static class HelperOutputMsgs
    {
        public static string printMessage(int nr)
        {
            switch (nr)
            {
                case -1:
                    return "Navnet er allerede brugt";
                    

                case 1:
                    return "Filen er oploaded";
                    

                case 2:
                    return "Mappen er oprettet";
            }

            return "Fejl i Message Helper";
        }
    }
}