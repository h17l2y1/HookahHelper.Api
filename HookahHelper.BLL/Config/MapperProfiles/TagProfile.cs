using AutoMapper;
using HookahHelper.BLL.ViewModels.Tag;
using HookahHelper.DAL.Entities;

namespace HookahHelper.BLL.Config.MapperProfiles;

public class TagProfile: Profile
{
    public TagProfile()
    {
        CreateMap<CreateTagRequest, Tag>();
        CreateMap<UpdateTagRequest, Tag>();
        CreateMap<Tag, GetTagResponse>();
    }
}