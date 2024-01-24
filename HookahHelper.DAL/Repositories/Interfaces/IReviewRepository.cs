using HookahHelper.DAL.Entities;

namespace HookahHelper.DAL.Repositories.Interfaces;

public interface IReviewRepository: IBaseRepository<Review>
{
    Task<double> GetAvgRating(string tobaccoId);
}