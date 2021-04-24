using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Taxations.Controllers
{
    public class TaxationController : Controller
    {
        // GET: Taxation
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult BasicInformation()
        {
            return View();
        }

        public ActionResult StatementOfAssets()
        {
            return View();
        }

        public ActionResult StatementOfExpenses()
        {
            return View();
        }
    }
}