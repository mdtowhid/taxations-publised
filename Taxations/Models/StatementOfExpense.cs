using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Taxations.Models
{
    [Table("StatementOfExpenses")]
    public class StatementOfExpense
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        [Display(Name= "Assessment Year")]
        public string AssessmentYear { get; set; }
        public string StatementDate { get; set; }
        public string NameOfAssessee { get; set; }
        public string TIN { get; set; }


        public string AgriculturalProperty { get; set; }
        public string HousingExpense { get; set; }
        public string AutoAndTransportationExpenses07A08B { get; set; }
        public string DriverSalary07A { get; set; }
        public string OtherTransportation { get; set; }
        public string HouseholdAndUtilityExpenses08A08B08C08D { get; set; }
        public string Electricity08A { get; set; }
        public string GasWaterSewerAndGarbage08B { get; set; }
        public string PhoneInternet08C { get; set; }
        public string HomeSupport08D { get; set; }
        public string ChildrenEducation { get; set; }
        public string SpecialExpenses10A10B10C10D { get; set; }
        public string FestivalParty10A { get; set; }
        public string DomesticAndOverseasTour10B { get; set; }
        public string Donation10C { get; set; }
        public string OtherSpecialExpenses10D { get; set; }
        public string AnyOtherExpenses { get; set; }
        public string TotalExpenseRelating { get; set; }
        public string PaymentOfTax13A13B { get; set; }
        public string PaymentOfTax13A { get; set; }
        public string PaymentOfTax13B { get; set; }
        public string TotalAmountOfExpense { get; set; }
        public string Name { get; set; }
        public string SignatureAndDatePhotoPath { get; set; }
		
        [Display(Name= "Employeement Status")]
        public string EmployeementStatus { get; set; }
        public string Total { get; set; }
    }
}