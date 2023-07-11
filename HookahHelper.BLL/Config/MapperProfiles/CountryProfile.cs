using AutoMapper;
using HookahHelper.BLL.ViewModels.Country;
using HookahHelper.DAL.Entities;

namespace HookahHelper.BLL.Config.MapperProfiles;

public class CountryProfile:Profile
{
    public CountryProfile()
    {
        CreateMap<CreateCountryRequest, Country>();
        CreateMap<UpdateCountryRequest, Country>();
        CreateMap<Country, GetCountryResponse>();
    }
}