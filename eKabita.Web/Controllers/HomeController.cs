using eKabita.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eKabita.Web.Controllers
{
    [Authorize]
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