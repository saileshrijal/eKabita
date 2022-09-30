using eKabita.Models;
using eKabita.Services.Interface;
using eKabita.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace eKabita.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        private readonly UserManager<ApplicationUser> userManager;

        public AccountController(IUserService userService, UserManager<ApplicationUser> _userManager)
        {
            _userService = userService;
            userManager = _userManager;
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _userService.Logout();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel regViewModel) {
            if (ModelState.IsValid) {
                await _userService.Register(regViewModel);
                return RedirectToAction("Index", "Home");
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
                await _userService.Login(loginViewModel);
                return RedirectToAction("Index", "Home");
            }
            return View(loginViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> UserDetail() {
            var user = await userManager.GetUserAsync(HttpContext.User);
            var vm = new UserDetailViewModel()
            {
                Id = user.Id,
            };
            return View(vm);
        }
    }
}
