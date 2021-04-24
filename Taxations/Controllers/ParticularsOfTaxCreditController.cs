using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Taxations.BusinessLogic;
using Taxations.DataAccessLayer;
using Taxations.Dtos;
using Taxations.Models;
using Taxations.Models.EditViewModels;

namespace Taxations.Controllers
{
    public class ParticularsOfTaxCreditController : Controller
    {
        private readonly TaxationDbContext db = new TaxationDbContext();
        private readonly string targetFolderPath = "~/Images/BasicInformationImages/";
        private readonly long userId = SessionHandling.GetUserIdFromSession();

        public ActionResult CreateParticularsOfTaxCredit()
        {
            if (SessionHandling.CheckSession())
            {
                var userInformations = db.UserInformations.FirstOrDefault(x => x.UserId == userId);
                AllViewBag();
                if (userInformations != null)
                {
                    ViewBag.ParticularsOfIncomeFromSalariesTotal =
                        db.ParticularsOfIncomeFromSalaries.FirstOrDefault(x => x.UserId == userId);
                    return View(db.ParticularsOfTaxCredits.FirstOrDefault(x => x.UserId == userId));
                }
                return RedirectToAction("create", "userInformation");
            }
            return RedirectToAction("login", "account");
        }

        private void AllViewBag()
        {
            ViewBag.UserInformations = db.UserInformations.FirstOrDefault(x => x.UserId == userId);
            ViewBag.User = UserHandling.GetUserById(SessionHandling.GetUserIdFromSession());
            ViewBag.ParticularsOfTaxCredits = db.ParticularsOfTaxCredits.FirstOrDefault(x => x.UserId == userId);

            ViewBag.ParticularsOfIncomeFromSalaries = db.ParticularsOfIncomeFromSalaries.FirstOrDefault(x => x.UserId == userId);

            ViewBag.ParticularsOfIncomeFromSalariesTotal = db.ParticularsOfIncomeFromSalaries.FirstOrDefault(x => x.UserId == userId);
            //var particularOfIncomeFromSalaries = db.ParticularsOfIncomeFromSalaries.FirstOrDefault(x => x.UserId == userId);

            //if (particularOfIncomeFromSalaries != null)
            //{
            //    ViewBag.ParticularsOfIncomeFromSalariesTotal = particularOfIncomeFromSalaries.Total;
            //}
        }

        [HttpPost]
        public ActionResult CreateParticularsOfTaxCredit(ParticularsOfTaxCredit model, HttpPostedFileBase file)
        {
            if (SessionHandling.CheckSession())
            {
                var userInformations = db.UserInformations.FirstOrDefault(x => x.UserId == userId);
                AllViewBag();
                if (userInformations != null)
                {
                    var existParticularsOfTaxCredits = db.ParticularsOfTaxCredits.FirstOrDefault(x => x.UserId == model.UserId);
                    if (existParticularsOfTaxCredits != null)
                    {
                        model.SignatureAndDatePhoto =
                            FileHandlingGateway.UpdateFile(
                                targetFolderPath, existParticularsOfTaxCredits.SignatureAndDatePhoto, file);
                        db.ParticularsOfTaxCredits.AddOrUpdate(EditParticularsOfTaxCreditViewModel.EditParticularsOfTaxCredit(model, existParticularsOfTaxCredits));
                        db.SaveChanges();
                        ViewBag.SuccessMessage = "Particulars Of Tax Credits has been updated successfully.";
                    }
                    else
                    {
                        model.SignatureAndDatePhoto = FileHandlingGateway.UploadFile(targetFolderPath, file);
                        db.ParticularsOfTaxCredits.Add(model);
                        db.SaveChanges();
                        ViewBag.SuccessMessage = "Particulars Of Tax Credits has been saved successfully.";
                    }
                        

                    if (TotalCalculation.IsExistTotalInfoes())
                    {
                        var prevTotalInfoes = db.TotalInfoes.FirstOrDefault(x => x.UserId == userId);
                        prevTotalInfoes.TaxCredit = model.TotalAllowableInvestment;

                        TotalCalculation.UpdateTotalInfoes(prevTotalInfoes);
                    }
                    else
                    {
                        TotalCalculation.AddTotalInfoes(new TotalInfo
                        {
                            TaxCredit = model.TotalAllowableInvestment,
                            UserId = userId
                        });
                    }
                    AllViewBag();

                    return View();
                }
                else
                {
                    return View();
                }
            }
            return RedirectToAction("login", "account");
        }

        [HttpPost]
        public JsonResult CreateDpsInfo(DPSInfo dpsInfo)
        {
            if (SessionHandling.CheckSession())
            {
                if (dpsInfo != null)
                {
                    DPSInfo prevDpsInfo = db.DPSInfoes.FirstOrDefault(x => x.BankName == dpsInfo.BankName && x.UserId == userId);

                    if (prevDpsInfo == null)
                    {
                        db.DPSInfoes.Add(dpsInfo);
                        db.SaveChanges();
                        return Json("Informations saved successfully.", JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(null, JsonRequestBehavior.AllowGet);
                    }
                }
            }
            return Json(null, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public JsonResult DpsInfoes()
        {
            if (SessionHandling.CheckSession())
            {
                var infoes = db.DPSInfoes.Where(x => x.UserId == userId);

                if (infoes.Count() > 0)
                    return Json(db.DPSInfoes.Where(x => x.UserId == userId).ToList(), JsonRequestBehavior.AllowGet);
                else
                    return Json(infoes, JsonRequestBehavior.AllowGet);
            }
            return Json(null, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]

        public JsonResult DeleteDpsInfo(DPSInfo dpsInfo)
        {
            if (SessionHandling.CheckSession())
            {
                var info = db.DPSInfoes.FirstOrDefault(x => x.Id == dpsInfo.Id);
                if (info != null)
                {
                    db.DPSInfoes.Remove(info);
                    db.SaveChanges();
                    return Json(db.DPSInfoes.Where(x => x.UserId == userId).ToList(), JsonRequestBehavior.AllowGet);
                }
            }
            return Json(null, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public async Task<JsonResult> GetInsurances()
        {
            if (!SessionHandling.CheckSession())
                return Json("Not authenticated", JsonRequestBehavior.DenyGet);

            return Json(await db.Insurances.ToListAsync(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<JsonResult> SaveInsurance(Insurance model)
        {
            if (!SessionHandling.CheckSession())
                return Json("Not authenticated", JsonRequestBehavior.DenyGet);

            model.Year = Convert.ToInt64(DateTime.Now.Year).ToString();
            db.Insurances.Add(model);
            await db.SaveChangesAsync();
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<JsonResult> DeleteInsurance(long id)
        {
            if (!SessionHandling.CheckSession())
                return Json("Not authenticated", JsonRequestBehavior.DenyGet);

            var insuranceToDelete = await db.Insurances.FirstOrDefaultAsync(x => x.Id == id);
            if (insuranceToDelete != null)
            {
                db.Insurances.Remove(insuranceToDelete);
                await db.SaveChangesAsync();
                return Json("deleted", JsonRequestBehavior.AllowGet);
            }
            return Json(null, JsonRequestBehavior.AllowGet);
        }


    }
}