using eKabita.Models;
using eKabita.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eKabita.Services.Interface
{
    public interface IHomeService
    {
        Task<List<HomeViewModel>> GetAllPoems();
        Task<bool> CheckLiked(string userId, Guid poem_id);
        Task LikeByUser(Like like, Guid poemId);
        Task UnLikeByUser(Like like, Guid poemId);
        int TotalLikes(Guid poemId);
    }
}
