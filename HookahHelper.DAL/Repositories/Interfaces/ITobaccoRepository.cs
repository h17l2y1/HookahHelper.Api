using HookahHelper.DAL.Entities;
using HookahHelper.DAL.Entities.Models;

namespace HookahHelper.DAL.Repositories.Interfaces;

public interface ITobaccoRepository: IBaseRepository<Tobacco>
{
    Task<IEnumerable<Tobacco>> GetAll(int skip, int take, string sortBy, string column, Filter filters);

    Task<int> Count(Filter filters);

    new Task<Tobacco?> GetById(string id);

    Task<IEnumerable<Tobacco>> GetByBrandId(string brandId);
}