using System.ComponentModel.DataAnnotations;

namespace RegistrationForm.Models
{
    public class UserRegistration
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter User Name")]
        [Display(Name ="Username")]
        public string UserName { get; set; }


        [Required(ErrorMessage = "Please enter Email")]
        [Display(Name = "Email")]
        [RegularExpression(".+@.+\\..+")]
        public string Emaild  { get; set; }

        [Required(ErrorMessage = "Please enter Password")]
        [Display(Name = "Password")]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please enter Confirm Password")]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Marital Status")]
        [Required(ErrorMessage = "Please select marital status")]
        public string MaritalStatus { get; set; }

        [Display(Name = "Gender")]
        [Required(ErrorMessage = "Please select gender")]
        public char Gender  { get; set; }
    }
}
