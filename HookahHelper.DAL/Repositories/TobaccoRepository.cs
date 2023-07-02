using HookahHelper.DAL.Config;
using HookahHelper.DAL.Entities;
using HookahHelper.DAL.Repositories.Interfaces;

namespace HookahHelper.DAL.Repositories;

public class TobaccoRepository: BaseRepository<Tobacco>, ITobaccoRepository
{
    public TobaccoRepository(ApplicationContext context): base(context)
    {
        
    }
}