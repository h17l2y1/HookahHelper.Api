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

    public async Task<GetLineResponse> GetById(string id)
    {
        var entity = await _repository.GetById(id);
        var response = _mapper.Map<GetLineResponse>(entity);
        return response;
    }

    public async Task<GetAllResponse<GetLineResponse>> GetAll(GetAllRequest request)
    {
        int total = await _repository.Count();
        var response = new GetAllResponse<GetLineResponse>(total);
        if (total > 0)
        {
            int skip = (request.Page - 1) * request.Take;
            var entities = await _repository.GetAll(skip, request.Take);
            var lines = _mapper.Map<IEnumerable<GetLineResponse>>(entities);
            response.List = lines;
        }

        return response;
    }

    public async Task Update(UpdateLineRequest request)
    {
        var entity = _mapper.Map<Line>(request);
        await _repository.Update(entity);
    }

    public async Task Remove(string id)
    {
        await _repository.Remove(id);
    }
}