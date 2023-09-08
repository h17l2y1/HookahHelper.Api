using HookahHelper.DAL.Entities;
using Microsoft.AspNetCore.Identity;

namespace HookahHelper.BLL.Providers.Interfaces;

public interface IJwtProvider
{
    string GenerateJwtToken(User user);
}