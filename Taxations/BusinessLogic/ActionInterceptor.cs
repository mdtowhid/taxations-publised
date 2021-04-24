using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Http.Filters;
using System.Web.Mvc;
using Taxations.Models;
using TeamCode.BusinessLogicLayer;

namespace Taxations.BusinessLogic
{
    public class ActionInterceptor : System.Web.Mvc.ActionFilterAttribute
    {
        private readonly TaxationDbContext db = new TaxationDbContext();

        long userId = 0;
        bool isLoggedIn = false;

        

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //Thread.Sleep(1000);
            //AppExpiration expiration = db.AppExpirations.First();
            //if(expiration != null)
            //{
            //    DateTime today = DateTime.Now;
            //    DateTime expDateTime = DateTime.Parse(expiration.ExpireDate);
            //    int expMonth = expDateTime.Month;
            //    int currMonth = today.Month;
            //    //if(expMonth == currMonth)
            //    //{
            //        //TotalCalculation.AppDelete(false);
            //    //}
            //}
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (HttpContext.Current.Session != null)
            {
                if (HttpContext.Current.Session["UserId"] != null)
                {
                    isLoggedIn = true;
                    userId = (long)HttpContext.Current.Session["UserId"];
                    HttpContext.Current.Session["IsReportMenuItemActive"] = SessionHandling.CheckModelStatus(userId);
                }
            }
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext){ }

        public override void OnResultExecuted(ResultExecutedContext filterContext){}

        //public void X()
        //{
            

        //    if (isLoggedIn && userId > 0)
        //    {
        //        var userInformation = db.UserInformations.FirstOrDefault(x => x.UserId == userId);
        //        var user = db.Users.FirstOrDefault(x => x.Id == userId);
        //        if (userInformation != null)
        //        {
        //            HttpContext.Current.Session["Signature"] = userInformation.Signature;
        //            var splittedYear = userInformation.AssessmentYear.Split('-');
        //            string year = splittedYear[0];
        //            string yearLastTwoDigit = year.Substring(2, 2);

        //            int yearLastTwoDigitPlusOne = Convert.ToInt32(yearLastTwoDigit) + 1;

        //            HttpContext.Current.Session["FAY"] = splittedYear[0] + "-20" + yearLastTwoDigitPlusOne.ToString();
        //        }
        //    }
        //}
    }
}