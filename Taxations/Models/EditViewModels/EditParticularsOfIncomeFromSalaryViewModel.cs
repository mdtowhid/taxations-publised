using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Taxations.Models.EditViewModels
{
    public class EditParticularsOfIncomeFromSalaryViewModel
    {
        public static ParticularsOfIncomeFromSalary UpdateParticularsOfIncomeFromSalary(ParticularsOfIncomeFromSalary model, ParticularsOfIncomeFromSalary updatingModel)
        {
            updatingModel.AllowanceStaffTaxable = model.AllowanceStaffTaxable;
            updatingModel.ArrearPayTaxable = model.ArrearPayTaxable;
            updatingModel.AssessmentYear = model.AssessmentYear;
            updatingModel.BasicPayTaxable = model.BasicPayTaxable;
            updatingModel.BonusTaxable = model.BonusTaxable;
            updatingModel.ConveyanceAllowanceTaxable = model.ConveyanceAllowanceTaxable;
            updatingModel.DearnessAllowanceTaxable = model.DearnessAllowanceTaxable;
            updatingModel.DeemedIncomeTransportTaxable = model.DeemedIncomeTransportTaxable;
            updatingModel.EmployerContributionTaxable = model.EmployerContributionTaxable;
            updatingModel.FestivalAllowanceTaxable = model.FestivalAllowanceTaxable;
            updatingModel.HonorariumTaxable = model.HonorariumTaxable;
            updatingModel.HouseRentAllowanceTaxable = model.HouseRentAllowanceTaxable;
            updatingModel.InterestAccruedTaxable = model.InterestAccruedTaxable;
            updatingModel.LeaveAllowanceTaxable = model.LeaveAllowanceTaxable;
            updatingModel.MedicalAllowanceTaxable = model.MedicalAllowanceTaxable;
            updatingModel.OtherAllowancesTaxable = model.OtherAllowancesTaxable;
            updatingModel.OtherIfAny = model.OtherIfAny;
            updatingModel.OvertimeAllowanceTaxable = model.OvertimeAllowanceTaxable;
            updatingModel.PhotoPath = model.PhotoPath;
            updatingModel.SpecialPayTaxable = model.SpecialPayTaxable;
            updatingModel.TIN = model.TIN;
            updatingModel.Total = model.Total;
            updatingModel.Name = model.Name;
            updatingModel.DeemedIncomeFurnishedTaxable = model.DeemedIncomeFurnishedTaxable;
            updatingModel.OtherIfAny = model.OtherIfAny;
            updatingModel.TotalTaxExempted = model.TotalTaxExempted;
            updatingModel.GrossTaxBeforeTaxRebate = model.GrossTaxBeforeTaxRebate;
            updatingModel.GrossTaxBeforeTaxRebateMaxPercentage = model.GrossTaxBeforeTaxRebateMaxPercentage;

            return updatingModel;
        }
    }
}