using AutoMapper;
using HookahHelper.BLL.Services.Interfaces;
using HookahHelper.BLL.ViewModels.Heaviness;
using HookahHelper.DAL.Entities;
using HookahHelper.DAL.Repositories.Interfaces;

namespace HookahHelper.BLL.Services;

public class HeavinessService: IHeavinessService
{
    private readonly IMapper _mapper;
    private readonly IHeavinessRepository _repository;

    public HeavinessService(IMapper mapper, IHeavinessRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }
    
    public async Task<IEnumerable<GetHeavinessResponse>> GetOptions()
    {
        IEnumerable<Heaviness> entities = await _repository.GetOptions();
        var response = _mapper.Map<IEnumerable<GetHeavinessResponse>>(entities);

        return response;
    }
    
}