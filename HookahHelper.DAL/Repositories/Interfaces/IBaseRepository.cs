namespace HookahHelper.DAL.Repositories.Interfaces;

public interface IBaseRepository<TEntity>
{
    Task<IEnumerable<TEntity>> GetAll(int skip, int take);
    
    Task<TEntity?> GetById(string id);

    Task Create(TEntity entity);

    Task Create(IEnumerable<TEntity> collection);
    
    Task Update(TEntity entity);

    Task Remove(string id);
}