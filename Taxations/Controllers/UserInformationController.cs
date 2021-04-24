using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Taxations.BusinessLogic;
using Taxations.DataAccessLayer;
using Taxations.Models;
using Taxations.Models.EditViewModels;

namespace Taxations.Controllers
{
    public class UserInformationController : Controller
    {
        private TaxationDbContext db = new TaxationDbContext();
        private static readonly long userId = SessionHandling.GetUserIdFromSession();
        private readonly User user = UserHandling.GetUserById(userId);


        public void GetAllViewBag()
        {
            long u_id = (long)Session["UserId"];
            ViewBag.User = db.Users.FirstOrDefault(x => x.Id == u_id);
            var ui = db.UserInformations.FirstOrDefault(x => x.UserId == u_id);
            //if(ui!= null)
            //    ui.AssessmentYear = CustomFormatter.DateFormatterForForm(ui.AssessmentYear, '-', '-');
            ViewBag.UserInformations = ui;
        }

        public ActionResult Create()
        {
            if (SessionHandling.CheckSession())
            {
                GetAllViewBag();
                return View();
            }
            return RedirectToAction("login", "account");
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create(UserInformation userInformation, HttpPostedFileBase signatureFile)
        {
            string targetFolderPath = "~/Signatures/";
            string updatedPhotoPath = "";
            if (SessionHandling.CheckSession())
            {
                GetAllViewBag();
                if (ModelState.IsValid)
                {
                    var prevInfoes = db.UserInformations.FirstOrDefault(x => x.UserId == userInformation.UserId);

                    if (prevInfoes == null)
                    {
                        userInformation.TickOnBoxes = userInformation.TickOnBoxes != null
                            ? CustomFormatter.StringTrimmerOnStringArrayFormatter(userInformation.TickOnBoxes, ',') : userInformation.TickOnBoxes;


                        userInformation.Signature = FileHandlingGateway.UploadFile(targetFolderPath, signatureFile);
                        Session["Signature"] = userInformation.Signature;
                        db.UserInformations.Add(userInformation);
                        db.SaveChanges();
                        ViewBag.SuccessMessage = "Information has been added successfully";
                    }
                    else
                    {
                        #region Update Properties
                        prevInfoes.AssessmentYear = userInformation.AssessmentYear;
                        prevInfoes.BIN = userInformation.BIN;
                        prevInfoes.Circle = userInformation.Circle;
                        prevInfoes.DateOfBirth = userInformation.DateOfBirth;
                        prevInfoes.Email = userInformation.Email;
                        prevInfoes.EmployeementStatus = userInformation.EmployeementStatus;
                        prevInfoes.EmployerName = userInformation.EmployerName;
                        prevInfoes.FatherName = userInformation.FatherName;

                        prevInfoes.IncomeYearFrom = userInformation.IncomeYearFrom;
                        prevInfoes.IncomeYearTo = userInformation.IncomeYearTo;
                        prevInfoes.MotherName = userInformation.MotherName;
                        prevInfoes.NameOfAssessee = userInformation.NameOfAssessee;
                        prevInfoes.NewTIN = userInformation.NewTIN;
                        prevInfoes.NID = userInformation.NID;
                        prevInfoes.OldTIN = userInformation.OldTIN;

                        prevInfoes.PermanentAddress = userInformation.PermanentAddress;
                        prevInfoes.PresentAddress = userInformation.PresentAddress;
                        prevInfoes.ResidentStatus = userInformation.ResidentStatus;
                        prevInfoes.ReturnSubmitted = userInformation.ReturnSubmitted;
                        prevInfoes.SpouseName = userInformation.SpouseName;
                        prevInfoes.SpouseTIN = userInformation.SpouseTIN;

                        prevInfoes.Gender = userInformation.Gender;

                        prevInfoes.TickOnBoxes = userInformation.TickOnBoxes != null
                            ? CustomFormatter.StringTrimmerOnStringArrayFormatter(userInformation.TickOnBoxes, ',') : userInformation.TickOnBoxes;


                        prevInfoes.Zone = userInformation.Zone;
                        prevInfoes.UserId = userInformation.UserId;
                        prevInfoes.HouseRentByOffice = userInformation.HouseRentByOffice;
                        prevInfoes.VehiclesByOffice = userInformation.VehiclesByOffice;
                        #endregion


                        if(signatureFile != null)
                        {
                            prevInfoes.Signature = FileHandlingGateway
                                        .UpdateFile(targetFolderPath, prevInfoes.Signature, signatureFile);
                            updatedPhotoPath = prevInfoes.Signature;
                        }

                        db.UserInformations.AddOrUpdate(prevInfoes);
                        db.SaveChanges();
                        ViewBag.SuccessMessage = "Information has been updated successfully";
                    }

                    var u = db.Users.FirstOrDefault(x => x.Id == userInformation.UserId);
                    if (u != null)
                    {
                        u.Gender = userInformation.Gender;
                        db.Users.AddOrUpdate();
                        db.SaveChanges();
                    }

                    GetAllViewBag();
                    //SessionHandling.FormattedAssetYear();
                    if (userInformation != null)
                    {
                        if (!string.IsNullOrEmpty(updatedPhotoPath))
                        {
                            Session["Signature"] = updatedPhotoPath;
                        }

                        var splittedYear = userInformation.AssessmentYear.Split('-');
                        string year = splittedYear[0];
                        string yearLastTwoDigit = year.Substring(2, 2);

                        int yearLastTwoDigitPlusOne = Convert.ToInt32(yearLastTwoDigit) + 1;

                        Session["FAY"] = splittedYear[0] + "-20" + yearLastTwoDigitPlusOne.ToString();
                    }
                    return View();
                }

                return View(userInformation);
            }
            return RedirectToAction("login", "account");

        }

        public ActionResult Index()
        {
            if (SessionHandling.CheckSession())
            {
                ViewBag.User = user;
                return View();
            }
            return RedirectToAction("login", "account");
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
