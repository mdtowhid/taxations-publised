using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Taxations.DataAccessLayer;
using Taxations.Models;

namespace Taxations.Controllers
{
    public class DefaultController : Controller
    {
        private readonly TaxationDbContext db = new TaxationDbContext();
        private readonly User user = UserHandling.GetUserById(SessionHandling.GetUserIdFromSession());
        private readonly long userId = SessionHandling.GetUserIdFromSession();
        public ActionResult Index()
        {
            if (SessionHandling.CheckSession())
            {
                GetAllViewBag();
                return View();
            }
            return RedirectToAction("login", "account");
        }

        public ActionResult Settings()
        {
            if (SessionHandling.CheckSession())
            {
                GetAllViewBag();
                return View();
            }
            return RedirectToAction("login", "account");
        }

        public void GetAllViewBag()
        {
            var assets = db.StatementOfAssets.Where(x => x.UserId == userId);

            if (assets.Count() == 1)
            {
                ViewBag.StatementOfAsset = db.StatementOfAssets.FirstOrDefault(x => x.UserId == userId);
            }

            if (assets.Count() == 2)
            {
                ViewBag.StatementOfAsset = db.StatementOfAssets.FirstOrDefault(x => x.UserId == assets.Max(y => y.Id));
            }

            ViewBag.User = user;
            ViewBag.UserInformations = db.UserInformations.FirstOrDefault(x => x.UserId == userId);
            ViewBag.StatementOfExpense = db.StatementOfExpense.FirstOrDefault(x => x.UserId == userId);
            ViewBag.ParticularsOfTaxCredits = db.ParticularsOfTaxCredits.FirstOrDefault(x => x.UserId == userId);
            ViewBag.BasicInformations = db.BasicInformations.FirstOrDefault(x => x.UserId == userId);
            ViewBag.ParticularsOfIncomeFromSalaries = db.ParticularsOfIncomeFromSalaries.FirstOrDefault(x => x.UserId == userId);
        }
    }
}