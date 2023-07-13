using HookahHelper.DAL.Entities;

namespace HookahHelper.DAL.Repositories.Interfaces;

public interface ILineRepository: IBaseRepository<Line>
{
    Task<int> Count(string? filterBy);
}