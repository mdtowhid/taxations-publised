using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Taxations.Models.EditViewModels
{
    public class EditParticularsOfAmountViewModel
    {
        public static ParticularsOfIncomeAmount ParticularsOfAmount(
            ParticularsOfIncomeAmount model, ParticularsOfIncomeAmount updatingModel)
        {
            updatingModel.AllowanceStaff = model.AllowanceStaff;
            updatingModel.ArrearPay = model.ArrearPay;
            updatingModel.BasicPay = model.BasicPay;
            updatingModel.BonusAmount = model.BonusAmount;
            updatingModel.ConveyanceAllowance = model.ConveyanceAllowance;
            updatingModel.DearnessAllowance = model.DearnessAllowance;
            updatingModel.DeemedIncomeFurnished = model.DeemedIncomeFurnished;
            updatingModel.DeemedIncomeTransport = model.DeemedIncomeTransport;
            updatingModel.EmployerContribution = model.EmployerContribution;
            updatingModel.FestivalAllowance = model.FestivalAllowance;
            updatingModel.HonorariumAmount = model.HonorariumAmount;
            updatingModel.HouseRentAllowance = model.HouseRentAllowance;
            updatingModel.InterestAccrued = model.InterestAccrued;
            updatingModel.LeaveAllowance = model.LeaveAllowance;
            updatingModel.MedicalAllowance = model.MedicalAllowance;
            updatingModel.OtherAllowances = model.OtherAllowances;
            updatingModel.OtherIfAny = model.OtherIfAny;
            updatingModel.OvertimeAllowance = model.OvertimeAllowance;
            updatingModel.SpecialPay = model.SpecialPay;
            updatingModel.AmountTotal = model.AmountTotal;

            return updatingModel;
        }
    }
}