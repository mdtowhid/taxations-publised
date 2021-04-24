using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Taxations.Dtos
{
    public class PasswordRecoveryDto
    {
        [Required(ErrorMessage ="User id must be required.")]
        public int UserId { get; set; }
        [Required, MinLength(6, ErrorMessage ="Password must be six characters required.")]
        public string Password { get; set; }
        [Required, MinLength(6, ErrorMessage = "Confirm Password must be six characters required.")]
        [Compare("Password", ErrorMessage = "Password and confirm password doesn't matched.")]
        public string ConfirmPassword { get; set; }
        public string RecoveryCode { get; set; }
    }
}