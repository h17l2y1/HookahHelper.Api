using AutoMapper;
using HookahHelper.BLL.ViewModels.Review;
using HookahHelper.DAL.Entities;

namespace HookahHelper.BLL.Config.MapperProfiles;

public class ReviewProfile: Profile
{
    public ReviewProfile()
    {
        CreateMap<CreateReviewRequest, Review>()
            .ForMember(to => to.AnonymousName, from => from.MapFrom(source => source.Name));

        CreateMap<Review, GetReviewResponse>()
            .ForMember(to => to.Name, from => from.MapFrom(source => source.IsAnonymous? source.AnonymousName : $"{source.User.FirstName} {source.User.LastName}"));
    }
}