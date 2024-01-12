using HookahHelper.DAL.Config;
using HookahHelper.DAL.Entities;
using HookahHelper.DAL.Repositories.Interfaces;

namespace HookahHelper.DAL.Repositories;

public class ReviewRepository: BaseRepository<Review>, IReviewRepository
{
    public ReviewRepository(ApplicationContext context) : base(context)
    {
    }
}