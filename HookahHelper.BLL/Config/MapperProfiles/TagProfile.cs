using AutoMapper;
using HookahHelper.BLL.ViewModels.Image;
using HookahHelper.BLL.ViewModels.Tag;
using HookahHelper.BLL.ViewModels.Tobacco;
using HookahHelper.BLL.ViewModels.TobaccoTag;
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