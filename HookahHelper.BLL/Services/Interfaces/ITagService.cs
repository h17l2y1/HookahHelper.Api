using HookahHelper.BLL.ViewModels.Default;
using HookahHelper.BLL.ViewModels.Tag;

namespace HookahHelper.BLL.Services.Interfaces;

public interface ITagService
{
    Task<GetTagResponse> GetById(string id);
    
    Task<GetAllResponse<GetTagResponse>>GetAll(GetAllRequest request);
    
    Task Create(CreateTagRequest request);
    
    Task Update(UpdateTagRequest request);
    
    Task Remove(string id);
}