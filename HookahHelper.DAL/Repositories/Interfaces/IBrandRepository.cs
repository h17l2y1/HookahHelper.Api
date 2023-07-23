using HookahHelper.DAL.Entities;
using HookahHelper.DAL.Entities.Models;

namespace HookahHelper.DAL.Repositories.Interfaces;

public interface IBrandRepository: IBaseRepository<Brand>
{
    Task<IEnumerable<Brand>> GetAll(int skip, int take, string sortBy, string column, Filter filters);

    Task<int> Count(Filter filters);
}