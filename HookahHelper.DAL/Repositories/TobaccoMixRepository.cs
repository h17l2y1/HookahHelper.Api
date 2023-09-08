using HookahHelper.DAL.Config;
using HookahHelper.DAL.Entities;
using HookahHelper.DAL.Repositories.Interfaces;

namespace HookahHelper.DAL.Repositories;

public class TobaccoMixRepository : BaseRepository<TobaccoMix>, ITobaccoMixRepository
{
    public TobaccoMixRepository(ApplicationContext context) : base(context)
    {
    }
}