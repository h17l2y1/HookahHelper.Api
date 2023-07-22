using AutoMapper;
using HookahHelper.BLL.ViewModels.Brands;
using HookahHelper.BLL.ViewModels.Line;
using HookahHelper.DAL.Entities;

namespace HookahHelper.BLL.Config.MapperProfiles;

public class LineProfile: Profile
{
    public LineProfile()
    {
        CreateMap<CreateLineRequest, Line>();
        CreateMap<GetLineResponse, Line>().ReverseMap();
        CreateMap<UpdateLineRequest, Line>();
        CreateMap<LinesInner, Line>();
        CreateMap<LinesInnerUpdate, Line>();
    }
}