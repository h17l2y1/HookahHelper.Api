using HookahHelper.BLL.ViewModels.Review;

namespace HookahHelper.BLL.Services.Interfaces;

public interface IReviewService
{
    Task Create(CreateReviewRequest request);
}