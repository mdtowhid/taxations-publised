using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Taxations.Models
{
    [Table("ParticularsOfTaxCredits")]
    public class ParticularsOfTaxCredit
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        [Display(Name= "Assessment Year")]
        public string AssessmentYear { get; set; }
        public string TIN { get; set; }
        [Display(Name= "Life Insurance")]
        public string LifeInsurance { get; set; }
        [Display(Name = "Contribution To Deposit")]
        public string ContributionToDeposit { get; set; }
        [Display(Name= "Investment In Approved Savings")]
        public string InvestmentInApprovedSavings { get; set; }
        [Display(Name= "Investment In Approved Debenture")]
        public string InvestmentInApprovedDebenture { get; set; }
        [Display(Name= "Contribution To Provident Fund")]
        public string ContributionToProvidentFund { get; set; }
        [Display(Name= "Self Contribution And Employer")]
        public string SelfContributionAndEmployer { get; set; }
        [Display(Name= "Contribution To Super Annuation Fund")]
        public string ContributionToSuperAnnuationFund { get; set; }
        [Display(Name= "Contribution To Benevolent Fund")]
        public string ContributionToBenevolentFund { get; set; }
        [Display(Name= "Contribution To Zakat Fund")]
        public string ContributionToZakatFund { get; set; }
        [Display(Name= "Others If Any")]
        public string OthersIfAny { get; set; }
        [Display(Name= "Total Allowable Investment")]
        public string TotalAllowableInvestment { get; set; }
        [Display(Name= "Eligible Amount For Rebate")]
        public string EligibleAmountForRebate { get; set; }
        [Display(Name= "Total Allowable Investment Contribution")]
        public string TotalAllowableInvestmentContribution { get; set; }
        [Display(Name= "Total Income")]
        public string TotalIncome14B { get; set; }
        [Display(Name= "Crore")]
        public string Crore14C { get; set; }
        [Display(Name = "Amount Of Tax Rebate Calculated")]
        public string AmountOfTaxRebateCalculated { get; set; }
        public string Name { get; set; }
        [Display(Name= "Signature And Date Photo")]
        public string SignatureAndDatePhoto { get; set; }
		
        [Display(Name= "Employeement Status")]
        public string EmployeementStatus { get; set; }
    }
}
