using HookahHelper.DAL.Config;
using HookahHelper.DAL.Entities;
using HookahHelper.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using HookahHelper.DAL.Entities.Models;
using HookahHelper.DAL.Repositories.Extensions;

namespace HookahHelper.DAL.Repositories;

public class BrandRepository: BaseRepository<Brand>, IBrandRepository
{
    public BrandRepository(ApplicationContext context): base(context)
    {
    }

    public async Task<IEnumerable<Brand>> GetAll(int skip, int take, string sortBy, string column, Filter filters)
    {
        return await _dbSet
            .AsNoTracking()
            .Include(x => x.Country)
            .Include(x => x.Image)
            .OrderBy($"{column} {sortBy}")
            .WhereIf(filters?.Name is not null, x => x.Name.ToLower().Contains(filters.Name.ToLower()))
            .WhereIf(filters?.CountryId is not null,  x => x.CountryId == filters.CountryId)
            .Skip(skip)
            .Take(take)
            .ToListAsync();
    }
    
    public async Task<int> Count(Filter filters)
    {
        return await _dbSet
            .WhereIf(filters.Name is not null, x => x.Name.ToLower().Contains(filters.Name.ToLower()))
            .WhereIf(filters.CountryId is not null,  x => x.CountryId == filters.CountryId)
            .CountAsync();
    }

    public override async Task<Brand?> GetById(int id)
    {
        return await _dbSet
            .AsNoTracking()
            .Include(x => x.Country)
            .Include(x => x.Image)
            .Include(x => x.Lines)
            .SingleOrDefaultAsync(x => x.Id == id);
    }
    
    public async Task<IEnumerable<Brand>> GetOptions()
    {
        return await _dbSet
            .AsNoTracking()
            .OrderBy(x => x.Name)
            .ToListAsync();
    }
}