using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Taxations.Models
{
    public static class SessionHandling
    {
        private static readonly TaxationDbContext db = new TaxationDbContext();
        public static bool CheckSession() => (HttpContext.Current.Session["UserId"] != null) ? true : false;

        public static string GetUserTypeFromSession() => HttpContext.Current.Session["UserType"] != null ? HttpContext.Current.Session["UserType"].ToString() : null;

        public static long GetUserIdFromSession() => HttpContext.Current.Session["UserId"] != null ? (long)HttpContext.Current.Session["UserId"] : 0;

        public static User GetUserById(long userId) => db.Users.FirstOrDefault(x => x.Id == userId);

        public static bool BI { get; set; }
        public static bool PTC { get; set; }
        public static bool PIS { get; set; }
        public static bool SE { get; set; }
        public static bool SA { get; set; }

        //public static string GetSignatureFromSession()
        //{
        //    var signature = HttpContext.Current.Session["Signature"].ToString();
        //    return (!string.IsNullOrEmpty(signature)) ? signature : "";
        //}

        public static bool CheckModelStatus(long userId)
        {
            return ((db.BasicInformations.FirstOrDefault(x => x.UserId == userId) != null)
                    && (db.BasicInformations.FirstOrDefault(x => x.UserId == userId) != null)
                    && (db.ParticularsOfIncomeFromSalaries.FirstOrDefault(x => x.UserId == userId) != null)
                    && (db.ParticularsOfTaxCredits.FirstOrDefault(x => x.UserId == userId) != null)
                    && (db.StatementOfExpense.FirstOrDefault(x => x.UserId == userId) != null)
                    && (db.StatementOfAssets.FirstOrDefault(x => x.UserId == userId) != null)) 
                    ? true 
                    : false;
        }


        public static void FormattedAssetYear() //FAY
        {
            long userId = GetUserIdFromSession();
            if(userId > 0)
            {
                var userInformation = db.UserInformations.FirstOrDefault(x => x.UserId == userId);
                if (userInformation != null)
                {
                    var splittedYear = userInformation.AssessmentYear.Split('-');
                    string year = splittedYear[0];
                    string yearLastTwoDigit = year.Substring(2, 2);

                    int yearLastTwoDigitPlusOne = Convert.ToInt32(yearLastTwoDigit) + 1;

                    HttpContext.Current.Session["FAY"] = splittedYear[0] + "-20" + yearLastTwoDigitPlusOne.ToString();
                }
            }
        }
    }
}