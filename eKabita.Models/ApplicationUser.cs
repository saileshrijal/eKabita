using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace eKabita.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }
        public string? Gender { get; set; }
        public string? ProfilePictureUrl { get; set; }
        public List<Poem>? Poems { get; set; }
        public List<Like>? Likes { get; set; }

        [NotMapped]
        public string? FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }
    }
}
