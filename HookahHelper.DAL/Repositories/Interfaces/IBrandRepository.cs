using HookahHelper.DAL.Entities;

namespace HookahHelper.DAL.Repositories.Interfaces;

public interface IBrandRepository: IBaseRepository<Brand>
{
    Task<IEnumerable<Brand>> GetAll2(int skip, int take);

}