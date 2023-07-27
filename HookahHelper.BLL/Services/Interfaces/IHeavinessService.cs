using HookahHelper.BLL.ViewModels.Heaviness;

namespace HookahHelper.BLL.Services.Interfaces;

public interface IHeavinessService
{
    Task<IEnumerable<GetHeavinessResponse>> GetOptions();
}