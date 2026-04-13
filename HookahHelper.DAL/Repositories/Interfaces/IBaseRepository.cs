namespace HookahHelper.DAL.Repositories.Interfaces;

public interface IBaseRepository<TEntity>
{
    Task<IEnumerable<TEntity>> GetAll(int skip, int take);
    
    Task<IEnumerable<TEntity>> GetAll();
    
    Task<TEntity> GetById(int id);

    Task<TEntity> FindById(int id);

    Task Create(TEntity entity);

    Task Create(IEnumerable<TEntity> collection);
    
    Task Update(TEntity entity);

    Task Remove(int id);

    Task RemoveRange(IEnumerable<TEntity> entities);

    Task SaveChangesAsync();
}