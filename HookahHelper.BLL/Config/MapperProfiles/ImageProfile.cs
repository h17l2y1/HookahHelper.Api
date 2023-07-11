using AutoMapper;
using HookahHelper.BLL.ViewModels.Brands;
using HookahHelper.BLL.ViewModels.Image;
using HookahHelper.DAL.Entities;

namespace HookahHelper.BLL.Config.MapperProfiles;

public class ImageProfile:Profile
{
    public ImageProfile()
    {
        CreateMap<CreateImageRequest, Image>();
        CreateMap<UpdateImageRequest, Image>();
        CreateMap<Image, GetBrandResponse>();
    }
}