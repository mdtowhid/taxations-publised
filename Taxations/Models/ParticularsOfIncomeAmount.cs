using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Taxations.Models
{
    [Table("ParticularsOfIncomeAmounts")]
    public class ParticularsOfIncomeAmount
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string BasicPay { get; set; }
        public string SpecialPay { get; set; }
        public string ArrearPay { get; set; }
        public string DearnessAllowance { get; set; }
        public string HouseRentAllowance { get; set; }
        public string MedicalAllowance { get; set; }
        public string ConveyanceAllowance { get; set; }
        public string FestivalAllowance { get; set; }
        public string AllowanceStaff { get; set; }
        public string LeaveAllowance { get; set; }
        public string HonorariumAmount { get; set; }
        public string OvertimeAllowance { get; set; }
        public string BonusAmount { get; set; }
        public string OtherAllowances { get; set; }
        public string EmployerContribution { get; set; }
        public string InterestAccrued { get; set; }
        public string DeemedIncomeTransport { get; set; }
        public string DeemedIncomeFurnished { get; set; }
        public string OtherIfAny { get; set; }
        public string AmountTotal { get; set; }
    }
}