using eKabita.Models;
using eKabita.Services.Interface;
using eKabita.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace eKabita.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public UserService(UserManager<ApplicationUser> userManager, 
                                        SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
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
    }
}
