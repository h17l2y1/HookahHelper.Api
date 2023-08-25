using AutoMapper;
using HookahHelper.BLL.ViewModels.Tobacco;
using HookahHelper.DAL.Entities;

namespace HookahHelper.BLL.Config.MapperProfiles;

public class TobaccoProfile:Profile
{
    public TobaccoProfile()
    {
        CreateMap<CreateTobaccoRequest, Tobacco>()
            .ForMember(to => to.Tags, from => from.Ignore())
            .ForMember(to => to.Description, from => from.MapFrom(source => string.Join(", ", source.Tags.Select(x => x.Name))));
        CreateMap<UpdateTobaccoRequest, Tobacco>()
            .ForMember(to => to.TobaccoTags, from => from.Ignore())
            .ForMember(to => to.Description, from => from.MapFrom(source => string.Join(", ", source.Tags.Select(x => x.Name))));
        CreateMap<Tobacco, GetTobaccoResponse>();
    }
}