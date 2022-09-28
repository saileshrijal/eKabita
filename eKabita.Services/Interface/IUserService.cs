using eKabita.ViewModels;

namespace eKabita.Services.Interface
{
    public interface IUserService
    {
        Task Register(RegisterViewModel vm);
        Task Login(LoginViewModel vm);
        Task Logout();
    }
}
