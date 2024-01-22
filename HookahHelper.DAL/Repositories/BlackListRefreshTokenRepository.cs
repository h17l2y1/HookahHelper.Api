using HookahHelper.DAL.Config;
using HookahHelper.DAL.Entities;
using HookahHelper.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HookahHelper.DAL.Repositories;

public class BlackListRefreshTokenRepository : BaseRepository<BlackListRefreshToken>, IBlackListRefreshTokenRepository
{
    public BlackListRefreshTokenRepository(ApplicationContext context) : base(context)
    {
    }

}