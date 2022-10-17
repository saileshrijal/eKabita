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

        public async Task<bool> CheckLiked(string userId, Guid poem_id)
        {
            var result = await _unitOfWork.Like.checkUserLike(userId, poem_id);
            if (result > 0)
            {
                return true;
            }
            return false;
        }

        public async Task<List<HomeViewModel>> GetAllPoems()
        {
            var modelList = await _unitOfWork.Poem.GetAll();
            return ConvertModelToViewModel(modelList);
        }
        private List<HomeViewModel> ConvertModelToViewModel(List<Poem> modelList)
        {
            return modelList.Select(x => new HomeViewModel(x)).ToList();
        }

        public async Task LikeByUser(Like like, Guid poemId)
        {
            var poem = await _unitOfWork.Poem.GetBy(x=>x.Id==poemId);
            like.PoemId = poem.Id;
            await _unitOfWork.Like.Create(like);
            await _unitOfWork.Save();
        }

        public async Task UnLikeByUser(Like like, Guid poemId)
        {
            var poem = await _unitOfWork.Poem.GetBy(x => x.Id == poemId);
            like.PoemId = poem.Id;
            _unitOfWork.Like.deleteLike(like);
            await _unitOfWork.Save();
        }
    }
}
