using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Taxations.Models
{
    [Table("Incomes")]
    public class Income
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        [Display(Name = "Income")]
        public string TotalIncome { get; set; }
        [Display(Name = "Tax Free Income")]
        public string TotalTaxFreeIncome { get; set; }
        [Display(Name = "Taxable Income")]
        public string TotalTaxableIncome { get; set; }
        public bool IsActive { get; set; }

    }
}