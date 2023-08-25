using AutoMapper;
using HookahHelper.BLL.ViewModels.Brands;
using HookahHelper.BLL.ViewModels.Line;
using HookahHelper.DAL.Entities;

namespace HookahHelper.BLL.Config.MapperProfiles;

public class LineProfile: Profile
{
    public LineProfile()
    {
        CreateMap<CreateLineRequest, Line>()
            .ForMember(to => to.Name, from => from.MapFrom(source => source.Name.Trim()));
        CreateMap<GetLineResponse, Line>().ReverseMap();
        CreateMap<UpdateLineRequest, Line>()
            .ForMember(to => to.Name, from => from.MapFrom(source => source.Name.Trim()));
        CreateMap<LinesInner, Line>();
        CreateMap<LinesUpdateInner, Line>()
            .ForMember(to => to.Id, from => from.MapFrom(source => source.Id ?? Guid.NewGuid().ToString()))
            .ForMember(to => to.Name, from => from.MapFrom(source => source.Name.Trim()));
    }
}