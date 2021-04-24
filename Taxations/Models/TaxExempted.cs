using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Taxations.Models
{
    [Table("TaxExempteds")]
    public class TaxExempted
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string BasicPayTaxExempted { get; set; }
        public string SpecialPayTaxExempted { get; set; }
        public string ArrearPayTaxExempted { get; set; }
        public string DearnessAllowanceTaxExempted { get; set; }
        public string HouseRentAllowanceTaxExempted { get; set; }
        public string MedicalAllowanceTaxExempted { get; set; }
        public string ConveyanceAllowanceTaxExempted { get; set; }
        public string FestivalAllowanceTaxExempted { get; set; }
        public string AllowanceStaffTaxExempted { get; set; }
        public string LeaveAllowanceTaxExempted { get; set; }
        public string HonorariumTaxExempted { get; set; }
        public string OvertimeAllowanceExempted { get; set; }
        public string BonusExempted { get; set; }
        public string OtherAllowancesExempted { get; set; }
        public string EmployerContributionExempted { get; set; }
        public string InterestAccruedExempted { get; set; }
        public string DeemedIncomeTransportExempted { get; set; }
        public string DeemedIncomeFurnishedExempted { get; set; }
        public string OtherIfAnyExempted { get; set; }
    }
}