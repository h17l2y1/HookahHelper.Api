using HookahHelper.BLL.ViewModels.Account;
using HookahHelper.DAL.Entities;

namespace HookahHelper.BLL.Providers.Interfaces;

public interface IJwtProvider
{
    LoginResponse GenerateJwtToken(User user);
}