using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Taxations.Models
{
    [Table("Admins")]
    public class Admin
    {
        public long Id { get; set; }
        [Display(Name= "User Name")]
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }
        [Display(Name = "Admin Type")]
        public string AdminType { get; set; }
        public bool IsActive { get; set; }
    }
}