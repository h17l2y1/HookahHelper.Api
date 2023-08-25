using AutoMapper;
using HookahHelper.BLL.ViewModels.Brands;
using HookahHelper.BLL.ViewModels.Image;
using HookahHelper.DAL.Entities;

namespace HookahHelper.BLL.Config.MapperProfiles;

public class ImageProfile:Profile
{
    public ImageProfile()
    {
        CreateMap<CreateImageRequest, Image>()
            .ForMember(to => to.Name, from => from.MapFrom(source => source.Name.Trim()));
        CreateMap<UpdateImageRequest, Image>()
            .ForMember(to => to.Name, from => from.MapFrom(source => source.Name.Trim()));
        CreateMap<ImageInner, Image>();
        CreateMap<Image, GetImageResponse>();
    }
}