using HookahHelper.DAL.Config;
using HookahHelper.DAL.Entities;
using HookahHelper.DAL.Repositories.Interfaces;

namespace HookahHelper.DAL.Repositories;

public class RefreshTokenRepository : BaseRepository<RefreshToken>, IRefreshTokenRepository
{
    public RefreshTokenRepository(ApplicationContext context) : base(context)
    {
    }
}