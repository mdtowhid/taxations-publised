using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Taxations.Models
{
    [Table("ParticularsOfIncomeFromSalaries")]
    public class ParticularsOfIncomeFromSalary
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        [Display(Name= "Assessment Year")]
        public string AssessmentYear { get; set; }
        public string TIN { get; set; }
        [Display(Name= "Basic Pay")]
        public string BasicPayTaxable { get; set; }
        [Display(Name = "Special Pay")]
        public string SpecialPayTaxable { get; set; }
        [Display(Name= "Arrear Pay")]
        public string ArrearPayTaxable { get; set; }
        [Display(Name= "Dearness Allowance")]
        public string DearnessAllowanceTaxable { get; set; }
        [Display(Name= "House Rent Allowance")]
        public string HouseRentAllowanceTaxable { get; set; }
        [Display(Name= "Medical Allowance")]
        public string MedicalAllowanceTaxable { get; set; }
        [Display(Name= "Conveyance Allowance")]
        public string ConveyanceAllowanceTaxable { get; set; }
        [Display(Name= "Festival Allowance")]
        public string FestivalAllowanceTaxable { get; set; }
        [Display(Name= "Allowance Staff")]
        public string AllowanceStaffTaxable { get; set; }
        [Display(Name= "Leave Allowance")]
        public string LeaveAllowanceTaxable { get; set; }
        [Display(Name= "Honorarium")]
        public string HonorariumTaxable { get; set; }
        [Display(Name= "Overtime Allowance")]
        public string OvertimeAllowanceTaxable { get; set; }
        [Display(Name= "Bonus")]
        public string BonusTaxable { get; set; }
        [Display(Name= "Other Allowances")]
        public string OtherAllowancesTaxable { get; set; }
        [Display(Name= "Employer Contribution")]
        public string EmployerContributionTaxable { get; set; }
        [Display(Name= "Interest Accrued")]
        public string InterestAccruedTaxable { get; set; }
        [Display(Name= "Deemed Income Transport")]
        public string DeemedIncomeTransportTaxable { get; set; }
        [Display(Name= "Deemed Income Furnished")]
        public string DeemedIncomeFurnishedTaxable { get; set; }
        [Display(Name= "Other If Any")]
        public string OtherIfAny { get; set; }
        public string Name { get; set; }
        public string Total { get; set; }
        [Display(Name="Image")]
        public string PhotoPath { get; set; }
		
        [Display(Name= "Employeement Status")]
        public string EmployeementStatus { get; set; }
        public string TotalTaxExempted { get; set; }

        public string GrossTaxBeforeTaxRebate { get; set; }
        public string GrossTaxBeforeTaxRebateMaxPercentage { get; set; }
        public string TotalSurcharge { get; set; }
        public string SurchargePercentage { get; set; }
    }
}