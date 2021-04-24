using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Taxations.DataAccessLayer;
using Taxations.Models;

namespace Taxations.Controllers
{
    public class UserController : Controller
    {
        private readonly TaxationDbContext db = new TaxationDbContext();
        private readonly User user = UserHandling.GetUserById(SessionHandling.GetUserIdFromSession());
        private readonly long userId = SessionHandling.GetUserIdFromSession();
        public ActionResult Profile()
        {
            if (SessionHandling.CheckSession())
            {
                AllViewBag();
                return View(user);
            }
            return RedirectToAction("login", "account");

        }

        public ActionResult UserManual()
        {
            if (SessionHandling.CheckSession())
            {
                AllViewBag();
                return View(user);
            }
            return RedirectToAction("login", "account");

        }

        public ActionResult Downloads()
        {
            if (SessionHandling.CheckSession())
            {
                AllViewBag();
                return View(user);
            }
            return RedirectToAction("login", "account");
        }

        public ActionResult DownloadBasicInformation(long id)
        {
            AllViewBag();
            return View(db.BasicInformations.FirstOrDefault(x => x.UserId == id));

        }

        public ActionResult PrintBasicInformation(long id)
        {
            var user = db.Users.FirstOrDefault(x => x.Id == id);
            //if (SessionHandling.CheckSession())
            //{
            //    var report = new Rotativa.ActionAsPdf("DownloadBasicInformation", new { id = id })
            //    {
            //        FileName = user.FirstName + " " + user.LastName + ".pdf",
            //        PageOrientation = Rotativa.Options.Orientation.Portrait,
            //        PageSize = Rotativa.Options.Size.A4,
            //        IsLowQuality = true,

            //    };
            //    return report;
            //}
            //return RedirectToAction("login", "account");
            var report = new Rotativa.ActionAsPdf("DownloadBasicInformation", new { id = id });
            return report;
        }



        public ActionResult DownloadParticularsOfIncomeFromSlaries()
        {
            if (SessionHandling.CheckSession())
            {
                AllViewBag();
                return View(db.ParticularsOfIncomeFromSalaries.FirstOrDefault(x => x.UserId == userId));
            }
            return RedirectToAction("login", "account");
        }

        public ActionResult DownloadParticularsOfTaxCredit()
        {
            if (SessionHandling.CheckSession())
            {
                AllViewBag();
                return View(db.ParticularsOfTaxCredits.FirstOrDefault(x => x.UserId == userId));
            }
            return RedirectToAction("login", "account");
        }

        public ActionResult DownloadStatementOfAssets()
        {
            if (SessionHandling.CheckSession())
            {
                AllViewBag();
                return View(db.StatementOfAssets.FirstOrDefault(x => x.UserId == userId));
            }
            return RedirectToAction("login", "account");
        }

        public ActionResult DownloadStatementOfExpenses()
        {
            if (SessionHandling.CheckSession())
            {
                AllViewBag();
                return View(db.StatementOfExpense.FirstOrDefault(x => x.UserId == userId));
            }
            return RedirectToAction("login", "account");
        }

        public ActionResult DownloadUserInformation()
        {
            if (SessionHandling.CheckSession())
            {
                AllViewBag();
                return View(db.UserInformations.FirstOrDefault(x => x.UserId == userId));
            }
            return RedirectToAction("login", "account");
        }

        public ActionResult Documentaions()
        {
            if (SessionHandling.CheckSession())
            {
                AllViewBag();
                return View(user);
            }
            return RedirectToAction("login", "account");

        }

        public ActionResult Contacts()
        {
            if (SessionHandling.CheckSession())
            {
                AllViewBag();
                return View(user);
            }
            return RedirectToAction("login", "account");

        }

        public ActionResult Helps()
        {
            if (SessionHandling.CheckSession())
            {
                AllViewBag();
                return View(user);
            }
            return RedirectToAction("login", "account");

        }

        private void AllViewBag()
        {
            ViewBag.StatementOfExpense = db.StatementOfExpense.FirstOrDefault(x => x.UserId == userId);
            ViewBag.UserInformations = db.UserInformations.FirstOrDefault(x => x.UserId == userId);
            ViewBag.AllInformations = db.TotalInfoes.FirstOrDefault(x => x.UserId == userId);
            ViewBag.BasicInformations = db.BasicInformations.FirstOrDefault(x => x.UserId == userId);
            ViewBag.UserInformations = db.UserInformations.FirstOrDefault(x => x.UserId == userId);
            ViewBag.FinalCalculations = db.FinalCalculations.FirstOrDefault(x => x.UserId == userId);
            ViewBag.ParticularsOfSalaries = db.ParticularsOfIncomeFromSalaries
                                                .FirstOrDefault(x => x.UserId == userId);

            ViewBag.ParticularsOfIncomeFromSalaries =
                db.ParticularsOfIncomeFromSalaries.FirstOrDefault(x => x.UserId == userId);


            ViewBag.StatementOfAsset = db.StatementOfAssets.FirstOrDefault(x => x.UserId == userId);


            ViewBag.ParticularsOfTaxCredits = db.ParticularsOfTaxCredits.FirstOrDefault(x => x.UserId == userId);


            ViewBag.User = user;
        }

    }
}