using HookahHelper.DAL.Entities;

namespace HookahHelper.DAL.Repositories.Interfaces;

public interface IRefreshTokenRepository : IBaseRepository<RefreshToken>
{
    Task<bool> IsTokenValid(string refreshToken, DateTime expirationDateTime);
}