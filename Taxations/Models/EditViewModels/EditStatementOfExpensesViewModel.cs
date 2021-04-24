using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Taxations.Models.EditViewModels
{
    public class EditStatementOfExpensesViewModel
    {
        public static StatementOfExpense EditStatementOfExpenses(StatementOfExpense model, StatementOfExpense updatingModel)
        {

            updatingModel.AgriculturalProperty = model.AgriculturalProperty;
            updatingModel.AnyOtherExpenses = model.AnyOtherExpenses;
            updatingModel.AssessmentYear = model.AssessmentYear;
            updatingModel.AutoAndTransportationExpenses07A08B = model.AutoAndTransportationExpenses07A08B;
            updatingModel.ChildrenEducation = model.ChildrenEducation;
            updatingModel.DomesticAndOverseasTour10B = model.DomesticAndOverseasTour10B;
            updatingModel.Donation10C = model.Donation10C;
            updatingModel.DriverSalary07A = model.DriverSalary07A;
            updatingModel.Electricity08A = model.Electricity08A;
            updatingModel.FestivalParty10A = model.FestivalParty10A;
            updatingModel.GasWaterSewerAndGarbage08B = model.GasWaterSewerAndGarbage08B;
            updatingModel.HomeSupport08D = model.HomeSupport08D;
            updatingModel.HouseholdAndUtilityExpenses08A08B08C08D = model.HouseholdAndUtilityExpenses08A08B08C08D;
            updatingModel.HousingExpense = model.HousingExpense;
            updatingModel.Name = model.Name;
            updatingModel.NameOfAssessee = model.NameOfAssessee;
            updatingModel.OtherSpecialExpenses10D = model.OtherSpecialExpenses10D;
            updatingModel.OtherTransportation = model.OtherTransportation;
            updatingModel.PaymentOfTax13A = model.PaymentOfTax13A;

            updatingModel.PaymentOfTax13A13B = model.PaymentOfTax13A13B;
            updatingModel.PaymentOfTax13B = model.PaymentOfTax13B;

            updatingModel.PhoneInternet08C = model.PhoneInternet08C;
            updatingModel.SignatureAndDatePhotoPath = model.SignatureAndDatePhotoPath;
            updatingModel.SpecialExpenses10A10B10C10D = model.SpecialExpenses10A10B10C10D;
            updatingModel.StatementDate = model.StatementDate;
            updatingModel.TIN = model.TIN;
            updatingModel.TotalAmountOfExpense = model.TotalAmountOfExpense;
            updatingModel.TotalExpenseRelating = model.TotalExpenseRelating;
            updatingModel.Total = model.Total;
            return updatingModel;
        }
    }
}