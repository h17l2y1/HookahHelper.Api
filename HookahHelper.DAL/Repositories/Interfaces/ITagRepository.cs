using HookahHelper.DAL.Entities;
using HookahHelper.DAL.Entities.Models;

namespace HookahHelper.DAL.Repositories.Interfaces;

public interface ITagRepository : IBaseRepository<Tag>
{
    Task<int> Count(Filter filters);
}