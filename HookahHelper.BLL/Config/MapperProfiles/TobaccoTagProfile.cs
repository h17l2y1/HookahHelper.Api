using AutoMapper;
using HookahHelper.BLL.ViewModels.TobaccoTag;
using HookahHelper.DAL.Entities;

namespace HookahHelper.BLL.Config.MapperProfiles;

public class TobaccoTagProfile:Profile
{
    public TobaccoTagProfile()
    {
        CreateMap<TobaccoTagRequest, TobaccoTag>();

    }
}