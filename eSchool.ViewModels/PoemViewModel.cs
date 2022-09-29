using eKabita.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eKabita.ViewModels
{
    public class PoemViewModel
    {
        public Guid? Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Remarks { get; set; }
        public string? ApplicationUserId { get; set; }

        public PoemViewModel()
        {
        }

        public PoemViewModel(Poem model)
        {
            Id = model.Id;
            Title = model.Title;
            Description = model.Description;
            Remarks = model.Remarks;
            ApplicationUserId = model.ApplicationUserId;
        }

        public Poem ConvertViewModel(PoemViewModel vm)
        {
            return new Poem(){
                Id = vm.Id,
                Title = vm.Title,
                Description = vm.Description,
                Remarks = vm.Remarks,
                ApplicationUserId = vm.ApplicationUserId,
            };
        }

    }
}
