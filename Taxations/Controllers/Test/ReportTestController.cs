using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Taxations.BusinessLogic;
using Taxations.Models;

namespace Taxations.Controllers.Test
{
    public class ReportTestController : Controller
    {
        // GET: ReportTest
        private readonly TaxationDbContext db = new TaxationDbContext();

        public ActionResult BI()
        {
            VB(35);

            //31-12-2020, 
            var bi = db.BasicInformations.FirstOrDefault(x => x.UserId == 35);
            bi.AssessmentYear = CustomFormatter.DateCurrentYearWithNextYearTwoDigitFormatter(bi.AssessmentYear);
            bi.DateOfBirth = CustomFormatter.DateDDMMYYFormatter(bi.DateOfBirth);
            bi.DateOfSignature = CustomFormatter.DateDDMMYYFormatter(bi.DateOfSignature);
            bi.DateOfSubmition = CustomFormatter.DateDDMMYYFormatter(bi.DateOfSubmition);
            return View(bi);
        }

        public void VB(long userId)
        {
            var maxAssetId = db.StatementOfAssets.Where(x => x.UserId == userId).Max(y => y.Id);
            var ui = db.UserInformations.FirstOrDefault(x => x.UserId == userId);
            ui.AssessmentYear = CustomFormatter.DateDDMMYYFormatter(ui.AssessmentYear);
            ViewBag.UserInformations = ui;
            ViewBag.BasicInformations = db.BasicInformations.FirstOrDefault(x => x.UserId == userId);
            ViewBag.TaxCredits = db.ParticularsOfTaxCredits.FirstOrDefault(x => x.UserId == userId);

            ViewBag.StatementOfExpenses = db.StatementOfExpense.FirstOrDefault(x => x.UserId == userId);

            ViewBag.StatementOfAssets = db.StatementOfAssets.Where(x => x.Id == maxAssetId).FirstOrDefault();

            ViewBag.ParticularsOfSalaries = db.ParticularsOfIncomeFromSalaries
                                                .FirstOrDefault(x => x.UserId == userId);
            ViewBag.User = db.Users.FirstOrDefault(x => x.Id == userId);
        }
    }
}