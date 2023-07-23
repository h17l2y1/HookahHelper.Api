using AutoMapper;
using HookahHelper.BLL.ViewModels.Default;
using HookahHelper.DAL.Entities.Models;

namespace HookahHelper.BLL.Config.MapperProfiles;

public class OtherProfile: Profile
{
    public OtherProfile()
    {
        CreateMap<GetAllRequest, Filter>();
    }
}