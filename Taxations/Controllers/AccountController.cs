using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using Taxations.BusinessLogic;
using Taxations.Dtos;
using Taxations.Models;

namespace Taxations.Controllers
{
    public class AccountController : Controller
    {
        private TaxationDbContext db = new TaxationDbContext();
        //private readonly string targetFolderPath = "~/Images/UserImages/";
        private readonly string targetFolderPath = "~/Images/";
        private readonly string projectUrl = "http://localhost:1940";
        private string url = "/account/confirm?regId=";
        private string passwordRecoveryUrl = "/account/recoverAccount?regId=";

        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(User model, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (!FileHandlingGateway.IsImageFile(file))
                {
                    ModelState.AddModelError("", "Please select an image file.");
                    return View();
                }

                model.PhotoPath = FileHandlingGateway.UploadFile(targetFolderPath, file);
                db.Users.Add(model);
                db.SaveChanges();

                Uri uri = new Uri(Request.Url.ToString());
                string requested = uri.Scheme + Uri.SchemeDelimiter + uri.Host + ":" + uri.Port;
                string projectUrl = "http://localhost:1940/";
                if (requested != projectUrl)
                {
                    requested += "/tax";
                }
                url = requested + url;

                //SENDING EMAIL...
                EmailConfirmation.BuildEmailTemplate(model.Id, url, false);

                return RedirectToAction("RegistrationSuccess",
                            "Account",
                            new { regSuccess = "registration-succeeded" });
            }

            return View(model);
        }

        public ActionResult RegistrationSuccess(string regSuccess)
        {
            if (regSuccess == "registration-succeeded")
            {
                ViewBag.SuccessClasses = "alert alert-success";
                ViewBag.SuccessStatus = "Your Account Created Successfully. " +
                                        "A Confirmation email is send to your mail account. Please check your account. ";
                return View();
            }
            else
            {
                return RedirectToAction("notfound", "badrequest");
            }
        }

        public ActionResult Confirm(int regId)
        {
            ViewBag.regId = regId;
            return View();
        }

        public JsonResult RegisterConfirm(int regId)
        {
            User user = db.Users.FirstOrDefault(x => x.Id == regId);
            user.Active = true;
            user.IsEmailConfirmed = true;
            db.SaveChanges();
            return Json("Your email was varified.", JsonRequestBehavior.AllowGet);
        }

        public ActionResult EditProfile(long? id)
        {
            if (SessionHandling.CheckSession())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                User user = db.Users.Find(id);
                if (user == null)
                {
                    return HttpNotFound();
                }
                ViewBag.User = user; 
                UserInformation ui = db.UserInformations.FirstOrDefault(x => x.UserId == user.Id);
                if (ui != null)
                    ViewBag.UserInformations = ui;
                return View(user);
            }
            return RedirectToAction("login", "account");

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult editProfile(User model, HttpPostedFileBase file)
        {
            if (SessionHandling.CheckSession())
            {
                User user = db.Users.FirstOrDefault(x => x.Id == model.Id);
                if (user == null)
                    return HttpNotFound();
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.IsAutistc = model.IsAutistc;
                user.Bio = model.Bio;
                user.WhoYouAre = model.WhoYouAre;
                user.EmploymentStatus = model.EmploymentStatus;
                user.Gender = model.Gender;
                if (file != null)
                {
                    user.PhotoPath = FileHandlingGateway.UpdateFile(targetFolderPath, user.PhotoPath, file);
                }
                db.Users.AddOrUpdate(user);
                db.SaveChanges();
                ViewBag.User = user;
                ViewBag.SuccessMessage = "Profile Updated";
                UserInformation ui = db.UserInformations.FirstOrDefault(x => x.UserId == user.Id);
                if (ui != null)
                    ViewBag.UserInformations = ui;
                CreateUserSession(user);
                //return View(user);
                return RedirectToAction("create", "userinformation");
            }
            return RedirectToAction("login", "account");

        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User model)
        {
            var check = db.Users.FirstOrDefault(x => x.Email == model.Email
                                                && x.Password == model.Password
                                                && x.EmploymentStatus == model.EmploymentStatus
                                               );
            if (check == null)
            {
                ModelState.AddModelError("", "There is no account with given informations.");
                return View();
            }

            if (!check.IsEmailConfirmed)
            {
                ModelState.AddModelError("", "Your email isn't confirmed yet.");
                return View();
            }

            if (check != null)
            {
                CreateUserSession(check);
                Session["IsReportMenuItemActive"] = SessionHandling.CheckModelStatus(check.Id);
                return RedirectToAction("create", "userinformation");
            }
            else
            {
                ModelState.AddModelError("", "Given information was error.");
                return View();
            }
        }

