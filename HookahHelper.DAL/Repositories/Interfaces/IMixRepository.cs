using HookahHelper.DAL.Entities;
using HookahHelper.DAL.Entities.Models;

namespace HookahHelper.DAL.Repositories.Interfaces;

public interface IMixRepository: IBaseRepository<Mix>
{
    Task<int> Count(Filter filters);
    
    Task<IEnumerable<Mix>> GetAll(int skip, int take, string sortBy, string column, Filter filters);
}