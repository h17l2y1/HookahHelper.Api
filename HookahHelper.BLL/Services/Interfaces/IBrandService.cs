using HookahHelper.BLL.ViewModels.Brands;
using HookahHelper.BLL.ViewModels.Default;
using HookahHelper.DAL.Entities;

namespace HookahHelper.BLL.Services.Interfaces;

public interface IBrandService
{
    Task<GetBrandResponse> GetById(string id);
    Task<GetAllResponse<Brand>> GetAll(GetAllRequest request);
    Task Create(CreateBrandRequest request);
    Task Update(UpdateBrandRequest request);
    Task Remove(string id);
}