using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Taxations.Models
{
    [Table("StatementOfAssets")]
    public class StatementOfAsset
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        [Display(Name= "Assessment Year")]
        public string AssessmentYear { get; set; }
        [Display(Name = "Statement As On")]
        public string StatementAsOn { get; set; }
        [Display(Name = "Name Of Assessee")]
        public string NameOfAssessee { get; set;}
        public string TIN { get; set; }
        [Display(Name = "Business Capital")]
        public string BusinessCapital { get; set;}
        [Display(Name = "Business Capital")]
        public string BusinessCapital05A { get; set;}
        public string BusinessCapital05B { get; set; }
        [Display(Name = "Director Shareholdings InLimited Companies")]
        public string DirectorShareholdingsInLimitedCompanies05B { get; set;}
        [Display(Name = "Non Agricultural")]
        public string NonAgricultural06A { get; set;}
        [Display(Name = "Advance Made For Non Agricultural Property")]
        public string AdvanceMadeForNonAgriculturalProperty06B { get; set;}
        public string TotalOf06A06B { get; set; }
        [Display(Name = "Agricultural Property")]
        public string AgriculturalProperty07 { get; set;}
        [Display(Name = "Financial Assets Value")]
        public string FinancialAssetsValue08 { get; set;}
        [Display(Name = "Share Debentures")]
        public string ShareDebentures08A { get; set;}
        [Display(Name = "Savings Certificate")]
        public string SavingsCertificate08B { get; set;}
        [Display(Name = "Fixed Deposit")]
        public string FixedDeposit08C { get; set;}
        [Display(Name = "Loans Given To Others")]
        public string LoansGivenToOthers08D { get; set;}
        [Display(Name = "Other Financial Assets")]
        public string OtherFinancialAssets08D { get; set;}
        [Display(Name = "Motor Cars")]
        public string MotorCars09 { get; set;}
        [Display(Name = "Gold Diamond")]
        public string GoldDiamond10 { get; set;}
        [Display(Name = "Furniture Equipment And Electronic Items")]
        public string FurnitureEquipmentAndElectronicItems11 { get; set;}
        [Display(Name = "Other Assets Of Significant Value")]
        public string OtherAssetsOfSignificantValue12 { get; set;}
        [Display(Name = "Cash And Fund Outside Business")]
        public string CashAndFundOutsideBusiness { get; set;}
        [Display(Name = "Notes And Currencies")]
        public string NotesAndCurrencies13A { get; set;}
        [Display(Name = "Banks Cards And Other Electronic Cash")]
        public string BanksCardsAndOtherElectronicCash13B { get; set;}
        [Display(Name = "Provident Fund And Other Fund")]
        public string ProvidentFundAndOtherFund13C { get; set;}
        [Display(Name = "Other Deposit Balance And Advance")]
        public string OtherDepositBalanceAndAdvance13D { get; set;}
        [Display(Name = "Gross Wealth")]
        public string GrossWealth14 { get; set;}
        [Display(Name = "Liabilities Butside Busines")]
        public string LiabilitiesButsideBusines15 { get; set;}
        [Display(Name = "Borrowings From Banks")]
        public string BorrowingsFromBanks15A { get; set;}
        [Display(Name = "Unsecured Loan")]
        public string UnsecuredLoan15B { get; set;}
        [Display(Name = "Other Loans Or Overdrafts")]
        public string OtherLoansOrOverdrafts15C { get; set;}
        [Display(Name = "Net Wealth 16")]
        public string NetWealth16 { get; set;}
        [Display(Name = "Net Wealth 17")]
        public string NetWealth17 { get; set;}
        [Display(Name = "Change In 18")]
        public string ChangeIn18 { get; set;}
        [Display(Name = "Other Fund Outflow")]
        public string OtherFundOutflow19 { get; set;}
        [Display(Name = "Annual Living")]
        public string AnnualLiving19A { get; set;}
        [Display(Name = "Loss Deductions Expenses")]
        public string LossDeductionsExpenses19B { get; set;}
        [Display(Name = "Gift Donation")]
        public string GiftDonation19C { get; set;}
        [Display(Name = "Total Fund Outflow")]
        public string TotalFundOutflow20 { get; set;}
        [Display(Name = "Sources Of Fund")]
        public string SourcesOfFund21 { get; set;}
        [Display(Name = "Income Shown")]
        public string IncomeShown21A { get; set;}
        [Display(Name = "Tax Exempted")]
        public string TaxExempted21B { get; set;}
        [Display(Name = "Other Receipts")]
        public string OtherReceipts21C { get; set;}
        [Display(Name = "Shortage Of Fund")]
        public string ShortageOfFund22 { get; set;}
        [Display(Name = "Name")]
        public string SecondPageName { get; set;}
        [Display(Name = "Image")]
        public string SecondPagePhotoPath { get; set;}
        [Display(Name = "Name")]
        public string ThirdPageName { get; set;}
        [Display(Name = "Image")]
        public string ThirdPagePhtotPath { get; set; }
        public bool Active { get; set; }
		
        [Display(Name= "Employeement Status")]
        public string EmployeementStatus { get; set; }
        public bool IsPrevYearCalculated { get; set; }
    }
}