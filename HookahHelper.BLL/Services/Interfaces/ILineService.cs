using HookahHelper.BLL.ViewModels.Default;
using HookahHelper.BLL.ViewModels.Line;
using HookahHelper.DAL.Entities;

namespace HookahHelper.BLL.Services.Interfaces;

public interface ILineService
{
    Task<GetLineResponse> GetById(string id);
    Task<GetAllResponse<GetLineResponse>> GetAll(GetAllRequest request);
    Task Create(CreateLineRequest request);
    Task Update(UpdateLineRequest request);
    Task Remove(string id);
}