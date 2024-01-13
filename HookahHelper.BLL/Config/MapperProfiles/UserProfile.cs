using AutoMapper;
using HookahHelper.BLL.ViewModels.Review;
using HookahHelper.DAL.Entities;

namespace HookahHelper.BLL.Config.MapperProfiles;

public class UserProfile: Profile
{
    public UserProfile()
    {
        CreateMap<User, GetReviewUser>();
    }
}