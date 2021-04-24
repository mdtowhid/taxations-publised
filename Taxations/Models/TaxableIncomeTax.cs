using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Taxations.Models
{
    public class TaxableIncomeTax
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string TaxableIncome { get; set; }
        public string TaxRate { get; set; }
        public string NetTax { get; set; }
    }
}