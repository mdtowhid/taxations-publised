using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Taxations.Models
{
    [Table("Invesments")]
    public class Invesment
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        [Display(Name = "Invesment Name")]
        public string InvesmentName { get; set; }
        public Double Amount { get; set; }
        public bool Active { get; set; }
    }
}