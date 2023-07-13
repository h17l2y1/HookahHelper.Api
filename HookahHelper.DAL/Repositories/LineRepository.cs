using HookahHelper.DAL.Config;
using HookahHelper.DAL.Entities;
using HookahHelper.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HookahHelper.DAL.Repositories;

public class LineRepository: BaseRepository<Line>, ILineRepository
{
    public LineRepository(ApplicationContext context): base(context)
    {
    }
    
    public override async Task<Line?> GetById(string id)
    {
        return await _dbSet
            .AsNoTracking()
            .Include(x => x.Tobaccos)
            .SingleOrDefaultAsync(x => x.Id == id);
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