using HookahHelper.DAL.Config;
using HookahHelper.DAL.Entities;
using HookahHelper.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HookahHelper.DAL.Repositories;

public class BrandRepository: BaseRepository<Brand>, IBrandRepository
{
    public BrandRepository(ApplicationContext context): base(context)
    {
    }
    
    public override async Task<Brand?> GetById(string id)
    {
        return await _dbSet
            .AsNoTracking()
            .Include(x => x.Lines)
            .SingleOrDefaultAsync(x => x.Id == id);
    }
}