using HookahHelper.BLL.ViewModels.Brands;
using HookahHelper.BLL.ViewModels.Default;

namespace HookahHelper.BLL.Services.Interfaces;

public interface IBrandService
{
    Task<GetBrandResponse> GetById(int id);
    Task<GetAllResponse<GetBrandResponse>> GetAll(GetAllRequest request);
    Task<IEnumerable<GetBrandOption>>GetOptions();
    Task Create(CreateBrandRequest request);
    Task Update(UpdateBrandRequest request);
    Task Remove(int id);
}