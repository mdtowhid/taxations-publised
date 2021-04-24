using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Taxations.Models
{
    [Table("Users")]
    public class User
    {
        public long Id { get; set; }
        [Display(Name = "First Name"), Required]
        public string FirstName { get; set; }
        [Display(Name = "Last Name"), Required]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email Is Rrequied.")]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        [Remote("IsEmailExists", "Account", ErrorMessage = "Email already exists!")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        [Required]
        [MinLength(6, ErrorMessage = "Password must be six character long.")]
        public string Password { get; set; }
        [Display(Name = "Confirm Password"), Required, System.ComponentModel.DataAnnotations.Compare("Password")]
        [MinLength(6, ErrorMessage = "Password must be six character long.")]
        public string ConfirmPassword { get; set; }
        public bool IsEmailConfirmed { get; set; }
        public bool Active { get; set; }
        public string PhotoPath { get; set; }
        [Display(Name = "Employment Status"), Required]
        public string EmploymentStatus { get; set; }

        [Required]
        public string Gender { get; set; }

        public bool IsAutistc { get; set; }

        public string RecoveryCode { get; set; }

        public string Bio { get; set; }
        [Display(Name = "Who You Are")]
        public string WhoYouAre { get; set; }
    }
}