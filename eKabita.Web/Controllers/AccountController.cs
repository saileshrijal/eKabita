using eKabita.Models;
using eKabita.Web.Models.LoginViewModel;
using eKabita.Web.Models.RegisterViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace eKabita.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVIewModel regViewModel) {
            if (ModelState.IsValid) { 
                var user = new ApplicationUser() {
                  FirstName = regViewModel.FirstName,
                  LastName = regViewModel.LastName,
                  UserName = regViewModel.UserName,
                  Email = regViewModel.Email
                };
                var result = await userManager.CreateAsync(user,regViewModel.Password);
                if (result.Succeeded) {
                    await signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Home");
                }

                foreach (var error in result.Errors) { 
                    ModelState.AddModelError(string.Empty,error.Description);
                }
            }
            return View(regViewModel);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(loginViewModel.UserName, 
                    loginViewModel.Password, loginViewModel.RememberMe, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
               
                ModelState.AddModelError(string.Empty, "Invalid Username or Password");  
            }
            return View(loginViewModel);
        }
    }
}
