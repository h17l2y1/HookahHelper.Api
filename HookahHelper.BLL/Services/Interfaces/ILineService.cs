using HookahHelper.BLL.ViewModels.Line;
using HookahHelper.DAL.Entities;

namespace HookahHelper.BLL.Services.Interfaces;

public interface ILineService
{
    Task<GetLineResponse> GetById(int id);
    
    Task Create(CreateLineRequest request);
    
    Task Update(UpdateLineRequest request);
    
    Task Remove(int id);

    Task<IEnumerable<GetLineResponse>>GetLinesByBrandId(int brandId);
}