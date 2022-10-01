using eKabita.Models;
using System.ComponentModel.DataAnnotations;

namespace eKabita.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        public string? UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Display(Name ="Remember me")]
        public bool RememberMe { get; set; }


        public LoginViewModel() { }

        public LoginViewModel(ApplicationUser model)
        {
            UserName = model.UserName;
        }

        public ApplicationUser ConvertViewModel(LoginViewModel model)
        {
            return new ApplicationUser()
            {
                UserName = model.UserName
            };
        }
    }
}
