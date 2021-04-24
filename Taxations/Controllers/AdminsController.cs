using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Taxations.BusinessLogic;
using Taxations.Models;

namespace Taxations.Controllers
{
    public partial class AdminsController : Controller
    {
        TaxationDbContext db = new TaxationDbContext();
        CrystalReportController cr = new CrystalReportController();

        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(Admin model)
        {
            var isExistAdmin = db.Admins.FirstOrDefault(x => x.Email == model.Email && x.Password == model.Password);
            if (isExistAdmin != null)
            {
                CreateUserSession(isExistAdmin);
                return RedirectToAction("index");
            }
            ModelState.AddModelError("", "Given information is error");
            return View();
        }


        public void AllViewBag()
        {
            if (SessionHandling.CheckSession())
            {
                long adminId = SessionHandling.GetUserIdFromSession();
                ViewBag.Admin = db.Admins.FirstOrDefault(x => x.Id == adminId);
            }
        }


        public ActionResult GetAllUsers()
        {
            if (!SessionHandling.CheckSession())
                return RedirectToAction("Login", "Admins");

            return View(db.Users.ToList());
        }

        [HttpGet]
        public ActionResult PutUser(long id)
        {
            if (!SessionHandling.CheckSession())
                return RedirectToAction("Login", "Admins");

            var user = db.Users.FirstOrDefault(x => x.Id == id);
            if (user == null)
                return View();

            return View(user);
        }


        [HttpPost]
        public ActionResult PutUser(User model)
        {
            if (!SessionHandling.CheckSession())
                return RedirectToAction("Login", "Admins");
            if (model == null)
                return View();

            var user = db.Users.FirstOrDefault(x => x.Id == model.Id);
            if (user == null)
                return View();

            user.Active = model.Active;
            user.Bio = model.Bio;
            user.Email = model.Email;
            user.Password = model.Password;
            user.ConfirmPassword = model.ConfirmPassword;
            user.EmploymentStatus = model.EmploymentStatus;
            user.Gender = model.Gender;
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.IsAutistc = model.IsAutistc;

            db.Users.AddOrUpdate(user);
            db.SaveChanges();
            return RedirectToAction("GetAllUsers");
        }





        public ActionResult GetUserInformations(long? id)
        {
            if (!SessionHandling.CheckSession())
                return RedirectToAction("Login", "Admins");
            if (id == null)
                return View(db.UserInformations.ToList());
            return View("GetUserInformation", db.UserInformations.FirstOrDefault(x => x.Id == id));
        }


        //public ActionResult GetBasicInformation()
        //{

        //}

        public ActionResult GetBasicInformations(long? id)
        {
            if (!SessionHandling.CheckSession())
                return RedirectToAction("Login", "Admins");
            if(id == null)
            return View(db.BasicInformations.ToList());
            return View("Bi", db.BasicInformations.FirstOrDefault(x => x.Id == id));
        }

        public ActionResult GetParticularOfIncomeFromSalaries(long? id)
        {
            if (!SessionHandling.CheckSession())
                return RedirectToAction("Login", "Admins");

            if (id == null)
                return View(db.ParticularsOfIncomeFromSalaries.ToList());

            return View("GetParticularOfIncomeFromSalary", db.ParticularsOfIncomeFromSalaries.FirstOrDefault(x => x.Id == id));
        }



        
        public ActionResult GetParticularOftaxCredits(long? id)
        {
            if (!SessionHandling.CheckSession())
                return RedirectToAction("Login", "Admins");

            if (id == null)
                return View(db.ParticularsOfTaxCredits.ToList());

            return View("GetParticularOftaxCredit", db.ParticularsOfTaxCredits.FirstOrDefault(x => x.Id == id));
        }



        public ActionResult GetStatementOfAssets(long? id)
        {
            if (!SessionHandling.CheckSession())
                return RedirectToAction("Login", "Admins");

            if (id == null)
                return View(db.StatementOfAssets.ToList());

            return View("GetStatementOfAsset", db.StatementOfAssets.FirstOrDefault(x => x.Id == id));
        }

        public ActionResult GetStatementOfExpenses(long? id)
        {
            if (!SessionHandling.CheckSession())
                return RedirectToAction("Login", "Admins");

            if (id == null)
                return View(db.StatementOfExpense.ToList());

            return View("GetStatementOfExpense", db.StatementOfExpense.FirstOrDefault(x => x.Id == id));
        }

        public ActionResult GR(string repName, long id)
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

