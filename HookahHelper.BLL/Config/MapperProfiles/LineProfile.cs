using AutoMapper;
using HookahHelper.BLL.ViewModels.Line;
using HookahHelper.DAL.Entities;

namespace HookahHelper.BLL.Config.MapperProfiles;

public class LineProfile: Profile
{
    public LineProfile()
    {
        CreateMap<CreateLineRequest, Line>();
        CreateMap<GetLineResponse, Line>().ReverseMap();
        CreateMap<UpdateLineResponse, Line>();
        // CreateMap<UpdateLineResponse, Line>().ForMember(to => to.Id, from => from.Ignore());
    }
}