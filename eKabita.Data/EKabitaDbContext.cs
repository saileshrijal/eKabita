using eKabita.Models;
using Microsoft.EntityFrameworkCore;

namespace eKabita.Data
{
    public class EKabitaDbContext:DbContext
    {
        public EKabitaDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Poem> Poems { get; set; }
    }
}
