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
    public class ParticularsOfIncomeFromSlariesController : Controller
    {
        private readonly TaxationDbContext db = new TaxationDbContext();
        private readonly long userId = SessionHandling.GetUserIdFromSession();
        private readonly string targetFolderPath = "~/Images/IncomeFromSlariesImages/";

        public ActionResult Create()
        {
            if (SessionHandling.CheckSession())
            {
                var userInformations = db.UserInformations.FirstOrDefault(x => x.UserId == userId);
                AllViewBag();
                if (userInformations != null)
                {
                    var pOIFS = db.ParticularsOfIncomeFromSalaries.FirstOrDefault(x => x.UserId == userId);
                    var te = db.TaxExempteds.FirstOrDefault(x => x.UserId == userId);
                    if (pOIFS == null && te!=null)
                    {
                        db.TaxExempteds.Remove(te);
                        db.SaveChanges();
                    }
                    return View();
                }

                return RedirectToAction("create", "userInformation");
            }
            return RedirectToAction("login", "account");
        }

        [HttpPost]
        public ActionResult Create(
                ParticularsOfIncomeFromSalary model,
                ParticularsOfIncomeAmount poia,
                HttpPostedFileBase file, 
                TaxExempted taxExempted)
        {
            if (SessionHandling.CheckSession())
            {
                var userInformations = db.UserInformations.FirstOrDefault(x => x.UserId == userId);
                AllViewBag();
                

                if (userInformations != null)
                {
                    var existParticularsOfIncomeFromSalary =
                        db.ParticularsOfIncomeFromSalaries.FirstOrDefault(x => x.UserId == userId);

                    var taxExemptedFromDB = db.TaxExempteds.FirstOrDefault(x => x.UserId == userId);
                    var taxAmountsFromDb = db.ParticularsOfIncomeAmounts.FirstOrDefault(x => x.UserId == userId);

                    if (existParticularsOfIncomeFromSalary != null && taxAmountsFromDb != null)
                    {

                        if (file != null)
                            if (FileHandlingGateway.IsImageFile(file)) 
                                model.PhotoPath = FileHandlingGateway.UpdateFile(targetFolderPath,existParticularsOfIncomeFromSalary.PhotoPath, file);
                        
                        db.ParticularsOfIncomeFromSalaries
                            .AddOrUpdate(
                                EditParticularsOfIncomeFromSalaryViewModel
                                .UpdateParticularsOfIncomeFromSalary(model, existParticularsOfIncomeFromSalary)
                            );
                        db.SaveChanges();

                        db.ParticularsOfIncomeAmounts.AddOrUpdate(EditParticularsOfAmountViewModel.ParticularsOfAmount(poia, taxAmountsFromDb));
                        db.SaveChanges();

                        

                        ViewBag.SuccessMessage =
                            "Particulars Of Income From Salary Informations has been Updated Successfully";
                    }
                    else
                    {
                        if (file != null)
                        {
                            if (!FileHandlingGateway.IsImageFile(file) && file != null)
                            {
                                ModelState.AddModelError("", "Please select an image file");
                                return View(model);
                            }
                            model.PhotoPath = FileHandlingGateway.UploadFile(targetFolderPath, file);
                        }

                        db.ParticularsOfIncomeFromSalaries.Add(model);
                        db.SaveChanges();



                        db.ParticularsOfIncomeAmounts.Add(poia);
                        db.SaveChanges();

                        ViewBag.SuccessMessage =
                            "Particulars Of Income From Salary Informations has been Added Successfully";
                    }


                    /*
                     ::
                     :: CODE FOR TAXEXEMPTED
                     ::
                     */

                    if (taxExemptedFromDB != null)
                    {
                        db.TaxExempteds.AddOrUpdate(TaxExemtedMapper(taxExempted, taxExemptedFromDB));
                        db.SaveChanges();
                    }
                    else
                    {
                        db.TaxExempteds.Add(taxExempted);
                        db.SaveChanges();
                    }

                    
                    //if (TotalCalculation.IsExistTotalInfoes())
                    //{
                    //    var prevTotalInfoes = db.TotalInfoes.FirstOrDefault(x => x.UserId == userId);
                    //    prevTotalInfoes.Slaries = model.Total;

                    //    TotalCalculation.UpdateTotalInfoes(prevTotalInfoes);
                    //}
                    //else
                    //{
                    //    TotalCalculation.AddTotalInfoes(new TotalInfo
                    //    {
                    //        Slaries = model.Total,
                    //        UserId = userId
                    //    });
                    //}

                    AllViewBag();
                    return View();
                }

                return RedirectToAction("create", "userInformation");
            }
            return RedirectToAction("login", "account");
        }

        private TaxExempted TaxExemtedMapper(TaxExempted model, TaxExempted oldTaxExempted)
        {
            oldTaxExempted.AllowanceStaffTaxExempted = model.AllowanceStaffTaxExempted;
            oldTaxExempted.ArrearPayTaxExempted = model.ArrearPayTaxExempted;
            oldTaxExempted.BasicPayTaxExempted = model.BasicPayTaxExempted;
            oldTaxExempted.BonusExempted = model.BonusExempted;
            oldTaxExempted.ConveyanceAllowanceTaxExempted = model.ConveyanceAllowanceTaxExempted;
            oldTaxExempted.DearnessAllowanceTaxExempted = model.DearnessAllowanceTaxExempted;
            oldTaxExempted.DeemedIncomeFurnishedExempted = model.DeemedIncomeFurnishedExempted;
            oldTaxExempted.DeemedIncomeTransportExempted = model.DeemedIncomeTransportExempted;
            oldTaxExempted.EmployerContributionExempted = model.EmployerContributionExempted;
            oldTaxExempted.FestivalAllowanceTaxExempted = model.FestivalAllowanceTaxExempted;
            oldTaxExempted.HonorariumTaxExempted = model.HonorariumTaxExempted;
            oldTaxExempted.HouseRentAllowanceTaxExempted = model.HouseRentAllowanceTaxExempted;
            oldTaxExempted.InterestAccruedExempted = model.InterestAccruedExempted;
            oldTaxExempted.LeaveAllowanceTaxExempted = model.LeaveAllowanceTaxExempted;
            oldTaxExempted.MedicalAllowanceTaxExempted = model.MedicalAllowanceTaxExempted;
            oldTaxExempted.OtherAllowancesExempted = model.OtherAllowancesExempted;
            oldTaxExempted.OtherIfAnyExempted = model.OtherIfAnyExempted;
            oldTaxExempted.OvertimeAllowanceExempted = model.OvertimeAllowanceExempted;
            oldTaxExempted.SpecialPayTaxExempted = model.SpecialPayTaxExempted;
            return oldTaxExempted;
        }

        private void AllViewBag()
        {
            ViewBag.UserInformations = db.UserInformations.FirstOrDefault(x => x.UserId == userId);
            ViewBag.TaxExempteds = db.TaxExempteds.FirstOrDefault(x => x.UserId == userId);
            ViewBag.ParticularsOfIncomeFromSalaries =
                db.ParticularsOfIncomeFromSalaries.FirstOrDefault(x => x.UserId == userId);
            ViewBag.ParticularsOfIncomeAmounts = db.ParticularsOfIncomeAmounts.FirstOrDefault(x => x.UserId == userId);
            ViewBag.User = UserHandling.GetUserById(SessionHandling.GetUserIdFromSession());

        }
    }

}