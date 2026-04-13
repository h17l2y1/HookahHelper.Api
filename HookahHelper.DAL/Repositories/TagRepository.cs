using HookahHelper.DAL.Config;
using HookahHelper.DAL.Entities;
using HookahHelper.DAL.Entities.Models;
using HookahHelper.DAL.Repositories.Extensions;
using HookahHelper.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace HookahHelper.DAL.Repositories;

public class TagRepository : BaseRepository<Tag>, ITagRepository
{
    public TagRepository(ApplicationContext context): base(context)
    {
    }
    
    public async Task<IEnumerable<Tag>> GetAll(int skip, int take, string sortBy, string column, Filter filters)
    {
        return await _dbSet
            .AsNoTracking()
            .WhereIf(filters.Name is not null, x => EF.Functions.Like(x.Name, $"%{filters.Name}%"))
            .Skip(skip)
            .Take(take)
            .ToListAsync();
    }
    public async Task<int> Count(Filter filters)
    {
        return await _dbSet
            .WhereIf(filters.Name is not null, x => x.Name.ToLower().Contains(filters.Name.ToLower()))
            .CountAsync();
    }
    
    public async Task<IEnumerable<Tag>> GetGlobals()
    {
        return await _dbSet.AsNoTracking()
            .Where(x => x.IsGlobal == true)
            .OrderBy(x => x.Name)
            .ToListAsync();
    }
    
    public async Task<bool> IsExist(string name, bool isGlobal)
    {
        return await _dbSet.AsNoTracking()
            .Where(x => x.IsGlobal == isGlobal)
            .AnyAsync(x => x.Name == name);
    }
}