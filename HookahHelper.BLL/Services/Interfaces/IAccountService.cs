using HookahHelper.BLL.ViewModels.Account;

namespace HookahHelper.BLL.Services.Interfaces;

public interface IAccountService
{
    Task SignUp(SignUp request);
    Task<string> Authenticate(Login model);
}