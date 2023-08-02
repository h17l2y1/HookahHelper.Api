using HookahHelper.BLL.ViewModels.Country;
using HookahHelper.BLL.ViewModels.Default;
using HookahHelper.DAL.Entities;

namespace HookahHelper.BLL.Services.Interfaces;

public interface ICountryService
{
    Task<GetCountryResponse> GetById(string id);
    
    Task<IEnumerable<GetCountryResponse>>GetOptions();
    
    Task Create(CreateCountryRequest request);
    
    Task Update(UpdateCountryRequest request);
    
    Task Remove(string id);
}