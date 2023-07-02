using HookahHelper.DAL.Config;
using HookahHelper.DAL.Entities;
using HookahHelper.DAL.Repositories.Interfaces;

namespace HookahHelper.DAL.Repositories;

public class BrandRepository: BaseRepository<Brand>, IBrandRepository
{
    public BrandRepository(ApplicationContext context): base(context)
    {
        
    }
}