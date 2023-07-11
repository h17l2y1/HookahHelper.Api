using HookahHelper.DAL.Config;
using HookahHelper.DAL.Entities.Interfaces;
using HookahHelper.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HookahHelper.DAL.Repositories;

public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class, IBaseEntity
{
    private ApplicationContext _context { get; set; }

    protected DbSet<TEntity> _dbSet { get; set; }

    public BaseRepository(ApplicationContext context)
    {
        _context = context;
        _dbSet = _context.Set<TEntity>();
    }

    public virtual async Task<IEnumerable<TEntity>> GetAll(int skip, int take)
    {
        return await _dbSet
            .AsNoTracking()
            .Skip(skip)
            .Take(take)
            .ToListAsync();
    }

    public virtual async Task<TEntity?> GetById(string id)
    {
        return await _dbSet.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);
    }

    public virtual async Task Create(TEntity entity)
    {
        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public virtual async Task Create(IEnumerable<TEntity> collection)
    {
        await _dbSet.AddRangeAsync(collection);
        await _context.SaveChangesAsync();
    }

    public virtual async Task Update(TEntity entity)
    {
        bool isExist = await _dbSet.AnyAsync(x => x.Id == entity.Id);
        if (!isExist)
        {
            throw new Exception($"can't Update because id '{entity.Id}' is doesn't exist");
        }

        _dbSet.Update(entity);
        await _context.SaveChangesAsync();
    }

    public virtual async Task Remove(string id)
    {
        var entity = await _dbSet.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);
        if (entity != null)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<int> Count()
    {
        return await _dbSet.AsNoTracking().CountAsync();
    }
}