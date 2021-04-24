using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Taxations.Dtos
{
    public class DPSInfo
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        [Required]
        [Display(Name="Bank Name")]
        public string BankName { get; set; }
        [Required]
        public string Amount { get; set; }
    }
}