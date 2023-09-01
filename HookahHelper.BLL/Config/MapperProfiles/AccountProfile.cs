using AutoMapper;
using HookahHelper.BLL.ViewModels.Account;
using HookahHelper.DAL.Entities;

namespace HookahHelper.BLL.Config.MapperProfiles;

public class AccountProfile : Profile
{
    public AccountProfile()
    {
        CreateMap<SignUp, User>()
            .ForMember(to => to.FirstName, from => from.MapFrom(source => source.FirstName.Trim()))
            .ForMember(to => to.LastName, from => from.MapFrom(source => source.LastName.Trim()))
            .ForMember(to => to.Email, from => from.MapFrom(source => source.Email.Trim()))
            .ForMember(to => to.Password, from => from.MapFrom(source => source.Password.Trim()));
    }
}