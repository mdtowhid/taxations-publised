using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Taxations.BusinessLogic
{
    public class CustomFormatter
    {
        public static string DateDDMMYYFormatter(string date)
        {
            if (!ValidateDateString(date))
                return date;

            string[] dateArray = date.Trim().Split('-');

            return dateArray[2] + "-" + dateArray[1] + "-" + dateArray[0];
        }


        public static string DateFormatterForForm(string date, char splitChar, char appendChar)
        {
            if (!ValidateDateString(date))
                return date;

            string[] dateArray = date.Trim().Split(splitChar);

            return dateArray[2] + appendChar + dateArray[1] + appendChar + dateArray[0];
        }

        public static string DateCurrentYearWithNextYearTwoDigitFormatter(string date)
        {
            if (!ValidateDateString(date))
                return date;

            string[] dateArray = date.Trim().Split('-');
            string a = dateArray[2];
            int b = 0;

            if (a.Length == 4)
            {
                b = Convert.ToInt32(a.Substring(1, 3)) + 1;
                return dateArray[2] + "-" + b.ToString();//currentYear+1
            }
            return date;
        }


        private static bool ValidateDateString(string date)
        {
            if (date == null)
                return false;

            string[] dateArray = date.Trim().Split('-');

            if (dateArray.Length > 3 || dateArray.Length < 3)
                return false;
            return true;
        }

        public static string StringTrimmerOnStringArrayFormatter(string str, char splitChar)
        {
            if (str == null)
                return str;

            string[] a = str.Split(splitChar);
            string res = "";

            if (a.Length > 0)
            {
                foreach (string s in a)
                {
                    if (s == "")
                        continue;

                    string r = s;
                    res += r.Trim() + ",";
                }
            }

            return res.Length > 0 ? res : str;
        }


        public static string[] StringArrayBasedOnSplitCharFormatter(string str, char splitChar)
        {
            if (str == null)
                return new string[] { };
            str = StringTrimmerOnStringArrayFormatter(str, splitChar);

            string[] a = str.Split(splitChar);

            return a.Length > 0 ? a : new string[] { };
        }

        //public static T CommaSeprator(T t)
        //{
        //    return t;
        //}
    }
}