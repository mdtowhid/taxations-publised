using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Taxations.BusinessLogic;
using Taxations.Models;

namespace Taxations.Controllers
{
    public partial class CrystalReportController : Controller
    {
        TaxationDbContext db = new TaxationDbContext();

        public ActionResult Home()
        {
            if (SessionHandling.CheckSession())
            {
                AllViewBag((long)Session["UserId"]);
                return View();
            }
            return RedirectToAction("login", "account");
        }

        public ActionResult GenerateReport(string repName, long id)
        {
            if (SessionHandling.CheckSession())
            {
                if ((repName == null || string.IsNullOrWhiteSpace(repName)) && id < 0)
                    return View(new { repName = "Report not found." });

                if (repName == "BasicInformations")
                    return new Rotativa.ActionAsPdf("BasicInformations", new { id });

                if (repName == "IncomeFromSalaries")
                    return new Rotativa.ActionAsPdf("IncomeFromSalaries", new { id });

                if (repName == "StatementOfExpenses")
                    return new Rotativa.ActionAsPdf("StatementOfExpenses", new { id });

                if (repName == "ParticularsOfTaxCredit")
                    return new Rotativa.ActionAsPdf("ParticularsOfTaxCredit", new { id });

                if (repName == "StatementOfAssets")
                    return new Rotativa.ActionAsPdf("StatementOfAssets", new { id });
            }

            return RedirectToAction("login", "account");
        }

 



        public ActionResult BasicInformations(long id)
        {
            AllViewBag(id);
            var bi = db.BasicInformations.FirstOrDefault(x => x.UserId == id);
            var ui = db.UserInformations.FirstOrDefault(x => x.UserId == id);
            ui.DateOfBirth = CustomFormatter.DateDDMMYYFormatter(ui.DateOfBirth);
            bi.DateOfSignature = CustomFormatter.DateDDMMYYFormatter(bi.DateOfSignature);
            bi.DateOfSubmition = CustomFormatter.DateDDMMYYFormatter(bi.DateOfSubmition);
            bi.Signature = Session["Signature"].ToString();
            //string signature = SessionHandling.GetSignatureFromSession();
            //if (signature.Length > 0)
            //    bi.Signature = signature;
            return View(bi);
        }


        public ActionResult IncomeFromSalaries(long id)
        {
            AllViewBag(id);
            ViewBag.TaxExempteds = db.TaxExempteds.FirstOrDefault(x => x.UserId == id);
            ViewBag.ParticularsOfIncomeAmounts = db.ParticularsOfIncomeAmounts.FirstOrDefault(x => x.UserId == id);
            var ui = db.UserInformations.FirstOrDefault(x => x.UserId == id);
            ui.AssessmentYear = CustomFormatter.DateCurrentYearWithNextYearTwoDigitFormatter(ui.AssessmentYear);

            var p = db.ParticularsOfIncomeFromSalaries.FirstOrDefault(x => x.UserId == id);
            p.PhotoPath = Session["Signature"].ToString();
            //string signature = SessionHandling.GetSignatureFromSession();
            //if (signature.Length > 0)
            //    p.PhotoPath = signature;
            return View(p);
        }

        public ActionResult StatementOfExpenses(long id)
        {
            AllViewBag(id);
            var model = db.StatementOfExpense.FirstOrDefault(x => x.UserId == id);
            model.AssessmentYear = CustomFormatter.DateDDMMYYFormatter(model.AssessmentYear);
            model.StatementDate = CustomFormatter.DateDDMMYYFormatter(model.StatementDate);
            var ui = db.UserInformations.FirstOrDefault(x => x.UserId == id);
            ui.AssessmentYear = CustomFormatter.DateCurrentYearWithNextYearTwoDigitFormatter(ui.AssessmentYear);
            model.SignatureAndDatePhotoPath = Session["Signature"].ToString();
            //string signature = SessionHandling.GetSignatureFromSession();
            //if (signature.Length > 0)
            //    model.SignatureAndDatePhotoPath = signature;
            return View(model);
        }

        public ActionResult ParticularsOfTaxCredit(long id)
        {
            AllViewBag(id);
            var model = db.ParticularsOfTaxCredits.FirstOrDefault(x => x.UserId == id);
            model.AssessmentYear = CustomFormatter.DateDDMMYYFormatter(model.AssessmentYear);
            var ui = db.UserInformations.FirstOrDefault(x => x.UserId == id);
            ui.AssessmentYear = CustomFormatter.DateCurrentYearWithNextYearTwoDigitFormatter(ui.AssessmentYear);
            model.SignatureAndDatePhoto = Session["Signature"].ToString();
            //string signature = SessionHandling.GetSignatureFromSession();
            //if (signature.Length > 0)
            //    model.SignatureAndDatePhoto = signature;

            return View(model);
        }


        public ActionResult StatementOfAssets(long id)
        {
            var assets = db.StatementOfAssets.Where(x => x.UserId == id);
            var assetModel = db.StatementOfAssets.FirstOrDefault(x => x.UserId == id);
            long MaxId = 0;

            if (assets.Count() > 1)
            {
                MaxId = assets.Max(y => y.Id);
                assetModel = db.StatementOfAssets.FirstOrDefault(x => x.Id == MaxId);
            }

            assetModel.AssessmentYear = CustomFormatter.DateDDMMYYFormatter(assetModel.AssessmentYear);
            assetModel.StatementAsOn = CustomFormatter.DateDDMMYYFormatter(assetModel.StatementAsOn);
            var ui = db.UserInformations.FirstOrDefault(x => x.UserId == id);
            ui.AssessmentYear = CustomFormatter.DateCurrentYearWithNextYearTwoDigitFormatter(ui.AssessmentYear);

            AllViewBag(id);
            assetModel.SecondPagePhotoPath = Session["Signature"].ToString();

            //string signature = SessionHandling.GetSignatureFromSession();
            //if (signature.Length > 0)
            //    assetModel.SecondPagePhotoPath = signature;

            return View(assetModel);
        }

        private void AllViewBag(long userId)
        {
            var maxAssetId = db.StatementOfAssets.Where(x => x.UserId == userId).Max(y=>y.Id);
            var ui = db.UserInformations.FirstOrDefault(x => x.UserId == userId);
            Session["Signature"] = ui.Signature;
            //ui.AssessmentYear = CustomFormatter.DateDDMMYYFormatter(ui.AssessmentYear);


            var splittedYear = ui.AssessmentYear.Split('-');
            string year = splittedYear[0];
            string yearLastTwoDigit = year.Substring(2, 2);

            int yearLastTwoDigitPlusOne = Convert.ToInt32(yearLastTwoDigit) + 1;

            Session["FAY"] = splittedYear[0] + "-20" + yearLastTwoDigitPlusOne.ToString();

            ui.AssessmentYear = Session["FAY"].ToString();
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