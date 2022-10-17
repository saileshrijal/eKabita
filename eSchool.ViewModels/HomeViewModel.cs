using eKabita.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eKabita.ViewModels
{
    public class HomeViewModel
    {
        public Guid? Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Remarks { get; set; }
        public string? ApplicationUserId { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public ApplicationUser? ApplicationUser { get; set; }
        public bool IsLiked { get; set; }
        public HomeViewModel()
        {
        }

        public HomeViewModel(Poem model)
        {
            Id = model.Id;
            Title = model.Title;
            Description = model.Description;
            Remarks = model.Remarks;
            ApplicationUserId = model.ApplicationUserId;
            CreatedDate = model.CreatedDate;
            ApplicationUser = model.ApplicationUser;
        }

        public Poem ConvertViewModel(PoemViewModel vm)
        {
            return new Poem()
            {
                Id = vm.Id,
                Title = vm.Title,
                Description = vm.Description,
                Remarks = vm.Remarks,
                ApplicationUserId = vm.ApplicationUserId,
                CreatedDate = vm.CreatedDate,
                ApplicationUser = vm.ApplicationUser,
            };
        }
    }
}