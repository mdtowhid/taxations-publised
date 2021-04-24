using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Taxations.BusinessLogic;
using Taxations.DataAccessLayer;
using Taxations.Models;
using Taxations.Models.EditViewModels;

namespace Taxations.Controllers
{
    public class BasicInformationController : Controller
    {
        private readonly TaxationDbContext db = new TaxationDbContext();
        private readonly string targetFolderPath = "~/Images/BasicInformationImages/";
        private readonly User user = UserHandling.GetUserById(SessionHandling.GetUserIdFromSession());
        private readonly long userId = SessionHandling.GetUserIdFromSession();


        public ActionResult BasicInformations()
        {
            if (SessionHandling.CheckSession())
            {
                var userInformations = db.UserInformations.FirstOrDefault(x => x.UserId == userId);
                AllViewBag();
                if (userInformations != null)
                {
                    return View(db.BasicInformations.FirstOrDefault(x => x.UserId == userId));
                }
                else
                {
                    return RedirectToAction("create", "userInformation");
                }
            }
            return RedirectToAction("login", "account");
        }

        private void AllViewBag()
        {
            var assets = db.StatementOfAssets.Where(x => x.UserId == userId);
            ViewBag.StatementOfAssets = db.StatementOfAssets.FirstOrDefault(x => x.UserId == userId);
            long MaxId = 0;

            if (assets.Count() > 1)
            {
                MaxId = assets.Max(y => y.Id);
                ViewBag.StatementOfAssets = db.StatementOfAssets.FirstOrDefault(x => x.Id == MaxId);
            }
            var userInfoes = db.UserInformations.FirstOrDefault(x => x.UserId == userId);

            ViewBag.UserInformations = userInfoes;
            ViewBag.AllInformations = db.TotalInfoes.FirstOrDefault(x => x.UserId == userId);
            ViewBag.BasicInformations = db.BasicInformations.FirstOrDefault(x => x.UserId == userId);
            ViewBag.UserInformations = db.UserInformations.FirstOrDefault(x => x.UserId == userId);
            ViewBag.TaxCredits = db.ParticularsOfTaxCredits.FirstOrDefault(x => x.UserId == userId);
            ViewBag.FinalCalculations = db.FinalCalculations.FirstOrDefault(x => x.UserId == userId);
            ViewBag.ParticularsOfSalaries = db.ParticularsOfIncomeFromSalaries
                                                .FirstOrDefault(x => x.UserId == userId);
            ViewBag.User = user;

            ViewBag.Surcharges = db.Surcharges.FirstOrDefault(x => x.UserId == userId);
        }



        [HttpPost]
        public ActionResult BasicInformations(BasicInformation model, HttpPostedFileBase signature, HttpPostedFileBase placeOfSignatur)
        {
            if (SessionHandling.CheckSession())
            {
                var userInformations = db.UserInformations.FirstOrDefault(x => x.UserId == userId);

                AllViewBag();

                if (userInformations != null)
                {
                    var existBasicInformation = db.BasicInformations.FirstOrDefault(x => x.UserId == model.UserId);
                    if (existBasicInformation != null && existBasicInformation.UserId == user.Id)
                    {
                        model.Signature = FileHandlingGateway.UpdateFile(targetFolderPath, existBasicInformation.Signature, signature);
                        db.BasicInformations.AddOrUpdate(
                            EditBasicInformationViewModel.EditBasicInformation(
                                model, existBasicInformation));
                        db.SaveChanges();
                        ViewBag.SuccessMessage = "Basic information has been updated successfully.";
                    }
                    else
                    {
                        model.Signature = FileHandlingGateway.UploadFile(targetFolderPath, signature);
                        //model.PlaceOfSignatur = FileHandlingGateway.UploadFile(targetFolderPath, placeOfSignatur);
                        model.AssessmentYear = CustomFormatter.DateDDMMYYFormatter(model.AssessmentYear);
                        model.DateOfBirth = CustomFormatter.DateDDMMYYFormatter(model.DateOfBirth);
                        model.DateOfSignature = CustomFormatter.DateDDMMYYFormatter(model.DateOfSignature);
                        model.DateOfSubmition = CustomFormatter.DateDDMMYYFormatter(model.DateOfSubmition);

                        db.BasicInformations.Add(model);
                        db.SaveChanges();
                        ViewBag.SuccessMessage = "Basic information has been saved successfully.";
                    }
                    ModelState.AddModelError("", "There is an error while storing your informations");
                    AllViewBag();
                    return View();
                }
                else
                {
                    AllViewBag();
                    return View();
                }
            }
            return RedirectToAction("login", "account");
        }
    }
}