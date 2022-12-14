using eKabita.Models;
using eKabita.Repsitories.Configuration;
using eKabita.Services.Interface;
using eKabita.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace eKabita.Services.Implementation
{
    public class PoemService : IPoemService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUnitOfWork _unitOfWork;

        public PoemService(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        public async Task AddPoem(PoemViewModel vm)
        {
            var poem = new PoemViewModel().ConvertViewModel(vm);
            await _unitOfWork.Poem.Create(poem);
            await _unitOfWork.Save();
        }

        public async Task DeletePoem(Guid id)
        {
            var poem = await _unitOfWork.Poem.GetBy(x => x.Id == id);
            if(poem != null)
            {
                await _unitOfWork.Poem.Delete(id);
                await _unitOfWork.Save();
            }
        }

        public async Task<List<PoemViewModel>> GetAllPoemByUserId(string userId)
        {
            var modelList = await _unitOfWork.Poem.GetAllBy(x=>x.ApplicationUserId==userId);
            return ConvertModelToViewModelList(modelList);
        }

        private List<PoemViewModel> ConvertModelToViewModelList(List<Poem> modelList)
        {
            return modelList.Select(x => new PoemViewModel(x)).ToList();
        }

        public async Task<PoemViewModel> GetPoemById(Guid id)
        {
            var model = await _unitOfWork.Poem.GetBy(x => x.Id == id);
            var vm = new PoemViewModel(model);
            return vm;
        }

        public async Task UpdatePoem(PoemViewModel vm)
        {
            var model = new PoemViewModel().ConvertViewModel(vm);
            var modelById = await _unitOfWork.Poem.GetBy(x => x.Id == model.Id);
            modelById.Title = vm.Title;
            modelById.Description = vm.Description;
            modelById.Remarks = vm.Remarks;

            await _unitOfWork.Save();
        }
    }
}
