using AutoMapper;
using HookahHelper.BLL.ViewModels.Tobacco;
using HookahHelper.DAL.Entities;

namespace HookahHelper.BLL.Config.MapperProfiles;

public class TobaccoProfile:Profile
{
    public TobaccoProfile()
    {
        CreateMap<CreateTobaccoRequest, Tobacco>();
        CreateMap<UpdateTobaccoRequest, Tobacco>()
            .ForMember(to => to.TobaccoTags, from => from.Ignore());
        CreateMap<Tobacco, GetTobaccoResponse>();
    }
}