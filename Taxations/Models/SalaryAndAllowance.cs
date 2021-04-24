using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Taxations.Models
{
    [Table("SalaryAndAllowances")]
    public class SalaryAndAllowance
    {
        public long Id { get; set; }
        public string SalaryAndAllowanceName { get; set; }
        public bool Active { get; set; }
    }
}