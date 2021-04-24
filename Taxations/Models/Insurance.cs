using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Taxations.Models
{
    [Table("Insurances")]
    public class Insurance
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public long Amount { get; set; }
        public string CompanyName { get; set; }
        public string Year { get; set; }
    }
}