using eKabita.Models;
using eKabita.Repsitories.Configuration;
using eKabita.Services.Interface;
using eKabita.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace eKabita.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IUnitOfWork _unitOfWork;

        public UserService(UserManager<ApplicationUser> userManager, 
                                        SignInManager<ApplicationUser> signInManager,
                                        IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _unitOfWork = unitOfWork;
        }    

        public async Task Login(LoginViewModel vm)
        {
            await _signInManager.PasswordSignInAsync(vm.UserName,
                    vm.Password, vm.RememberMe, false);
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task Register(RegisterViewModel vm)
        {
            var user = new RegisterViewModel().ConvertViewModel(vm);
            var result = await _userManager.CreateAsync(user, vm.Password);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);
            }
        }
        public async Task<ManageProfileViewModel> GetUserById(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            var vm = new ManageProfileViewModel(user);
            return vm;
        }
        public async Task UpdateUser(ManageProfileViewModel vm)
        {
            var userById =await _userManager.FindByIdAsync(vm.Id);
            userById.FirstName = vm.FirstName;
            userById.LastName = vm.LastName;
            userById.Address = vm.Address;
            userById.Gender = vm.Gender;
            await _userManager.UpdateAsync(userById);
        }
    }
}
