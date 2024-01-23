using HookahHelper.DAL.Entities;

namespace HookahHelper.DAL.Repositories.Interfaces;

public interface ITobaccoTagRepository : IBaseRepository<TobaccoTag>
{
    Task RemoveTagsByTobaccoId(string tobaccoId);

    Task RemoveRangeByIdsWithoutSave(IEnumerable<string> ids);
}