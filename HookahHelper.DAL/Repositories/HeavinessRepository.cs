using HookahHelper.DAL.Config;
using HookahHelper.DAL.Entities;
using HookahHelper.DAL.Repositories.Interfaces;

namespace HookahHelper.DAL.Repositories;

public class HeavinessRepository : BaseRepository<Heaviness>, IHeavinessRepository
{
    public HeavinessRepository(ApplicationContext context) : base(context)
    {
    }
}