using AutoMapper;
using HookahHelper.BLL.ViewModels.Mix;
using HookahHelper.DAL.Entities;

namespace HookahHelper.BLL.Config.MapperProfiles;

public class MixProfile: Profile
{
    public MixProfile()
    {
        CreateMap<MixRequest, Mix>();
        CreateMap<Mix, MixResponse>()
            .ForMember(to => to.CommentsCount, from => from.MapFrom(source => source.Reviews != null ? source.Reviews.Count(x => x.Comment != null) : 0))
            .ForMember(to => to.RatingCount, from => from.MapFrom(source => source.Reviews != null ? source.Reviews.Count() : 0));
        // .ForMember(to => to.Rating, from => from.MapFrom(source => source.Rating.Value));
    }
}