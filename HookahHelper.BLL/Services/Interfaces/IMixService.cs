using HookahHelper.BLL.ViewModels.Default;
using HookahHelper.BLL.ViewModels.Mix;

namespace HookahHelper.BLL.Services.Interfaces;

public interface IMixService
{
    Task<MixResponse> GetById(string id);

    Task Create(MixRequest request);
    
    Task<GetAllResponse<MixResponse>>GetAll(GetAllRequest request);
}