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
    public class StatementOfExpensesController : Controller
    {


        private readonly TaxationDbContext db = new TaxationDbContext();
        private readonly string targetFolderPath = "~/Images/StatementOfExpensesImages/";
        private readonly long userId = SessionHandling.GetUserIdFromSession();
        public ActionResult CreateStatementOfExpenses()
        {
            if (SessionHandling.CheckSession())
            {
                var userInformations = db.UserInformations.FirstOrDefault(x => x.UserId == userId);
                if (userInformations != null)
                {
                    GetAllViewBag();
                    return View(db.StatementOfExpense.FirstOrDefault(x => x.UserId == userId));
                }
                return RedirectToAction("create", "userInformation");
            }

            return RedirectToAction("login", "account");
        }

        public void GetAllViewBag()
        {
            ViewBag.StatementOfExpense = db.StatementOfExpense.FirstOrDefault(x => x.UserId == userId);
            ViewBag.UserInformations = db.UserInformations.FirstOrDefault(x => x.UserId == userId);
            ViewBag.BasicInformations = db.BasicInformations.FirstOrDefault(x => x.UserId == userId);
            ViewBag.User = UserHandling.GetUserById(SessionHandling.GetUserIdFromSession());
        }

        [HttpPost]
        public ActionResult CreateStatementOfExpenses(StatementOfExpense model, HttpPostedFileBase file)
        {
            if (SessionHandling.CheckSession())
            {
                var userInformations = db.UserInformations.FirstOrDefault(x => x.UserId == userId);

                if (userInformations != null)
                {
                    GetAllViewBag();
                    var existStatementOfExpenses = db.StatementOfExpense.FirstOrDefault(x => x.UserId == model.UserId);
                    if (existStatementOfExpenses != null)
                    {
                        model.SignatureAndDatePhotoPath =
                            FileHandlingGateway.UpdateFile(targetFolderPath, existStatementOfExpenses.SignatureAndDatePhotoPath, file);
                        db.StatementOfExpense.AddOrUpdate(EditStatementOfExpensesViewModel.EditStatementOfExpenses(model, existStatementOfExpenses));
                        db.SaveChanges();
                        ViewBag.SuccessMessage = "Statement Of Expenses information has been updated successfully.";
                    }
                    else
                    {
                        model.SignatureAndDatePhotoPath = FileHandlingGateway.UploadFile(targetFolderPath, file);
                        db.StatementOfExpense.Add(model);
                        db.SaveChanges();
                        ViewBag.SuccessMessage = "Statement Of Expenses information has been saved successfully.";
                    }

                    if (TotalCalculation.IsExistTotalInfoes())
                    {
                        var prevTotalInfoes = db.TotalInfoes.FirstOrDefault(x => x.UserId == userId);
                        prevTotalInfoes.Expenses = model.Total;

                        TotalCalculation.UpdateTotalInfoes(prevTotalInfoes);
                    }
                    else
                    {
                        TotalCalculation.AddTotalInfoes(new TotalInfo
                        {
                            Expenses = model.Total,
                            UserId = userId
                        });
                    }

                    GetAllViewBag();
                    return View();
                }
                return RedirectToAction("create", "userInformation");
            }
            return RedirectToAction("login", "account");
        }
    }
}