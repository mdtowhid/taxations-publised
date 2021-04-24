using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Taxations.Models
{
    [Table("TotalInfoes")]
    public class TotalInfo
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string Assets { get; set; }
        public string Expenses { get; set; }
        public string Slaries { get; set; }
        public string TaxCredit { get; set; }
        public string Investment { get; set; }
        public string Rebate { get; set; }
        public string Others { get; set; }
        public string Income { get; set; }
    }
}