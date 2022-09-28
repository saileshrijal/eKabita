using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace eKabita.Web.Models.RegisterViewModel
{
    public class RegisterVIewModel
    {
        [Required]
        public string? FirstName { get; set; }

        [Required]
        public string? LastName { get; set; }

        [Required]
        public string? UserName { get; set; }
        
        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage ="Password and Confirm Password do not match.")]
        public string? ConfirmPassword { get; set; }
    }
}
