using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Taxations.BusinessLogic;
using Taxations.Models;

namespace Taxations.Models.EditViewModels
{
    public class EditBasicInformationViewModel
    {
        public static BasicInformation EditBasicInformation(BasicInformation model, BasicInformation exixstBasicInformationModel)
        {
            exixstBasicInformationModel.AdditionalColumn = model.AdditionalColumn;
            exixstBasicInformationModel.AdjustmentOfTaxRefund = model.AdjustmentOfTaxRefund;
            exixstBasicInformationModel.AdvanceTaxPaid = model.AdvanceTaxPaid;
            exixstBasicInformationModel.AgriculturalIncome = model.AgriculturalIncome;
            exixstBasicInformationModel.AmountPaidWithReturn = model.AmountPaidWithReturn;
            exixstBasicInformationModel.AreYouRequiredToSubmitStatementOfAssets = model.AreYouRequiredToSubmitStatementOfAssets;

            exixstBasicInformationModel.AssessmentYear = model.AssessmentYear;

            exixstBasicInformationModel.BIN = model.BIN;
            exixstBasicInformationModel.CapitalGains = model.CapitalGains;
            exixstBasicInformationModel.Circle = model.Circle;
            exixstBasicInformationModel.ContactTelephone = model.ContactTelephone;

            exixstBasicInformationModel.DateOfBirth = model.DateOfBirth;

            exixstBasicInformationModel.DateOfSignature = model.DateOfSignature;
            exixstBasicInformationModel.DateOfSubmition = model.DateOfSubmition;


            exixstBasicInformationModel.DeficitOrExcess = model.DeficitOrExcess;
            exixstBasicInformationModel.Email = model.Email;
            exixstBasicInformationModel.EmployerName = model.EmployerName;
            exixstBasicInformationModel.FatherName = model.FatherName;
            exixstBasicInformationModel.ForeignIncome = model.ForeignIncome;
            exixstBasicInformationModel.Gender = model.Gender;
            exixstBasicInformationModel.GrossTaxBeforeTaxRebate = model.GrossTaxBeforeTaxRebate;
            exixstBasicInformationModel.IncomeFromBusinessOrProfession = model.IncomeFromBusinessOrProfession;
            exixstBasicInformationModel.IncomeFromHouseProperty = model.IncomeFromHouseProperty;
            exixstBasicInformationModel.IncomeFromOtherSources = model.IncomeFromOtherSources;
            exixstBasicInformationModel.IncomeOfMinor = model.IncomeOfMinor;
            exixstBasicInformationModel.InterestOnSecurities = model.InterestOnSecurities;
            exixstBasicInformationModel.InterestOrOrdinance = model.InterestOrOrdinance;
            exixstBasicInformationModel.IsParentOfPersonWithDisability = model.IsParentOfPersonWithDisability;
            exixstBasicInformationModel.MinimumTax = model.MinimumTax;
            exixstBasicInformationModel.MotherName = model.MotherName;
            exixstBasicInformationModel.Name = model.Name;
            exixstBasicInformationModel.NameOfAssessee = model.NameOfAssessee;
            exixstBasicInformationModel.NetTaxAfterTaxRebate = model.NetTaxAfterTaxRebate;
            exixstBasicInformationModel.NetWealthSurcharge = model.NetWealthSurcharge;
            exixstBasicInformationModel.NewTIN = model.NewTIN;
            exixstBasicInformationModel.NID = model.NID;
            exixstBasicInformationModel.OldTIN = model.OldTIN;
            exixstBasicInformationModel.OtherStatementsDocuments = model.OtherStatementsDocuments;
            exixstBasicInformationModel.PermanentAddress = model.PermanentAddress;
            exixstBasicInformationModel.PlaceOfSignatur = model.PlaceOfSignatur;
            exixstBasicInformationModel.PresentAddress = model.PresentAddress;
            exixstBasicInformationModel.ResidentStatus = model.ResidentStatus;
            exixstBasicInformationModel.ReturnSubmitted = model.ReturnSubmitted;
            exixstBasicInformationModel.Salaries = model.Salaries;
            exixstBasicInformationModel.SchedulesAnnexed = model.SchedulesAnnexed;
            exixstBasicInformationModel.ShareOfIncomeFromFirmOrAOP = model.ShareOfIncomeFromFirmOrAOP;
            exixstBasicInformationModel.Signature = model.Signature;
            exixstBasicInformationModel.SpouseName = model.SpouseName;
            exixstBasicInformationModel.SpouseTIN = model.SpouseTIN;
            exixstBasicInformationModel.StatementsAnnexed = model.StatementsAnnexed;
            exixstBasicInformationModel.TaxDeducted = model.TaxDeducted;
            exixstBasicInformationModel.TaxExemptedIncome = model.TaxExemptedIncome;
            exixstBasicInformationModel.TaxOfficeEntryNumber = model.TaxOfficeEntryNumber;
            exixstBasicInformationModel.TaxRebate = model.TaxRebate;
            exixstBasicInformationModel.TickOnBoxes = model.TickOnBoxes;
            exixstBasicInformationModel.TotalAmountPaidAndAdjusted = model.TotalAmountPaidAndAdjusted;
            exixstBasicInformationModel.TotalAmountPayable = model.TotalAmountPayable;
            exixstBasicInformationModel.TotalIncome = model.TotalIncome;
            exixstBasicInformationModel.UserId = model.UserId;
            exixstBasicInformationModel.YearFrom = model.YearFrom;
            exixstBasicInformationModel.YearTo = model.YearTo;
            exixstBasicInformationModel.Zone = model.Zone;

            return exixstBasicInformationModel;
        }
    }
}