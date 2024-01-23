using HookahHelper.BLL.ViewModels.Account;

namespace HookahHelper.BLL.Services.Interfaces;

public interface IAccountService
{
    Task SignUp(SignUp request);
    Task<LoginResponse> Login(Login model);
    Task<LoginResponse> RefreshAuthToken(RefreshTokenRequest request);
}