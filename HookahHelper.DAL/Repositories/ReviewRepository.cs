using HookahHelper.DAL.Config;
using HookahHelper.DAL.Entities;
using HookahHelper.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HookahHelper.DAL.Repositories;

public class ReviewRepository: BaseRepository<Review>, IReviewRepository
{
    public ReviewRepository(ApplicationContext context) : base(context)
    {
    }

    public async Task<double> GetAvgTobaccoRating(string tobaccoId)
    {
        return await _dbSet.AsNoTracking()
            .Where(x => x.TobaccoId == tobaccoId)
            .Select(x => x.Rating)
            .AverageAsync();
    }
    public async Task<double> GetAvgMixRating(string mixId)
    {
        return await _dbSet.AsNoTracking()
            .Where(x => x.MixId == mixId)
            .Select(x => x.Rating)
            .AverageAsync();
    }
}