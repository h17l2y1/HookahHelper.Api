using System.Linq.Dynamic.Core;
using HookahHelper.DAL.Config;
using HookahHelper.DAL.Entities;
using HookahHelper.DAL.Entities.Models;
using HookahHelper.DAL.Repositories.Extensions;
using HookahHelper.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HookahHelper.DAL.Repositories;

public class TobaccoRepository : BaseRepository<Tobacco>, ITobaccoRepository
{
    public TobaccoRepository(ApplicationContext context) : base(context)
    {
    }

    public async Task<int> Count(Filter filters)
    {
        return await _dbSet
            .Include(x => x.Brand)
            .WhereIf(filters.Name is not null, x => x.Name.Contains(filters.Name))
            .WhereIf(filters.BrandId is not null, x => x.BrandId == filters.BrandId)
            .WhereIf(filters.CountryId is not null, x => x.Brand.CountryId == filters.CountryId)
            .WhereIf(filters.LineId is not null, x => x.LineId == filters.LineId)
            .CountAsync();
    }

    public async Task<IEnumerable<Tobacco>> GetAll(int skip, int take, string sortBy, string column, Filter filters)
    {
        return await _dbSet
            .AsNoTracking()
            .Include(x => x.Image)
            .Include(x => x.Tags.OrderBy(c => c.Name))
            // .OrderBy($"{column} {sortBy}")
            // .WhereIf(filters.Name is not null, x => x.Name.Contains(filters.Name) || x.Tags.Any(tag => tag.Name.Contains(filters.Name)))
            .WhereIf(filters.Name is not null, x => x.Name.Contains(filters.Name) || x.Tags.Any(tag => tag.Name == filters.Name))
            .WhereIf(filters.TagId is not null, x => x.Tags.Any(tag => tag.Id == filters.TagId))
            .WhereIf(filters.BrandId is not null, x => x.BrandId == filters.BrandId)
            .WhereIf(filters.CountryId is not null, x => x.Brand.CountryId == filters.CountryId)
            .WhereIf(filters.LineId is not null, x => x.LineId == filters.LineId)
            .WhereIf(filters.HeavinessId is not null,  x => x.HeavinessId == filters.HeavinessId)
            .OrderBy(x => x.Tags.Count())
            .ThenBy(x => x.Name)
            .Skip(skip)
            .Take(take)
            .ToListAsync();
    }
    
    public override async Task<Tobacco?> GetById(string id)
    {
        return await _dbSet
            .AsNoTracking()
            .Include(x => x.Image)
            .Include(x => x.Tags)
            .Include(x => x.TobaccoTags)
            .Include(x => x.Brand)
            .SingleOrDefaultAsync(x => x.Id == id);
    }

    public async Task<IEnumerable<Tobacco>> GetByBrandId(string brandId)
    {
        return await _dbSet
            .AsNoTracking()
            .Include(x => x.Image)
            .Include(x => x.Brand)
            .Where(x => x.BrandId == brandId)
            .OrderBy(x => x.Name)
            .ToListAsync();
    }
}