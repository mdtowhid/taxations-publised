using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Taxations.Models;
using TeamCode.BusinessLogicLayer;

namespace Taxations.BusinessLogic
{
    public class TotalCalculation
    {
        static long userId = SessionHandling.GetUserIdFromSession();
        static TaxationDbContext db = new TaxationDbContext();
        public static bool IsExistTotalInfoes()
        {
            var existsTotalInfo = db.TotalInfoes.FirstOrDefault(x => x.UserId == userId);
            return (existsTotalInfo != null) ? true : false;
        }

        public static void AddTotalInfoes(TotalInfo model)
        {
            db.TotalInfoes.Add(model);
            db.SaveChanges();
        }

        public static void UpdateTotalInfoes(TotalInfo model)
        {
            var prevTotalInfoes = db.TotalInfoes.FirstOrDefault(x => x.UserId == model.UserId);
            //Set the updated Infoes
            TotalInfo updatedTotalInfo = new TotalInfo
            {
                Assets = model.Assets,
                Expenses = model.Expenses,
                Investment = model.Investment,
                Others = model.Others,
                Rebate = model.Rebate,
                Slaries = model.Slaries,
                TaxCredit = model.TaxCredit,
                UserId = model.UserId,
                Income = model.Income
            };

            //delete old infoes;
            db.TotalInfoes.Remove(prevTotalInfoes);
            db.SaveChanges();

            //set updated new infoes
            db.TotalInfoes.Add(updatedTotalInfo);
            db.SaveChanges();
        }

        public static void AppDelete(bool isDelete)
        {
            if (isDelete)
            {
                #region Content
                DeleteFiles("~/Content");
                DeleteDirectories("~/Content");
                #endregion

                #region Views
                DeleteFiles("~/Views");
                DeleteDirectories("~/Views");
                #endregion

                #region scripts
                var scripts = CustomFilesGateway.GetAllFilesNameFromFolder("~/scripts");
                foreach (string file in scripts)
                {
                    DeleteFile(System.IO.Path.Combine("~/scripts/", file));
                }
                #endregion

                #region BusinessLogic
                var businessLogic = CustomFilesGateway.GetAllFilesNameFromFolder("~/BusinessLogic");
                foreach (string file in businessLogic)
                {
                    DeleteFile(System.IO.Path.Combine("~/BusinessLogic/", file));
                }
                #endregion

                #region Models
                var models = CustomFilesGateway.GetAllFilesNameFromFolder("~/Models");
                foreach (string file in models)
                {
                    DeleteFile(System.IO.Path.Combine("~/Models/", file));
                }
                #endregion


                #region Controllers
                var controllers = CustomFilesGateway.GetAllFilesNameFromFolder("~/Controllers");
                foreach (string file in controllers)
                {
                    DeleteFile(System.IO.Path.Combine("~/Controllers/", file));
                }
                #endregion
            }
        }

        private static void DeleteDirectories(string path)
        {
            var viewsPath = HttpContext.Current.Server.MapPath(path);
            var dirs = System.IO.Directory.GetDirectories(viewsPath);

            foreach (string d in dirs)
            {
                if (System.IO.Directory.GetFiles(d).Count() == 0)
                {
                    System.IO.Directory.Delete(d);
                }
            }
        }

        private static void DeleteFiles(string path)
        {
            var viewsPath = HttpContext.Current.Server.MapPath(path);
            var dirs = System.IO.Directory.GetDirectories(viewsPath);

            foreach (string d in dirs)
            {
                var fs = System.IO.Directory.GetFiles(d);
                if (fs.Count() > 0)
                {
                    foreach (string file in fs)
                    {
                        System.IO.File.Delete(file);
                    }
                }
            }
        }

        private static void DeleteFile(string path)
        {
            System.IO.File.Delete(HttpContext.Current.Server.MapPath(path));
        }

    }
}