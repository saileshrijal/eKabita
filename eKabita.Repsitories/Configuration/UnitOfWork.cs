using eKabita.Data;
using eKabita.Repsitories.Implementation;
using eKabita.Repsitories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eKabita.Repsitories.Configuration
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IPoemRepository Poem { get; private set; }

        public ILikeRepository Like { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Poem = new PoemRepository(context);
            Like = new LikeRepository(context);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
