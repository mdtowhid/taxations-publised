using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Taxations.Models
{
    [Table("FinalCalculations")]
    public class FinalCalculation
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string PayableTax { get; set; }
        public string RebateOnInvestment { get; set; }
        public string TaxPayable { get; set; }
        public string Surcharge { get; set; }
        public string DeductedSource { get; set; }
        public string DeductedSourceBank { get; set; }
        public string NetPayableTax { get; set; }
    }
}