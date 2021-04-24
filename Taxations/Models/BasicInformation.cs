using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Taxations.Models
{
    [Table("BasicInformations")]
    public class BasicInformation
    {

        /*
         *:::
         *:::-------> Step One Model
         *::: 
         *:::
        */

        public long Id { get; set; }
        public long UserId { get; set; }
        [Display(Name= "Assessment Year")]
        public string AssessmentYear { get; set; }
        [Display(Name= "Return Submitted")]
        public string ReturnSubmitted { get; set; }
        [Display(Name = "Name Of Assessee")]
        public string NameOfAssessee { get; set; }
        public string Gender { get; set; }
        [Display(Name= "New TIN")]
        public string NewTIN { get; set; }
        [Display(Name= "Old TIN")]
        public string OldTIN { get; set; }
        public string Circle { get; set; }
        public string Zone { get; set; }
        [Display(Name= "Resident Status")]
        public string ResidentStatus { get; set; }
        [Display(Name= "Tick On Boxes")]
        public string TickOnBoxes { get; set; }
        [Display(Name= "Date Of Birth")]
        public string DateOfBirth { get; set; }
        [Display(Name= "Year From")]
        public string YearFrom { get; set; }
        [Display(Name= "Year To")]
        public string YearTo { get; set; }
        [Display(Name= "EmployerName")]
        public string EmployerName { get; set; }
        [Display(Name= "Spouse Name")]
        public string SpouseName { get; set; }
        [Display(Name= "Spouse TIN")]
        public string SpouseTIN { get; set; }
        [Display(Name= "Father Name")]
        public string FatherName { get; set; }
        [Display(Name= "MotherName")]
        public string MotherName { get; set; }
        [Display(Name= "Present Address")]
        public string PresentAddress { get; set; }
        [Display(Name= "Permanent Address")]
        public string PermanentAddress { get; set; }
        [Display(Name= "Contact Telephone")]
        public string ContactTelephone { get; set; }

        [EmailAddress(ErrorMessage = "Invalid Email")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }
        public string NID { get; set; }
        public string BIN { get; set; }



        /*
         *:::
         *::: Step Two Model
         *:::
         *:::
        */


        public string Salaries { get; set; }
        [Display(Name= "Interest On Securities")]
        public string InterestOnSecurities { get; set; }
        [Display(Name= "Income FromHouse Property")]

        public string IncomeFromHouseProperty { get; set; }
        [Display(Name= "Agricultural Income")]
        public string AgriculturalIncome { get; set; }
        [Display(Name= "Income From Business Or Profession")]
        public string IncomeFromBusinessOrProfession { get; set; }
        [Display(Name= "Capital Gains")]

        public string CapitalGains { get; set; }
        [Display(Name= "Income From Other Sources")]
        public string IncomeFromOtherSources { get; set; }
        [Display(Name= "Share Of Income From Firm Or AOP")]
        public string ShareOfIncomeFromFirmOrAOP { get; set; }
        [Display(Name= "Income Of Minor")]
        public string IncomeOfMinor { get; set; }
        [Display(Name= "Foreign Income")]
        public string ForeignIncome { get; set; }
        [Display(Name= "Total Income")]
        public string TotalIncome { get; set; }
        [Display(Name= "Gross Tax Before Tax Rebate")]
        public string GrossTaxBeforeTaxRebate { get; set; }
        [Display(Name= "Tax Rebate")]
        public string TaxRebate { get; set; }
        [Display(Name= "Net Tax After Tax Rebate")]
        public string NetTaxAfterTaxRebate { get; set; }
        [Display(Name= "Minimum Tax")]
        public string MinimumTax { get; set; }
        [Display(Name= "Net Wealth Surcharge")]
        public string NetWealthSurcharge { get; set; }
        [Display(Name= "Interest Or Ordinance")]
        public string InterestOrOrdinance { get; set; }
        [Display(Name= "Total Amount Payable")]
        public string TotalAmountPayable { get; set; }
        [Display(Name= "Tax Deducted")]
        public string TaxDeducted { get; set; }
        [Display(Name= "Advance Tax Paid")]
        public string AdvanceTaxPaid { get; set; }
        [Display(Name= "Adjustment Of Tax Refund")]
        public string AdjustmentOfTaxRefund { get; set; }
        [Display(Name= "Amount Paid With Return")]
        public string AmountPaidWithReturn { get; set; }
        [Display(Name= "Total Amount Paid And Adjusted")]
        public string TotalAmountPaidAndAdjusted { get; set; }
        [Display(Name= "Deficit Or Excess")]
        public string DeficitOrExcess { get; set; }
        [Display(Name= "Tax Exempted Income")]
        public string TaxExemptedIncome { get; set; }







        /*
         *:::
         *::: Step Three Model
         *:::
         *:::
        */

        
        [Display(Name= "Is Parent Of Person With Disability")]
        public string IsParentOfPersonWithDisability { get; set; }
        [Display(Name = "Are You Required To Submit Statement Of Assets")]
        public string AreYouRequiredToSubmitStatementOfAssets { get; set; }
        [Display(Name= "Schedules Annexed")]
        public string SchedulesAnnexed { get; set; }
        [Display(Name= "Statements Annexed")]
        public string StatementsAnnexed { get; set; }
        [Display(Name= "Other Statements Documents")]
        public string OtherStatementsDocuments { get; set; }
        public string Name { get; set; }
        public string Signature { get; set; }
        [Display(Name= "Date Of Signature")]
        public string DateOfSignature { get; set; }
        [Display(Name= "Place Of Signatur")]
        public string PlaceOfSignatur { get; set; }
        [Display(Name= "Date Of Submition")]
        public string DateOfSubmition { get; set; }
        [Display(Name= "Tax Office EntryNumber")]
        public string TaxOfficeEntryNumber { get; set; }
        [Display(Name= "Additional Column")]
        public string AdditionalColumn { get; set; }
		
        [Display(Name= "Employeement Status")]
        public string EmployeementStatus { get; set; }
    }
}