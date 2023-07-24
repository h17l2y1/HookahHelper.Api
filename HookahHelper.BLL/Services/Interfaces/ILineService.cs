using HookahHelper.BLL.ViewModels.Line;
using HookahHelper.DAL.Entities;

namespace HookahHelper.BLL.Services.Interfaces;

public interface ILineService
{
    Task<GetLineResponse> GetById(string id);
    
    Task Create(CreateLineRequest request);
    
    Task Update(UpdateLineRequest request);
    
    Task Remove(string id);

    Task<IEnumerable<GetLineResponse>>GetLinesByBrandId(string brandId);
}