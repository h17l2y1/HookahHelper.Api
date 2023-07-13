using HookahHelper.DAL.Entities;

namespace HookahHelper.DAL.Repositories.Interfaces;

public interface ICountryRepository : IBaseRepository<Country>
{
    Task<int> Count(string? filterBy);
}