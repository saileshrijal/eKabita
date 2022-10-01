using eKabita.Models;
using eKabita.Repsitories.Configuration;
using eKabita.Services.Interface;
using eKabita.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eKabita.Services.Implementation
{
    public class HomeService : IHomeService
    {
        private IUnitOfWork _unitOfWork;

        public HomeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<PoemViewModel>> GetAllPoems()
        {
            var modelList = await _unitOfWork.Poem.GetAll();
            return ConvertModelToViewModel(modelList);
        }

        private List<PoemViewModel> ConvertModelToViewModel(List<Poem> modelList)
        {
            return modelList.Select(x => new PoemViewModel(x)).ToList();
        }
    }
}