        private void CreateUserSession(User user)
        {
            Session["UserName"] = user.FirstName + " " + user.LastName;
            Session["UserId"] = user.Id;
            Session["Email"] = user.Email;
            Session["UserType"] = user.EmploymentStatus;
            Session["UserGender"] = user.Gender;
            Session["IsAutistc"] = user.IsAutistc;
            Session["IsReportMenuItemActive"] = SessionHandling.CheckModelStatus(user.Id);
            var userInformation = db.UserInformations.FirstOrDefault(u => u.UserId == user.Id);
            if (userInformation != null)
            {
                if (!string.IsNullOrEmpty(userInformation.Signature))
                {
                    Session["Signature"] = userInformation.Signature;
                }

                var splittedYear = userInformation.AssessmentYear.Split('-');
                string year = splittedYear[0];
                string yearLastTwoDigit = year.Substring(2, 2);

                int yearLastTwoDigitPlusOne = Convert.ToInt32(yearLastTwoDigit) + 1;

                Session["FAY"] = splittedYear[0] + "-20" + yearLastTwoDigitPlusOne.ToString();
            }

            SessionHandling.FormattedAssetYear();

            
        }

        public JsonResult Logout()
        {
            Session["UserName"] = null;
            Session["UserId"] = null;
            Session["Email"] = null;
            Session["UserType"] = null;
            Session["UserGender"] = null;
            Session["IsAutistc"] = null;
            Session["IsReportMenuItemActive"] = null;
            return Json("Logout", JsonRequestBehavior.AllowGet);
        }

        public JsonResult IsEmailExists(string Email)
        {
            return Json(!db.Users.Any(x => x.Email == Email), JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetPassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetPassword(string email)
        {
            var user = db.Users.FirstOrDefault(u => u.Email == email);
            if (user == null)
            {
                ViewBag.Error = email;
                return View();
            }
            else
            {
                user.RecoveryCode = Guid.NewGuid().ToString();
                db.Users.AddOrUpdate(user);
                db.SaveChanges();

                ViewBag.Success = "We have send password recovery email to your mail account. Please check.";

                Uri uri = new Uri(Request.Url.ToString());
                string requested = uri.Scheme + Uri.SchemeDelimiter + uri.Host + ":" + uri.Port;

                passwordRecoveryUrl = requested + passwordRecoveryUrl;

                //SENDING RECOVERY EMAIL...
                EmailConfirmation.BuildEmailTemplate(user.Id, passwordRecoveryUrl, true);
                return View();
            }
        }

        public ActionResult RecoverAccount(long regId, string recoverCode)
        {
            ViewBag.User = db.Users.FirstOrDefault(x => x.Id == regId && x.RecoveryCode == recoverCode);
            return View();
        }

        [HttpPost]
        public ActionResult RecoverAccount(PasswordRecoveryDto dto)
        {
            if (dto.Password == null || dto.ConfirmPassword == null || dto.RecoveryCode == null)
            {
                ViewBag.Error = $"Password,Confirm Password is Empty.";
                return RedirectToAction("getPassword");
            }

            if (dto.Password.Length < 6 || dto.ConfirmPassword.Length < 6)
            {
                ViewBag.Error = "Please provide more secure passsword.";
                return View();
            }

            if (dto.Password != dto.ConfirmPassword)
            {
                ViewBag.Error = "Passsword & Confirm Password doesn't matched.";
                return View();
            }

            var user = db.Users.FirstOrDefault(x => x.Id == dto.UserId && x.RecoveryCode == dto.RecoveryCode);
            ViewBag.User = user;

            if (user == null && dto.RecoveryCode == null)
            {
                ViewBag.Error = "OOps! This is old confirmaion link.";
                return View();
            }

            user.Password = dto.Password;
            user.ConfirmPassword = dto.ConfirmPassword;
            user.RecoveryCode = Guid.NewGuid().ToString();

            db.Users.AddOrUpdate(user);
            db.SaveChanges();
            ViewBag.Success = "Password has been changed successfully";

            CreateUserSession(user);
            return View();
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
