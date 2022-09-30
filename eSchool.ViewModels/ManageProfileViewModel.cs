
using eKabita.Models;

namespace eKabita.ViewModels
{
    public class ManageProfileViewModel
    {
        public string? Id { get; set; }
        public string? FirstName { get; set; }        
        public string? LastName { get; set; }        
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? Gender { get; set; }

        public ManageProfileViewModel()
        {

        }
        public ManageProfileViewModel(ApplicationUser model)
        {   
             Id = model.Id;
             FirstName = model.FirstName;
             LastName = model.LastName;
             UserName = model.UserName;
             Email = model.Email;
             Address = model.Address;
             Gender = model.Gender;
        }

        public ApplicationUser ConvertViewModel(ManageProfileViewModel vm)
        {
            return new ApplicationUser()
            {
                Id = vm.Id,
                FirstName = vm.FirstName,
                LastName = vm.LastName,
                UserName = vm.UserName,
                Email = vm.Email,
                Address = vm.Address,
                Gender = vm.Gender
            };
        }
    }
}
