using HookahHelper.DAL.Config;
using HookahHelper.DAL.Entities;
using HookahHelper.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace HookahHelper.DAL.Repositories;

public class BrandRepository: BaseRepository<Brand>, IBrandRepository
{
    public BrandRepository(ApplicationContext context): base(context)
    {
    }

    public async Task<IEnumerable<Brand>> GetAll(int skip, int take, string sortBy, string column, string? filterBy)
    {
        var query = _dbSet.AsNoTracking();
        
        query = query.OrderBy($"{column} {sortBy}");
        
        if (filterBy != null)
        {
            query = query.Where(x => x.Name.Contains(filterBy));
        }

        query = query
            .Include(x => x.Country)
            .Include(x => x.Image)
            .Skip(skip)
            .Take(take);
        
        return await query.ToListAsync();
    }
    
    public async Task<int> Count(string? filterBy)
    {
        if (filterBy != null)
        {
            return await _dbSet.Where(x => x.Name.Contains(filterBy)).CountAsync();
        }
        
        return await _dbSet.CountAsync();
    }

    public override async Task<Brand?> GetById(string id)
    {
        return await _dbSet
            .AsNoTracking()
            .Include(x => x.Lines)
            .SingleOrDefaultAsync(x => x.Id == id);
    }
}