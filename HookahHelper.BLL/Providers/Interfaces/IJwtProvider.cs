using HookahHelper.BLL.ViewModels.Account;
using HookahHelper.DAL.Entities;
using Microsoft.AspNetCore.Identity;

namespace HookahHelper.BLL.Providers.Interfaces;

public interface IJwtProvider
{
    LoginResponse GenerateJwtToken(User user);
}