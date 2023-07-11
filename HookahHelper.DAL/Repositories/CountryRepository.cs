using HookahHelper.DAL.Config;
using HookahHelper.DAL.Entities;
using HookahHelper.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HookahHelper.DAL.Repositories;

public class CountryRepository: BaseRepository<Country>, ICountryRepository
{
    public CountryRepository(ApplicationContext context): base(context)
    {
    }
    public async Task<IEnumerable<Country>> GetAll2(int skip = 0, int take = 100)
    {
        var list = await _dbSet
            .AsNoTracking()
            .Skip(skip)
            .Take(take)
            .ToListAsync();

        return list;
    }
}