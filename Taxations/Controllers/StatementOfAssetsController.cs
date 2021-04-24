using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web.Mvc;
using Taxations.DataAccessLayer;
using Taxations.Models;
using Taxations.Models.EditViewModels;
using Taxations.Dtos;
using System.Data.Entity;

namespace Taxations.Controllers
{
    public class StatementOfAssetsController : Controller
    {

        private readonly TaxationDbContext db = new TaxationDbContext();
        private readonly string targetFolderPath = "~/Images/StatementOfAssetImages/";
        private readonly long userId = SessionHandling.GetUserIdFromSession();

        private void GetViewBagsForAssets(long userId)
        {
            var assets = db.StatementOfAssets.Where(x => x.UserId == userId);
            if (assets.Count() == 0)
            {
                ViewBag.PrevYearAssetsInfo = null;
                ViewBag.StatementOfAsset = db.StatementOfAssets.FirstOrDefault(x => x.Id == userId);
            }

            if (assets.Count() == 1)
            {
                var a = assets.FirstOrDefault(x => x.UserId == userId);
                var userInformations = db.UserInformations.FirstOrDefault(x => x.UserId == userId);
                long uiYear = Convert.ToInt64(userInformations.AssessmentYear.Split('-')[2]);
                long stateYear = Convert.ToInt64(a.AssessmentYear.Split('-')[2]);

                if (uiYear == stateYear)
                {
                    ViewBag.StatementOfAsset = db.StatementOfAssets.FirstOrDefault(x => x.UserId == userId);
                    ViewBag.PrevYearAssetsInfo = null;
                }
                else if (uiYear != stateYear && uiYear > stateYear)
                {
                    ViewBag.StatementOfAsset = null;
                    ViewBag.PrevYearAssetsInfo = db.StatementOfAssets.FirstOrDefault(x => x.UserId == userId);
                }
            }
            if (assets.Count() == 2)
            {
                ViewBag.PrevYearAssetsInfo = db.StatementOfAssets.FirstOrDefault(x => x.Id == assets.Min(y => y.Id));
                ViewBag.StatementOfAsset = db.StatementOfAssets.FirstOrDefault(x => x.Id == assets.Max(y => y.Id));
            }
        }

        public void GetAllViewBag()
        {
            var userInformation = db.UserInformations.FirstOrDefault(x => x.UserId == userId);
            var assets = db.StatementOfAssets.Where(x => x.UserId == userId).ToList();
            

            if (assets.Count() == 1)
            {
                var uia = DateTime.Parse(userInformation.AssessmentYear);
                var aa = DateTime.Parse(assets[0].AssessmentYear);

                var c = uia.Year;
                var d = aa.Year;
                
                if(c == d)
                {
                    ViewBag.StatementOfAsset = assets[0];
                }
                else if(c > d)
                {
                    ViewBag.PrevYearAssetsInfo = assets[0];
                }
            }
            //

            var DPSInfoes = db.DPSInfoes.Where(x => x.UserId == userId);
            long total = 0;
            foreach (DPSInfo item in DPSInfoes)
            {
                total += Convert.ToInt64(item.Amount);
            }
            ViewBag.DPSInfoes = total;
            ViewBag.TotalInsuranceAmount = GetTotalInsuranceInfo();
            //userInformation.AssessmentYear = CustomFormatter.DateDDMMYYFormatter(userInformation.AssessmentYear);
            ViewBag.UserInformations = userInformation;
            ViewBag.SateMentOfExpenses = db.StatementOfExpense.FirstOrDefault(x => x.UserId == userId);
            ViewBag.User = UserHandling.GetUserById(SessionHandling.GetUserIdFromSession());
            ViewBag.ParticularsOfIncomeFromSalaries = db.ParticularsOfIncomeFromSalaries.FirstOrDefault(x => x.UserId == userId);
        }


        private void Save(StatementOfAsset model)
        {
            db.StatementOfAssets.Add(model);
            db.SaveChanges();
            ViewBag.SuccessMessage = "Statement Of Assets information has been added successfully.";
        }

        private void Update(StatementOfAsset model, StatementOfAsset existStatementOfAsset)
        {
            db.StatementOfAssets.AddOrUpdate(EditStatementOfAssetViewModel.EditStatementOfAsset(model, existStatementOfAsset));
            db.SaveChanges();
            ViewBag.SuccessMessage = "Statement Of Assets information has been updated successfully.";
        }

        private object GetYearInfoes(StatementOfAsset model, long? maxId)
        {
            StatementOfAsset asset = null;
            DateTime fromDBYear = DateTime.Now;
            DateTime fromModelYear = DateTime.Now;

            if (maxId != null)
            {
                asset = db.StatementOfAssets.FirstOrDefault(x => x.Id == maxId);
            }
            else
            {
                asset = db.StatementOfAssets.FirstOrDefault(x => x.Id == model.Id);
            }



            var existStatementOfAsset = db.StatementOfAssets.FirstOrDefault(x => x.UserId == model.UserId);
            string yearFromModel = model.AssessmentYear.Split('-')[0];
            string yearFromDb = existStatementOfAsset.AssessmentYear.Split('-')[0];
            return new object { };
        }

        private long GetTotalInsuranceInfo()
        {
            var insuranceInfoes = db.Insurances.Where(x => x.UserId == userId).ToList();
            long total = 0;
            foreach (Insurance item in insuranceInfoes)
            {
                total += Convert.ToInt64(item.Amount);
            }
            return total;
        }

