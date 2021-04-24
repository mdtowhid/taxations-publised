using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Taxations.Models
{
    [Table("Surcharges")]
    public class Surcharge
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string SurchargeValue { get; set; }
        public string SurchargePercentage { get; set; }
    }
}