        private void CreateUserSession(Admin admin)
        {
            Session["UserId"] = admin.Id;
            Session["UserName"] = admin.FullName;
            Session["Email"] = admin.Email;
            Session["UserType"] = admin.AdminType;
        }




        public ActionResult Index()
        {
            if (SessionHandling.CheckSession())
            {
                AllViewBag();
                return View();
            }
            return RedirectToAction("login");
        }

        public ActionResult AllUser(string userType)
        {
            if (SessionHandling.CheckSession())
            {
                AllViewBag();
                List<User> users = db.Users.ToList();

                if (userType == "pvt")
                {
                    users = db.Users.Where(x => x.EmploymentStatus == "pvt").ToList();
                }
                if (userType == "govt")
                {
                    users = db.Users.Where(x => x.EmploymentStatus == "govt").ToList();
                }
                return View(users);
            }
            return RedirectToAction("login");
        }

        public ActionResult UserDetails(long? id)
        {

            if (SessionHandling.CheckSession())
            {
                AllViewBag();

                if (id > 0 || id != null)
                {
                    var user = db.Users.Find(id);
                    if (user != null)
                    {
                        return View(user);
                    }
                    return RedirectToAction("index", "notfound");
                }
                return RedirectToAction("index", "notfound");
            }
            return RedirectToAction("login");
        }

        public ActionResult UserInformations()
        {
            if (SessionHandling.CheckSession())
            {
                AllViewBag();
                return View(db.UserInformations.ToList());
            }
            return RedirectToAction("login");
        }





        public ActionResult BasicInformations(long id)
        {
            AllViewBag(id);
            var bi = db.BasicInformations.FirstOrDefault(x => x.UserId == id);
            var ui = db.UserInformations.FirstOrDefault(x => x.UserId == id);
            ui.AssessmentYear = CustomFormatter.DateCurrentYearWithNextYearTwoDigitFormatter(ui.AssessmentYear);
            ui.DateOfBirth = CustomFormatter.DateDDMMYYFormatter(ui.DateOfBirth);
            bi.DateOfSignature = CustomFormatter.DateDDMMYYFormatter(bi.DateOfSignature);
            bi.DateOfSubmition = CustomFormatter.DateDDMMYYFormatter(bi.DateOfSubmition);
            return View(bi);
        }


        public ActionResult IncomeFromSalaries(long id)
        {
            AllViewBag(id);
            ViewBag.TaxExempteds = db.TaxExempteds.FirstOrDefault(x => x.UserId == id);
            ViewBag.ParticularsOfIncomeAmounts = db.ParticularsOfIncomeAmounts.FirstOrDefault(x => x.UserId == id);
            var ui = db.UserInformations.FirstOrDefault(x => x.UserId == id);
            ui.AssessmentYear = CustomFormatter.DateCurrentYearWithNextYearTwoDigitFormatter(ui.AssessmentYear);
            return View(db.ParticularsOfIncomeFromSalaries.FirstOrDefault(x => x.UserId == id));
        }

        public ActionResult StatementOfExpenses(long id)
        {
            AllViewBag(id);
            var model = db.StatementOfExpense.FirstOrDefault(x => x.UserId == id);
            model.AssessmentYear = CustomFormatter.DateDDMMYYFormatter(model.AssessmentYear);
            model.StatementDate = CustomFormatter.DateDDMMYYFormatter(model.StatementDate);
            var ui = db.UserInformations.FirstOrDefault(x => x.UserId == id);
            ui.AssessmentYear = CustomFormatter.DateCurrentYearWithNextYearTwoDigitFormatter(ui.AssessmentYear);
            return View(model);
        }

        public ActionResult ParticularsOfTaxCredit(long id)
        {
            AllViewBag(id);
            var model = db.ParticularsOfTaxCredits.FirstOrDefault(x => x.UserId == id);
            model.AssessmentYear = CustomFormatter.DateDDMMYYFormatter(model.AssessmentYear);
            var ui = db.UserInformations.FirstOrDefault(x => x.UserId == id);
            ui.AssessmentYear = CustomFormatter.DateCurrentYearWithNextYearTwoDigitFormatter(ui.AssessmentYear);
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
            return View(assetModel);
        }

        private void AllViewBag(long userId)
        {
            var maxAssetId = db.StatementOfAssets.Where(x => x.UserId == userId).Max(y => y.Id);
            var ui = db.UserInformations.FirstOrDefault(x => x.UserId == userId);
            //ui.AssessmentYear = CustomFormatter.DateDDMMYYFormatter(ui.AssessmentYear);
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