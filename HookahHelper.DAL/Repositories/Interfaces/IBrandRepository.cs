using HookahHelper.DAL.Entities;

namespace HookahHelper.DAL.Repositories.Interfaces;

public interface IBrandRepository: IBaseRepository<Brand>
{
    Task<IEnumerable<Brand>> GetAll(int skip, int take, string? sortBy, string? column);
}