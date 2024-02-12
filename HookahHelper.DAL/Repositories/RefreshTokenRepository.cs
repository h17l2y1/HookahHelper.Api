using HookahHelper.DAL.Config;
using HookahHelper.DAL.Entities;
using HookahHelper.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace HookahHelper.DAL.Repositories;

public class RefreshTokenRepository : BaseRepository<RefreshToken>, IRefreshTokenRepository
{
    public RefreshTokenRepository(ApplicationContext context) : base(context)
    {
    }
    
    public async Task<bool> IsTokenInvalid(string refreshToken)
    {
        return await _dbSet.AnyAsync(x => x.Token == refreshToken && DateTime.Now > x.ExpiredDate);
    }
}