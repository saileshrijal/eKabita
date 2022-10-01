using eKabita.Models;
using eKabita.Services.Interface;
using eKabita.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace eKabita.Web.Controllers
{
    public class HomeController : Controller
    {
        private IHomeService _homeService;

        public HomeController(IHomeService homeService)
        {
            _homeService = homeService;
        }

        public async Task<IActionResult> Index()
        {
            var poems = await _homeService.GetAllPoems();
            return View(poems);
        }
    }
}