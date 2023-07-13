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
    
    public async Task<int> Count(string? filterBy)
    {
        if (filterBy != null)
        {
            return await _dbSet.Where(x => x.Name.Contains(filterBy)).CountAsync();
        }
        
        return await _dbSet.CountAsync();
    }
}