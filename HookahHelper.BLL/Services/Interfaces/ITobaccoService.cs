using HookahHelper.BLL.ViewModels.Default;
using HookahHelper.BLL.ViewModels.Tobacco;

namespace HookahHelper.BLL.Services.Interfaces;

public interface ITobaccoService
{
    Task<GetTobaccoResponse> GetById(int id);
    Task<GetAllResponse<GetTobaccoResponse>> GetAll(GetAllRequest request);
    Task Create(CreateTobaccoRequest request);
    Task Update(UpdateTobaccoRequest request);
    Task Remove(int id);
    Task<IEnumerable<GetTobaccoResponse>> GetByBrandId(int brandId);
}