using eKabita.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eKabita.Services.Interface
{
    public interface IPoemService
    {
        Task<List<PoemViewModel>> GetAllPoemByUserId(string userId);
        Task<PoemViewModel> GetPoemById(Guid id);
        Task UpdatePoem(PoemViewModel vm);
        Task DeletePoem(Guid id);
        Task AddPoem(PoemViewModel vm);
    }
}
