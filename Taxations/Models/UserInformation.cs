using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Taxations.Models
{
    [Table("UserInformations")]
    public class UserInformation
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        [Display(Name = "Assessment Year"), Required]
        public string AssessmentYear { get; set; }

        [Display(Name = "Name Of Assessee"), Required]
        public string NameOfAssessee { get; set; }
        [Required]
        public string Gender { get; set; }
        [
            MinLength(12, ErrorMessage = "New TIN 12 characters long."),
            MaxLength(12, ErrorMessage = "New TIN 12 characters long.")
        ]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "New TIN must be 12 characters long digit")]
        [Display(Name = "New TIN")]
        [Required(ErrorMessage = "New TIN must be required.")]
        public string NewTIN { get; set; }
        [
            MinLength(10, ErrorMessage = "Old TIN 10 characters long."),
            MaxLength(10, ErrorMessage = "Old TIN 10 characters long.")
        ]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Old TIN must be 10 characters long digit.")]
        [Display(Name = "Old TIN")]
        public string OldTIN { get; set; }
        [Required]
        public string Circle { get; set; }
        [Required]
        public string Zone { get; set; }
        [Display(Name = "Tick On Boxes")]
        public string TickOnBoxes { get; set; }
        [Display(Name = "Date Of Birth"), Required(ErrorMessage = "Date of birth is required.")]
        public string DateOfBirth { get; set; }
        [Display(Name = "Income Year From")]
        [Required]
        [MinLength(4, ErrorMessage = "Income year from must be 4 digits long")]
        [MaxLength(4, ErrorMessage = "Income year from must be 4 digits long")]
        public string IncomeYearFrom { get; set; }
        [Display(Name = "Income Year To")]
        [Required]
        [MinLength(4, ErrorMessage = "Income year to must be 4 digits long")]
        [MaxLength(4, ErrorMessage = "Income year to must be 4 digits long")]

        public string IncomeYearTo { get; set; }
        [Display(Name = "Employer Name")]
        [Required]
        public string EmployerName { get; set; }
        [Display(Name = "Spouse Name")]
        public string SpouseName { get; set; }
        [MinLength(13), MaxLength(13)]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Spouse TIN must be 13 characters long digit")]
        [Display(Name = "Spouse TIN")]
        public string SpouseTIN { get; set; }
        [Display(Name = "Father Name")]
        [Required]
        public string FatherName { get; set; }
        [Required]
        [Display(Name = "Mother Name")]
        public string MotherName { get; set; }
        [Display(Name = "Present Address")]
        [Required]
        public string PresentAddress { get; set; }
        [Display(Name = "Permanent Address")]
        [Required]
        public string PermanentAddress { get; set; }
        [Required]
        [RegularExpression("^01[0-9]{9}$", ErrorMessage = "Invalid Phone Number.")]
        public string ContactTelephone { get; set; }
        [EmailAddress(ErrorMessage = "Invalid Email")]
        [Required]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }
        [Required]
        public string NID { get; set; }
        public string BIN { get; set; }

        [Display(Name = "Return Submitted")]
        public string ReturnSubmitted { get; set; }
        [Display(Name = "Resident Status")]
        public string ResidentStatus { get; set; }

        [Display(Name = "Employeement Status")]
        public string EmployeementStatus { get; set; }

        public string HouseRentByOffice { get; set; }
        public string VehiclesByOffice { get; set; }
        [Required]
        public string Signature { get; set; }
    }
}