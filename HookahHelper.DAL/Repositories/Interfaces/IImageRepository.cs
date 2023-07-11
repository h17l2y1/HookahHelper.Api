using HookahHelper.DAL.Entities;

namespace HookahHelper.DAL.Repositories.Interfaces;

public interface IImageRepository:IBaseRepository<Image>
{
    Task<IEnumerable<Image>> GetAll2(int skip, int take);
}