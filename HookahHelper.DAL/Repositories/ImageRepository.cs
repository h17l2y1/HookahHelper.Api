using HookahHelper.DAL.Config;
using HookahHelper.DAL.Entities;
using HookahHelper.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HookahHelper.DAL.Repositories;


public class ImageRepository: BaseRepository<Image>, IImageRepository
{
    public ImageRepository(ApplicationContext context): base(context)
    {
    }
    
    public async Task<IEnumerable<Image>> GetAll2(int skip = 0, int take = 100)
    {
        var list = await _dbSet
            .AsNoTracking()
            .Skip(skip)
            .Take(take)
            .ToListAsync();

        return list;
    }


    // public override async Task<Image?> GetById(string id)
    // {
    //     return await _dbSet
    //         .AsNoTracking()
    //         .Include(x => x.Lines)
    //         .SingleOrDefaultAsync(x => x.Id == id);
    // }
}