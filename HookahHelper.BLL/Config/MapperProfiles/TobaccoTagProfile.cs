using AutoMapper;
using HookahHelper.BLL.ViewModels.TobaccoTag;
using HookahHelper.DAL.Entities;

namespace HookahHelper.BLL.Config.MapperProfiles;

public class TobaccoTagProfile: Profile
{
    public TobaccoTagProfile()
    {
        CreateMap<TobaccoTag, TobaccoTagRequest>();
        CreateMap<TobaccoTagRequest, TobaccoTag>()
            .ForMember(to => to.Id, from => from.MapFrom(source => GenerateIdIfNull(source.Id)));

    }

    private string GenerateIdIfNull(string? id)
    {
        return id ?? Guid.NewGuid().ToString();
    }
}