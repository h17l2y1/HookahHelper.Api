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
            .WhereIf(filters.Name is not null, x => x.Name.ToLower().Contains(filters.Name.ToLower()) || x.Tags.Any(tag => tag.Name.ToLower() == filters.Name.ToLower()))
            .WhereIf(filters.TagId is not null, x => x.Tags.Any(tag => tag.Id == filters.TagId))
            .WhereIf(filters.BrandId is not null, x => x.BrandId == filters.BrandId)
            .WhereIf(filters.CountryId is not null, x => x.Brand.CountryId == filters.CountryId)
            .WhereIf(filters.LineId is not null, x => x.LineId == filters.LineId)
            .WhereIf(filters.HeavinessId is not null,  x => x.HeavinessId == filters.HeavinessId)
            .CountAsync();
    }

    public async Task<IEnumerable<Tobacco>> GetAll(int skip, int take, string sortBy, string column, Filter filters)
    {
        return await _dbSet
            .AsNoTracking()
            .Include(x => x.Image)
            .Include(x => x.Reviews)
            .Include(x => x.Tags.OrderBy(c => c.Name))
            .WhereIf(filters.Name is not null, x => x.Name.ToLower().Contains(filters.Name.ToLower()) || x.Tags.Any(tag => tag.Name.ToLower() == filters.Name.ToLower()))
            .WhereIf(filters.TagId is not null, x => x.Tags.Any(tag => tag.Id == filters.TagId))
            .WhereIf(filters.BrandId is not null, x => x.BrandId == filters.BrandId)
            .WhereIf(filters.CountryId is not null, x => x.Brand.CountryId == filters.CountryId)
            .WhereIf(filters.LineId is not null, x => x.LineId == filters.LineId)
            .WhereIf(filters.HeavinessId is not null,  x => x.HeavinessId == filters.HeavinessId)
            .OrderBy($"{column} {sortBy}")
            .ThenBy(x => x.Tags.Count())
            .Skip(skip)
            .Take(take)
            .ToListAsync();
    }
    
    public override async Task<Tobacco?> GetById(int id)
    {
        return await _dbSet
            .AsNoTracking()
            .Include(x => x.Image)
            .Include(x => x.Tags)
            .Include(x => x.TobaccoTags)
            .Include(x => x.Brand)
            .Include(x => x.Reviews)
                .ThenInclude( c => c.User)
            .SingleOrDefaultAsync(x => x.Id == id);
    }

    public async Task<IEnumerable<Tobacco>> GetByBrandId(int brandId)
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