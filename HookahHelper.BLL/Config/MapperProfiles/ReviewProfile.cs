using AutoMapper;
using HookahHelper.BLL.ViewModels.Review;
using HookahHelper.DAL.Entities;

namespace HookahHelper.BLL.Config.MapperProfiles;

public class ReviewProfile: Profile
{
    public ReviewProfile()
    {
        CreateMap<CreateReviewRequest, Review>();
        CreateMap<Review, GetReviewResponse>();
    }
}