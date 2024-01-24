using HookahHelper.DAL.Config;
using HookahHelper.DAL.Entities;
using HookahHelper.DAL.Repositories.Interfaces;

namespace HookahHelper.DAL.Repositories;

public class TobaccoTagRepository : BaseRepository<TobaccoTag>, ITobaccoTagRepository
{
    public TobaccoTagRepository(ApplicationContext context) : base(context)
    {
    }
    
}