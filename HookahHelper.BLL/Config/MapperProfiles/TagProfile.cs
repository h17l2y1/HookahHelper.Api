using AutoMapper;
using HookahHelper.BLL.ViewModels.Tag;
using HookahHelper.DAL.Entities;

namespace HookahHelper.BLL.Config.MapperProfiles;

public class TagProfile: Profile
{
    public TagProfile()
    {
        CreateMap<CreateTagRequest, Tag>()
            .ForMember(to => to.Name, from => from.MapFrom(source => source.Name.Trim()));
        CreateMap<UpdateTagRequest, Tag>();
        CreateMap<Tag, GetTagResponse>().ReverseMap();
    }
}