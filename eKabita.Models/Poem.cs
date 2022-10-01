using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eKabita.Models
{
    public class Poem
    {
        public Guid? Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Remarks { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? ApplicationUserId { get; set; }   
        public ApplicationUser? ApplicationUser { get; set; }
        public List<Like>? Likes { get; set; }
    }
}
