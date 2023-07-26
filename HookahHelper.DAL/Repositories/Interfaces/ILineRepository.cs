using HookahHelper.DAL.Entities;

namespace HookahHelper.DAL.Repositories.Interfaces;

public interface ILineRepository: IBaseRepository<Line>
{
    Task<IEnumerable<Line>> GetLinesByBrandId(string brandId);

}