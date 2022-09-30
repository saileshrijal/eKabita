using AspNetCoreHero.ToastNotification.Abstractions;
using eKabita.Models;
using eKabita.Services.Interface;
using eKabita.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace eKabita.Web.Controllers
{
    [Authorize]
    public class PoemController : Controller
    {
        private readonly IPoemService _poemService;
        public INotyfService _notifyService { get; }
        private readonly UserManager<ApplicationUser> _userManager;

        public PoemController(IPoemService poemService, UserManager<ApplicationUser> userManager, INotyfService notifyService)
        {
            _poemService = poemService;
            _userManager = userManager;
            _notifyService = notifyService;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var poems = await _poemService.GetAllPoemByUserId(user.Id);
            return View(poems);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(PoemViewModel vm)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            vm.ApplicationUserId = user.Id;

            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            await _poemService.AddPoem(vm);
            _notifyService.Success("Poem Created Successfully");
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            if(id== Guid.Empty)
            {
                return Content("Enter id of a poem");
            }

            var user = await _userManager.GetUserAsync(HttpContext.User);
            var vm = await _poemService.GetPoemById(id);

            if (vm == null)
            {
                return Content("Poem not found");
            }

            if(user.Id != vm.ApplicationUserId)
            {
                return Content("You are not authorized");
            }

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(PoemViewModel vm)
        {
            if (ModelState.IsValid)
            {
                await _poemService.UpdatePoem(vm);
                _notifyService.Success("Poem Updated Successfully");
                return RedirectToAction(nameof(Index));
            }
            return View(vm);
        }


        public async Task<IActionResult> Delete(Guid id)
        {
            if(id == Guid.Empty)
            {
                return Content("Enter id");
            }
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var poem = await _poemService.GetPoemById(id);
            if(poem == null)
            {
                return Content("No poem found");
            }
            if (user.Id != poem.ApplicationUserId)
            {
                return Content("You are not authorized");
            }
            await _poemService.DeletePoem(id);
            _notifyService.Success("Poem Deleted Successfully");
            return RedirectToAction(nameof(Index));
        }
    }
}
