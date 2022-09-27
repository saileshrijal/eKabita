using eKabita.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace eKabita.Data
{
    public class ApplicationDbContext:IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<ApplicationUser>? ApplicationUsers { get; set; }
        public DbSet<Like>? Likes { get; set; }
        public DbSet<Poem>? Poems { get; set; }
    }
}
