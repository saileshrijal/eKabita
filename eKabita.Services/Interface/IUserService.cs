using eKabita.Models;
using eKabita.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace eKabita.Services.Interface
{
    public interface IUserService
    {
        Task Register(RegisterViewModel vm);
        Task Login(LoginViewModel vm);
        Task Logout();
        Task<ManageProfileViewModel> GetUserById(string userId);
        Task UpdateUser(ManageProfileViewModel vm);
    }
}
