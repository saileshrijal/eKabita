using eKabita.Models;
using eKabita.Services.Interface;
using eKabita.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace eKabita.Web.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountController(IUserService userService,UserManager<ApplicationUser> userManager)
        {
            _userService = userService;
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _userService.Logout();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]

        public async Task<IActionResult> Register(RegisterViewModel regViewModel) {
            if (ModelState.IsValid) {
                await _userService.Register(regViewModel);
                return RedirectToAction("Index", "Home");
            }
            return View(regViewModel);
        }

        [HttpGet]
        [AllowAnonymous]

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]

        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                await _userService.Login(loginViewModel);
                return RedirectToAction("Index", "Home");
            }
            return View(loginViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> ManageProfile() {

            var currentUser = await _userManager.GetUserAsync(HttpContext.User);
            var vm = await _userService.GetUserById(currentUser.Id);
            return View(vm);
        }


        [HttpPost]
        public async Task<IActionResult> ManageProfile(ManageProfileViewModel vm)
        {
            await _userService.UpdateUser(vm);
            return RedirectToAction(nameof(ManageProfile));
        }
    }
}
