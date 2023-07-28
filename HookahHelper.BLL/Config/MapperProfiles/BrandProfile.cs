using AutoMapper;
using HookahHelper.BLL.ViewModels.Brands;
using HookahHelper.DAL.Entities;

namespace HookahHelper.BLL.Config.MapperProfiles;

public class BrandProfile: Profile
{
    public BrandProfile()
    {
        CreateMap<CreateBrandRequest, Brand>()
            .ForMember(to => to.Name, from => from.MapFrom(source => $"tobacco: {source.Name}"));
        CreateMap<UpdateBrandRequest, Brand>();
        CreateMap<Brand, GetBrandResponse>();
        CreateMap<Brand, GetBrandOption>();
    }

    // private IEnumerable<LinesUpdateInner> aaa(IEnumerable<LinesUpdateInner>? lines, string brandId)
    // {
    //     foreach (var line in lines.Where(x => x.IsNew))
    //     {
    //         line.BrandId = brandId;
    //     }
    //
    //     return lines;
    // }
}


// CreateMap<User, DAL.Entities.User>()
//     .ForMember(to => to.Id, from => from.Ignore())
//     .ForMember(to => to.ClientId, from => from.MapFrom(source => source.Id.ToString()))
//     .ForMember(to => to.Name, from => from.MapFrom(source => $"{source.FirstName} {source.LastName}"))
//     .ForMember(to => to.Language, from => from.MapFrom(source => source.LanguageCode))
//     .ForMember(to => to.IsTelegram, from => from.MapFrom(source => true));
