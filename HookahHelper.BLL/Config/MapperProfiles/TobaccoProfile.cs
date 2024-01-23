using AutoMapper;
using HookahHelper.BLL.ViewModels.Tobacco;
using HookahHelper.DAL.Entities;

namespace HookahHelper.BLL.Config.MapperProfiles;

public class TobaccoProfile:Profile
{
    public TobaccoProfile()
    {
        CreateMap<CreateTobaccoRequest, Tobacco>()
            .ForMember(to => to.Description, from => from.MapFrom(source => string.Join(", ", source.Tags.Select(x => x.Name))))
            .ForMember(to => to.Tags, from => from.Ignore())
            .ForMember(to => to.Name, from => from.MapFrom(source => source.Name.Trim()));
        CreateMap<UpdateTobaccoRequest, Tobacco>()
            .ForMember(to => to.Description, from => from.MapFrom(source => string.Join(", ", source.Tags.Select(x => x.Name))))
            // .ForMember(to => to.TobaccoTags, from => from.Ignore())
            .ForMember(to => to.Tags, from => from.Ignore())
            .ForMember(to => to.Name, from => from.MapFrom(source => source.Name.Trim()));
        CreateMap<Tobacco, GetTobaccoResponse>()
            .ForMember(to => to.CommentsCount, from => from.MapFrom(source => source.Reviews != null ? source.Reviews.Count(x => x.Comment != null) : 0))
            .ForMember(to => to.RatingCount, from => from.MapFrom(source => source.Reviews != null ? source.Reviews.Count() : 0))
            // .ForMember(to => to.Rating, from => from.MapFrom(source => source.Reviews != null ? Math.Round(source.Reviews.Average(x => x.Rating), 2) : 0));
            .ForMember(to => to.Rating, from => from.MapFrom(source => 0));
    }
}