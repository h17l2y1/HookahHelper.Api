using HookahHelper.BLL.Models;
using HookahHelper.BLL.ViewModels.Account;
using HookahHelper.DAL.Entities;

namespace HookahHelper.BLL.Providers.Interfaces;

public interface IJwtProvider
{
    RefreshTokenData GenerateJwtToken(User user);
}