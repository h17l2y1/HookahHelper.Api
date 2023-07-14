using HookahHelper.DAL.Entities;

namespace HookahHelper.DAL.Repositories.Interfaces;

public interface ITobaccoRepository: IBaseRepository<Tobacco>
{
    Task<IEnumerable<Tobacco>> GetAll(int skip, int take, string sortBy, string column, string? filterBy);

    Task<int> Count(string? filterBy);
}