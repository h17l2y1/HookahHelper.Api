using HookahHelper.DAL.Entities;

namespace HookahHelper.DAL.Repositories.Interfaces;

public interface IRefreshTokenRepository : IBaseRepository<RefreshToken>
{
    Task<bool> IsTokenInvalid(string refreshToken);
}