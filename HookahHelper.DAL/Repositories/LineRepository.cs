using HookahHelper.DAL.Config;
using HookahHelper.DAL.Entities;
using HookahHelper.DAL.Repositories.Interfaces;

namespace HookahHelper.DAL.Repositories;

public class LineRepository: BaseRepository<Line>, ILineRepository
{
    public LineRepository(ApplicationContext context): base(context)
    {
        
    }
}