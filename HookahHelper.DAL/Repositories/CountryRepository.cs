using HookahHelper.DAL.Config;
using HookahHelper.DAL.Entities;
using HookahHelper.DAL.Entities.Models;
using HookahHelper.DAL.Repositories.Extensions;
using HookahHelper.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HookahHelper.DAL.Repositories;

public class CountryRepository: BaseRepository<Country>, ICountryRepository
{
    public CountryRepository(ApplicationContext context): base(context)
    {
    }
    
    public async Task<int> Count(Filter filters)
    {
        return await _dbSet
                .WhereIf(filters.Name is not null, x => x.Name.Contains(filters.Name))
                .CountAsync();
    }
    
    public async Task<IEnumerable<Country>> GetOptions()
    {
        return await _dbSet
            .AsNoTracking()
            .OrderBy(x => x.Name)
            .ToListAsync();
    }
}