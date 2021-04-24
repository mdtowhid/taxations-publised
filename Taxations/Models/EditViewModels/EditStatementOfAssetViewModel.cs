using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Taxations.Models.EditViewModels
{
    public class EditStatementOfAssetViewModel
    {
        public static StatementOfAsset EditStatementOfAsset(StatementOfAsset model, StatementOfAsset updatingModel)
        {
            updatingModel.Active = model.Active;
            updatingModel.AdvanceMadeForNonAgriculturalProperty06B = model.AdvanceMadeForNonAgriculturalProperty06B;
            updatingModel.AgriculturalProperty07 = model.AgriculturalProperty07;
            updatingModel.AnnualLiving19A = model.AnnualLiving19A;
            updatingModel.AssessmentYear = model.AssessmentYear;
            updatingModel.BanksCardsAndOtherElectronicCash13B = model.BanksCardsAndOtherElectronicCash13B;
            updatingModel.BorrowingsFromBanks15A = model.BorrowingsFromBanks15A;
            updatingModel.BusinessCapital = model.BusinessCapital;
            updatingModel.BusinessCapital05A = model.BusinessCapital05A;
            updatingModel.BusinessCapital05B = model.BusinessCapital05B;
            updatingModel.CashAndFundOutsideBusiness = model.CashAndFundOutsideBusiness;
            updatingModel.ChangeIn18 = model.ChangeIn18;
            updatingModel.DirectorShareholdingsInLimitedCompanies05B = model.DirectorShareholdingsInLimitedCompanies05B;
            updatingModel.FinancialAssetsValue08 = model.FinancialAssetsValue08;
            updatingModel.FixedDeposit08C = model.FixedDeposit08C;
            updatingModel.FurnitureEquipmentAndElectronicItems11 = model.FurnitureEquipmentAndElectronicItems11;
            updatingModel.GiftDonation19C = model.GiftDonation19C;
            updatingModel.GoldDiamond10 = model.GoldDiamond10;
            updatingModel.GrossWealth14 = model.GrossWealth14;
            updatingModel.IncomeShown21A = model.IncomeShown21A;
            updatingModel.LiabilitiesButsideBusines15 = model.LiabilitiesButsideBusines15;
            updatingModel.LoansGivenToOthers08D = model.LoansGivenToOthers08D;
            updatingModel.LossDeductionsExpenses19B = model.LossDeductionsExpenses19B;
            updatingModel.MotorCars09 = model.MotorCars09;
            updatingModel.NameOfAssessee = model.NameOfAssessee;
            updatingModel.NetWealth16 = model.NetWealth16;
            updatingModel.NetWealth17 = model.NetWealth17;
            updatingModel.NonAgricultural06A = model.NonAgricultural06A;
            updatingModel.NotesAndCurrencies13A = model.NotesAndCurrencies13A;
            updatingModel.OtherAssetsOfSignificantValue12 = model.OtherAssetsOfSignificantValue12;
            updatingModel.OtherDepositBalanceAndAdvance13D = model.OtherDepositBalanceAndAdvance13D;
            updatingModel.OtherFinancialAssets08D = model.OtherFinancialAssets08D;
            updatingModel.OtherFundOutflow19 = model.OtherFundOutflow19;
            updatingModel.OtherLoansOrOverdrafts15C = model.OtherLoansOrOverdrafts15C;
            updatingModel.OtherReceipts21C = model.OtherReceipts21C;
            updatingModel.ProvidentFundAndOtherFund13C = model.ProvidentFundAndOtherFund13C;
            updatingModel.SavingsCertificate08B = model.SavingsCertificate08B;
            updatingModel.SecondPageName = model.SecondPageName;
            updatingModel.SecondPagePhotoPath = model.SecondPagePhotoPath;
            updatingModel.ShareDebentures08A = model.ShareDebentures08A;
            updatingModel.ShortageOfFund22 = model.ShortageOfFund22;
            updatingModel.SourcesOfFund21 = model.SourcesOfFund21;
            updatingModel.StatementAsOn = model.StatementAsOn;
            updatingModel.TaxExempted21B = model.TaxExempted21B;
            updatingModel.ThirdPageName = model.ThirdPageName;
            updatingModel.ThirdPagePhtotPath = model.ThirdPagePhtotPath;
            updatingModel.TIN = model.TIN;
            updatingModel.TotalFundOutflow20 = model.TotalFundOutflow20;
            updatingModel.UnsecuredLoan15B = model.UnsecuredLoan15B;
            updatingModel.UserId = model.UserId;
            updatingModel.TotalOf06A06B = model.TotalOf06A06B;
            updatingModel.IsPrevYearCalculated = model.IsPrevYearCalculated;

            return updatingModel;
        }
    }
}