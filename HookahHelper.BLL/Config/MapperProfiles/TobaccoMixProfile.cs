using AutoMapper;
using HookahHelper.BLL.ViewModels.TobaccoMix;
using HookahHelper.DAL.Entities;

namespace HookahHelper.BLL.Config.MapperProfiles;

public class TobaccoMixProfile: Profile
{
    public TobaccoMixProfile()
    {
        CreateMap<CreateTobaccoMixRequest, TobaccoMix>();
        CreateMap<TobaccoMix, TobaccoMixResponse>();
    }
}