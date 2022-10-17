using eKabita.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eKabita.Repsitories.Interface
{
    public interface ILikeRepository : IGenericRepository<Like>
    {
        Task<int> checkUserLike(string userId, Guid poem_Id);
        void deleteLike(Like like);
        int totalLikes(Guid poemId);
    }
}
