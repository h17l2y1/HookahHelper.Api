using AutoMapper;
using HookahHelper.BLL.Services.Interfaces;
using HookahHelper.BLL.ViewModels.Default;
using HookahHelper.BLL.ViewModels.Line;
using HookahHelper.DAL.Entities;
using HookahHelper.DAL.Repositories.Interfaces;

namespace HookahHelper.BLL.Services;

public class LineService : ILineService
{
    private readonly IMapper _mapper;
    private readonly ILineRepository _repository;

    public LineService(IMapper mapper, ILineRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task Create(CreateLineRequest request)
    {
        var entity = _mapper.Map<Line>(request);
        await _repository.Create(entity);
    }

    public async Task<GetLineResponse> GetById(int id)
    {
        var entity = await _repository.GetById(id);
        var response = _mapper.Map<GetLineResponse>(entity);
        return response;
    }

    public async Task Update(UpdateLineRequest request)
    {
        var entity = _mapper.Map<Line>(request);
        await _repository.Update(entity);
    }

    public async Task Remove(int id)
    {
        await _repository.Remove(id);
    }

    public async Task<IEnumerable<GetLineResponse>> GetLinesByBrandId(int brandId)
    {
        var entity = await _repository.GetLinesByBrandId(brandId);
        var response = _mapper.Map<IEnumerable<GetLineResponse>>(entity);
        return response;
    }
}