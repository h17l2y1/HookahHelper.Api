using AutoMapper;
using HookahHelper.BLL.ViewModels.Brands;
using HookahHelper.BLL.ViewModels.Tobacco;
using HookahHelper.DAL.Entities;

namespace HookahHelper.BLL.Config.MapperProfiles;

public class BrandProfile: Profile
{
    public BrandProfile()
    {
        CreateMap<CreateBrandRequest, Brand>()
            .ForMember(to => to.Name, from => from.MapFrom(source => source.Name.Trim()));
        CreateMap<UpdateBrandRequest, Brand>()
            .ForMember(to => to.Name, from => from.MapFrom(source => source.Name.Trim()));
        CreateMap<Brand, GetBrandResponse>();
        CreateMap<Brand, GetBrandOption>();
        CreateMap<Brand, GetBrandInner>();
    }
}