using AutoMapper;
using HookahHelper.BLL.ViewModels.Country;
using HookahHelper.DAL.Entities;

namespace HookahHelper.BLL.Config.MapperProfiles;

public class CountryProfile:Profile
{
    public CountryProfile()
    {
        CreateMap<CreateCountryRequest, Country>()
            .ForMember(to => to.Name, from => from.MapFrom(source => source.Name.Trim()));
        CreateMap<UpdateCountryRequest, Country>()
            .ForMember(to => to.Name, from => from.MapFrom(source => source.Name.Trim()));
        CreateMap<Country, GetCountryResponse>();
    }
}