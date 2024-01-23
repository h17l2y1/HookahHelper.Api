using HookahHelper.DAL.Config;
using HookahHelper.DAL.Entities;
using HookahHelper.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HookahHelper.DAL.Repositories;

public class TobaccoTagRepository : BaseRepository<TobaccoTag>, ITobaccoTagRepository
{
    public TobaccoTagRepository(ApplicationContext context) : base(context)
    {
    }
    
    public async Task RemoveTagsByTobaccoId(string tobaccoId)
    {
        var toRemove = await _dbSet.Where(x => x.TobaccoId == tobaccoId).ToListAsync();
        await RemoveRange(toRemove);
    }
    
    public async Task RemoveRangeByIdsWithoutSave(IEnumerable<string> ids)
    {
        var entities = await _dbSet.Where(x => ids.Contains(x.Id)).ToListAsync();
        _dbSet.RemoveRange(entities);
    }
}