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

    public async Task<IEnumerable<Brand>> GetAll(int skip, int take, string? sortBy, string? column)
    {
        var query = _dbSet.AsNoTracking();

        if (sortBy != null)
        {
            query = query.OrderBy($"{column} {sortBy}");
        }

        query = query.Skip(skip).Take(take);
        
        return await query.ToListAsync();
    }

    public override async Task<Brand?> GetById(string id)
    {
        return await _dbSet
            .AsNoTracking()
            .Include(x => x.Lines)
            .SingleOrDefaultAsync(x => x.Id == id);
    }
}