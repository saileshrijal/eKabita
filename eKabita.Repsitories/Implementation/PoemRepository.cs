using eKabita.Data;
using eKabita.Models;
using eKabita.Repsitories.Interface;
using Microsoft.EntityFrameworkCore;

namespace eKabita.Repsitories.Implementation
{
    internal class PoemRepository : GenericRepository<Poem>, IPoemRepository
    {
        private readonly ApplicationDbContext _context;

        public PoemRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<List<Poem>> GetAll()
        {
            var poems = await _context.Poems.Include(x=>x.ApplicationUser).OrderByDescending(x=>x.CreatedDate).ToListAsync();
            return poems;
        }
    }
}
