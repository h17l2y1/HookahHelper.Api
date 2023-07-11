using HookahHelper.DAL.Entities;

namespace HookahHelper.DAL.Repositories.Interfaces;

public interface ICountryRepository : IBaseRepository<Country>
{
    Task<IEnumerable<Country>> GetAll2(int skip, int take);
}