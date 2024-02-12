using HookahHelper.DAL.Config;
using HookahHelper.DAL.Entities;
using HookahHelper.DAL.Entities.Models;
using HookahHelper.DAL.Repositories.Extensions;
using HookahHelper.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HookahHelper.DAL.Repositories;

public class MixRepository : BaseRepository<Mix>, IMixRepository
{
    public MixRepository(ApplicationContext context) : base(context)
    {
    }
    
    public async Task<int> Count(Filter filters)
    {
        return await _dbSet
            .WhereIf(filters.Name is not null, x => x.Name.ToLower().Contains(filters.Name.ToLower()))
            .CountAsync();
    }

    public async Task<IEnumerable<Mix>> GetAll(int skip, int take, string sortBy, string column, Filter filters)
    {
        return await _dbSet
            .AsNoTracking()
            .Include(x => x.TobaccoMixes)
            .Include(x => x.Reviews)
            .WhereIf(filters.Name is not null, x => x.Name.ToLower().Contains(filters.Name.ToLower()))
            .OrderBy(x => x.Name)
            .Skip(skip)
            .Take(take)
            .ToListAsync();
    }
}