        public void SetPrevoiusYearAssetInformations(List<StatementOfAsset> assets)
        {
            if (assets.Count() > 1)
            {
                var assetTaken = assets.OrderByDescending(ax => ax.Id).Take(2).ToList();

                var x = assetTaken[0];//21 -- 20
                var y = assetTaken[1];//20 -- 21

                if (DateTime.Parse(x.AssessmentYear) > DateTime.Parse(y.AssessmentYear))
                {
                    ViewBag.PrevYearAssetsInfo = y;
                    ViewBag.StatementOfAsset = x;
                }

                if (DateTime.Parse(x.AssessmentYear) < DateTime.Parse(y.AssessmentYear))
                {
                    ViewBag.PrevYearAssetsInfo = x;
                    ViewBag.StatementOfAsset = y;
                }
            }
        }

        [HttpGet]
        public ActionResult StatementOfAssets()
        {
            if (SessionHandling.CheckSession())
            {
                var userInformation = db.UserInformations.FirstOrDefault(x => x.UserId == userId);
                if (userInformation != null)
                {
                    //GetViewBagsForAssets((long)Session["UserId"]);
                    SetPrevoiusYearAssetInformations(db.StatementOfAssets.Where(x => x.UserId == userId).ToList());
                    GetAllViewBag();
                    return View();
                }
                return RedirectToAction("create", "userInformation");
            }
            return RedirectToAction("login", "account");
        }

        [HttpPost]
        public ActionResult StatementOfAssets(StatementOfAsset model)
        {
            if (SessionHandling.CheckSession())
            {
                var userInformations = db.UserInformations.FirstOrDefault(x => x.UserId == userId);

                if (userInformations != null)
                {
                    GetAllViewBag();
                    var assets = db.StatementOfAssets.Where(x => x.UserId == model.UserId).ToList();

                    if (assets.Count() > 0)
                    {
                        foreach (StatementOfAsset asset in assets)
                        {
                            var modelYear = model.AssessmentYear.Split('-')[0];
                            var isExist = db.StatementOfAssets
                                .FirstOrDefault(x => x.AssessmentYear.Contains(modelYear)
                                || x.AssessmentYear.Contains(model.AssessmentYear));

                            if (isExist != null)
                            {
                                Update(model, asset);
                            }
                            else
                            {
                                Save(model);
                            }
                        }

                        SetPrevoiusYearAssetInformations(assets);
                        return View();
                    }
                    else
                    {
                        Save(model);
                        return View();
                    }
                }
                else
                {
                    return View();
                }
            }
            return RedirectToAction("login", "account");
        }















        //[HttpPost]
        //public ActionResult StatementOfAssets(StatementOfAsset model,
        //    HttpPostedFileBase secondPagePhoto, HttpPostedFileBase thirdPagePhoto)
        //{
        //    if (SessionHandling.CheckSession())
        //    {
        //        var userInformations = db.UserInformations.FirstOrDefault(x => x.UserId == userId);

        //        if (userInformations != null)
        //        {
        //            var assets = db.StatementOfAssets.Where(x => x.UserId == model.UserId);

        //            if (assets.Count() == 0)
        //            {
        //                model.IsPrevYearCalculated = false;
        //                Save(model, secondPagePhoto);
        //                ViewBag.PrevYearAssetsInfo = null;
        //                ViewBag.StatementOfAsset = db.StatementOfAssets.FirstOrDefault(x => x.Id == model.Id);
        //            }

        //            if (assets.Count() == 1)
        //            {
        //                var existStatementOfAsset = db.StatementOfAssets.FirstOrDefault(x => x.Id == assets.Min(y => y.Id));
        //                string yearFromModel = model.AssessmentYear.Split('-')[2];
        //                string yearFromDb = existStatementOfAsset.AssessmentYear.Split('-')[2];

        //                long dbYear = Convert.ToInt64(yearFromDb);
        //                long modelYear = Convert.ToInt64(yearFromModel);

        //                if (modelYear > dbYear)
        //                {
        //                    Save(model, secondPagePhoto);
        //                    ViewBag.PrevYearAssetsInfo
        //                        = db.StatementOfAssets.FirstOrDefault(x => x.Id == assets.Min(y => y.Id));
        //                    ViewBag.StatementOfAsset = db.StatementOfAssets.FirstOrDefault(x => x.Id == assets.Max(y => y.Id));
        //                }

        //                if (modelYear == dbYear)
        //                {
        //                    model.IsPrevYearCalculated = false;
        //                    Update(model, existStatementOfAsset, secondPagePhoto);
        //                    ViewBag.PrevYearAssetsInfo
        //                        = db.StatementOfAssets.FirstOrDefault(x => x.Id == assets.Min(y => y.Id));
        //                    ViewBag.StatementOfAsset = null;
        //                }
        //            }

        //            if (assets.Count() == 2)
        //            {
        //                var currentYearAssets = db.StatementOfAssets.FirstOrDefault(x => x.Id == assets.Max(y => y.Id));
        //                model.IsPrevYearCalculated = true;
        //                Update(model, currentYearAssets, secondPagePhoto);
        //                ViewBag.PrevYearAssetsInfo = db.StatementOfAssets.FirstOrDefault(x => x.Id == assets.Min(y => y.Id));
        //                ViewBag.StatementOfAsset = db.StatementOfAssets.FirstOrDefault(x => x.Id == assets.Max(y => y.Id));
        //            }

        //            GetAllViewBag();

        //            return View();
        //        }
        //        else
        //        {
        //            return View();
        //        }
        //    }
        //    return RedirectToAction("login", "account");
        //}

    }
}