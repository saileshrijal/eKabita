using eKabita.Models;
using eKabita.Services.Interface;
using eKabita.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace eKabita.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private IHomeService _homeService;

        private IPoemService _poemService;
        private UserManager<ApplicationUser> _userManager;

        public HomeController(IHomeService homeService, UserManager<ApplicationUser> userManager, IPoemService poemService)
        {
            _homeService = homeService;
            _userManager = userManager;
            _poemService = poemService;
        }

        public async Task<IActionResult> Index()
        {
            string userId = _userManager.GetUserId(HttpContext.User);
            var poems = await _homeService.GetAllPoems();
            foreach (var poem in poems)
            {
                poem.TotalLikes = _homeService.TotalLikes((Guid)poem.Id);
                if(await _homeService.CheckLiked(userId, (Guid)poem.Id))
                {
                    poem.IsLiked = true;
                }
                else
                {
                    poem.IsLiked = false;
                }
            }
            return View(poems);
        }

        [HttpPost]
        public async Task<IActionResult> Like(Guid id)
        {
            string userId = _userManager.GetUserId(HttpContext.User);
            var poem = await _poemService.GetPoemById(id);
            var like = new Like()
            {
                ApplicationUserId = userId
            };
            await _homeService.LikeByUser(like, (Guid)poem.Id);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> UnLike(Guid id)
        {
            string userId = _userManager.GetUserId(HttpContext.User);
            var poem = await _poemService.GetPoemById(id);
            var like = new Like()
            {
                ApplicationUserId = userId
            };
            await _homeService.UnLikeByUser(like, (Guid)poem.Id);
            return RedirectToAction(nameof(Index));
        }
    }
}