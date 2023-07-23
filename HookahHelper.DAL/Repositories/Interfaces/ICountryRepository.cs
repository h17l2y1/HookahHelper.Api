using HookahHelper.DAL.Entities;
using HookahHelper.DAL.Entities.Models;

namespace HookahHelper.DAL.Repositories.Interfaces;

public interface ICountryRepository : IBaseRepository<Country>
{
    Task<int> Count(Filter filters);
}