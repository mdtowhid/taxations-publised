using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Taxations.Models
{
    [Table("RebateCalculations")]
    public class RebateCalculation
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string ActualInvestment { get; set; }
        public Double Amount { get; set; }
        public bool Active { get; set; }
    }
}