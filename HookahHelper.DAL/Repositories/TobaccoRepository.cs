using System.Linq.Dynamic.Core;
using HookahHelper.DAL.Config;
using HookahHelper.DAL.Entities;
using HookahHelper.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HookahHelper.DAL.Repositories;

public class TobaccoRepository: BaseRepository<Tobacco>, ITobaccoRepository
{
    public TobaccoRepository(ApplicationContext context): base(context)
    {
        
    }

    public async Task<int> Count(string? filterBy)
    {
        if (filterBy != null)
        {
            return await _dbSet.Where(x => x.Name.Contains(filterBy)).CountAsync();
        }
        
        return await _dbSet.CountAsync();
    }
    
    public async Task<IEnumerable<Tobacco>> GetAll(int skip, int take, string sortBy, string column, string? filterBy)
    {
        var query = _dbSet.AsNoTracking();
        
        query = query.OrderBy($"{column} {sortBy}");
        
        if (filterBy != null)
        {
            query = query.Where(x => x.Name.Contains(filterBy));
        }

        query = query
            .Include(x => x.Image)
            .Skip(skip)
            .Take(take);
        
        return await query.ToListAsync();
    }
}