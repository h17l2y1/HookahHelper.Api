using HookahHelper.DAL.Entities;
using HookahHelper.DAL.Entities.Models;

namespace HookahHelper.DAL.Repositories.Interfaces;

public interface ITagRepository : IBaseRepository<Tag>
{
    Task<IEnumerable<Tag>> GetAll(int skip, int take, string sortBy, string column, Filter filters);

    Task<int> Count(Filter filters);

    Task<IEnumerable<Tag>> GetGlobals();
}