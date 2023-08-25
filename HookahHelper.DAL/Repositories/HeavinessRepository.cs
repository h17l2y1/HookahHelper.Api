using HookahHelper.DAL.Config;
using HookahHelper.DAL.Entities;
using HookahHelper.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HookahHelper.DAL.Repositories;

public class HeavinessRepository : BaseRepository<Heaviness>, IHeavinessRepository
{
    public HeavinessRepository(ApplicationContext context) : base(context)
    {
    }
    
    public async Task<IEnumerable<Heaviness>> GetOptions()
    {
        return await _dbSet
            .AsNoTracking()
            .OrderBy(x => x.Value)
            .ToListAsync();
    }
}