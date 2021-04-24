using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;
using Taxations.BusinessLogic;
using Taxations.DataAccessLayer;
using Taxations.Models;

namespace Taxations.Controllers
{
    public class IncomeTaxController : Controller
    {
        private readonly TaxationDbContext db = new TaxationDbContext();
        private long userId = SessionHandling.GetUserIdFromSession();
        private readonly User user = UserHandling.GetUserById(SessionHandling.GetUserIdFromSession());

        public ActionResult TotalIncome()
        {
            if (SessionHandling.CheckSession())
            {
                GetAllViewBag();

                var particularsOfIncomeFromTaxCredit = db.ParticularsOfIncomeFromSalaries.FirstOrDefault(x => x.UserId == user.Id);
                ViewBag.ParticularsOfIncomeFromTaxCredit = particularsOfIncomeFromTaxCredit;

                return View(particularsOfIncomeFromTaxCredit);
            }
            return RedirectToAction("login", "account");
        }

        public JsonResult TaxableIncomeTaxesHandler(List<TaxableIncomeTax> models)
        {
            long userId = SessionHandling.GetUserIdFromSession();

            if (userId != 0 && models.Count() > 0)
            {
                //REMOVE OLD Taxable Income Taxes
                var tits = db.TaxableIncomeTaxes.Where(x => x.UserId == userId).ToList();
                db.TaxableIncomeTaxes.RemoveRange(tits);

                decimal total = 0;

                foreach (TaxableIncomeTax tit in models)
                {
                    tit.UserId = userId;
                    total += decimal.Parse(tit.NetTax);

                    //ADD NEW Taxable Income Taxes
                    db.TaxableIncomeTaxes.Add(tit);
                    db.SaveChanges();
                }

                if (TotalCalculation.IsExistTotalInfoes())
                {
                    var prevTotalInfoes = db.TotalInfoes.FirstOrDefault(x => x.UserId == userId);
                    prevTotalInfoes.Income = total.ToString();

                    TotalCalculation.UpdateTotalInfoes(prevTotalInfoes);
                }
                else
                {
                    TotalCalculation.AddTotalInfoes(new TotalInfo
                    {
                        TaxCredit = total.ToString(),
                        UserId = userId
                    });
                }

                return Json(db.TaxableIncomeTaxes.Where(x => x.UserId == userId).ToList(), JsonRequestBehavior.AllowGet);
            }
            return Json(null, JsonRequestBehavior.AllowGet);
        }

        public ActionResult TotalInvestment()
        {
            if (SessionHandling.CheckSession())
            {
                GetAllViewBag();
                ViewBag.TaxCredit = db.ParticularsOfTaxCredits.FirstOrDefault(x => x.UserId == userId);
                ViewBag.DpsInfoes = db.DPSInfoes.Where(x => x.UserId == userId).ToList();
                return View();
            }
            return RedirectToAction("login", "account");
        }


        public ActionResult RebateCalculation()
        {
            if (SessionHandling.CheckSession())
            {
                GetAllViewBag();
                ViewBag.TaxCredit = db.ParticularsOfTaxCredits.FirstOrDefault(x => x.UserId == userId);
                ViewBag.MaxDpsInfo = db.DPSInfoes.Where(x => x.UserId == userId).Max(x => x.Amount);
                return View();
            }
            return RedirectToAction("login", "account");
        }

        public ActionResult StatementOfAsset()
        {
            if (SessionHandling.CheckSession())
            {
                userId = SessionHandling.GetUserIdFromSession();
                var statementOfAsset = db.StatementOfAssets.FirstOrDefault(x => x.UserId == userId);
                ViewBag.TotalIncome =
                    db.ParticularsOfIncomeFromSalaries.FirstOrDefault(x => x.UserId == user.Id);

                if (statementOfAsset != null)
                {
                    ViewBag.TotalAssets = statementOfAsset.NetWealth16;
                }

                GetAllViewBag();
                return View();
            }
            return RedirectToAction("login", "account");
        }



        public void GetAllViewBag()
        {
            ViewBag.UserInformations = db.UserInformations.FirstOrDefault(x => x.UserId == userId);
            ViewBag.User = user;
        }

        public ActionResult FinalCalculation()
        {
            if (SessionHandling.CheckSession())
            {
                var a = db.ParticularsOfTaxCredits.FirstOrDefault(x => x.UserId == userId);
                var b = db.ParticularsOfIncomeFromSalaries.FirstOrDefault(x => x.UserId == user.Id);
                var c = db.StatementOfAssets.FirstOrDefault(x => x.UserId == userId);

                var finalCalc = db.FinalCalculations.FirstOrDefault(x => x.UserId == userId);

                if (finalCalc != null)
                    ViewBag.FinalCalc = finalCalc;

                if (a == null)
                {
                    ViewBag.Error = "Particulars Of Tax Credits isn't calculated yet";
                    return View();
                }

                if (b == null)
                {
                    ViewBag.Error = "Particulars Of Income From Salaries Credits isn't calculated yet";
                    return View();
                }

                if (a == null)
                {
                    ViewBag.Error = "Statement Of Assets Credits isn't calculated yet";
                    return View();
                }

                ViewBag.TaxCredit = db.ParticularsOfTaxCredits.FirstOrDefault(x => x.UserId == userId);
                ViewBag.TotalIncome = db.ParticularsOfIncomeFromSalaries.FirstOrDefault(x => x.UserId == user.Id).Total;
                ViewBag.TotalAssets = db.StatementOfAssets.FirstOrDefault(x => x.UserId == userId).ShortageOfFund22;
                ViewBag.Surcharges = db.Surcharges.FirstOrDefault(x => x.UserId == userId);
                GetAllViewBag();
                return View(finalCalc);
            }
            return RedirectToAction("login", "account");
        }

        public JsonResult AddFinalValues(FinalCalculation model)
        {

            var prevFinal = db.FinalCalculations.FirstOrDefault(x => x.UserId == model.UserId);
            if (prevFinal != null)
            {
                FinalCalculation fc = new FinalCalculation
                {
                    DeductedSource = model.DeductedSource,
                    DeductedSourceBank = model.DeductedSourceBank,
                    NetPayableTax = model.NetPayableTax,
                    PayableTax = model.PayableTax,
                    RebateOnInvestment = model.RebateOnInvestment,
                    Surcharge = model.Surcharge,
                    TaxPayable = model.TaxPayable,
                    UserId = model.UserId
                };

                db.FinalCalculations.Remove(prevFinal);
                db.SaveChanges();

                db.FinalCalculations.Add(fc);
                db.SaveChanges();
                return Json(fc, JsonRequestBehavior.AllowGet);
            }
            else
            {
                model.UserId = userId;
                db.FinalCalculations.Add(model);
                db.SaveChanges();
                return Json(model, JsonRequestBehavior.AllowGet);
            }
        }


        public JsonResult AddSurcharge(Surcharge model)
        {
            var prevSurcharge = db.Surcharges.FirstOrDefault(x => x.UserId == model.UserId);

            if (prevSurcharge == null)
            {
                db.Surcharges.Add(model);
                db.SaveChanges();
            }
            else
            {
                db.Surcharges.Remove(prevSurcharge);
                db.SaveChanges();
                db.Surcharges.Add(model);
                db.SaveChanges();
            }

            return Json("Saved", JsonRequestBehavior.AllowGet);
        }


    }
}