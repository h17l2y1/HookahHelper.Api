namespace HookahHelper.DAL.Repositories.Interfaces;

public interface IBaseRepository<TEntity>
{
    Task<IEnumerable<TEntity>> GetAll();
    
    Task<TEntity?> GetById(string id);

    Task Create(TEntity entity);

    Task Create(IEnumerable<TEntity> collection);
    
    Task Update(TEntity entity);

    Task Remove(string id);
    Task<int> Count();

    Task<bool> IsExist(string id);
}