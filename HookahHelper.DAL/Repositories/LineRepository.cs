using HookahHelper.DAL.Config;
using HookahHelper.DAL.Entities;
using HookahHelper.DAL.Entities.Models;
using HookahHelper.DAL.Repositories.Extensions;
using HookahHelper.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HookahHelper.DAL.Repositories;

public class LineRepository: BaseRepository<Line>, ILineRepository
{
    public LineRepository(ApplicationContext context): base(context)
    {
    }
    
    public override async Task<Line?> GetById(int id)
    {
        return await _dbSet
            .AsNoTracking()
            .Include(x => x.Tobaccos)
            .SingleOrDefaultAsync(x => x.Id == id);
    }
    
    public async Task<IEnumerable<Line>>GetLinesByBrandId(int brandId)
    {
        return await _dbSet
            .AsNoTracking()
            .Where(x => x.BrandId == brandId)
            .OrderBy(x => x.Name)
            .ToListAsync();
    }
}