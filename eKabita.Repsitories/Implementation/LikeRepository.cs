using eKabita.Data;
using eKabita.Models;
using eKabita.Repsitories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eKabita.Repsitories.Implementation
{
    internal class LikeRepository : GenericRepository<Like>, ILikeRepository
    {
        private ApplicationDbContext _context;
        public LikeRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<int> checkUserLike(string userId, Guid poem_Id)
        {
            return _context.Likes.Where(x => x.ApplicationUserId == userId && x.PoemId == poem_Id).Count();
        }

        public void deleteLike(Like l)
        {
            var like = _context.Likes.FirstOrDefault(x => x.PoemId == l.PoemId && x.ApplicationUserId == l.ApplicationUserId);
            _context.Likes?.Remove(like);
        }
    }
}
