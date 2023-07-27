using AutoMapper;
using HookahHelper.BLL.ViewModels.Heaviness;
using HookahHelper.DAL.Entities;

namespace HookahHelper.BLL.Config.MapperProfiles;

public class HeavinessProfile: Profile
{
    public HeavinessProfile()
    {
        CreateMap<Heaviness, GetHeavinessResponse>().ReverseMap();
    }
}