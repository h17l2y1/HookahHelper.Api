using AutoMapper;
using HookahHelper.BLL.Services.Interfaces;
using HookahHelper.BLL.ViewModels.Default;
using HookahHelper.BLL.ViewModels.Tobacco;
using HookahHelper.DAL.Entities;
using HookahHelper.DAL.Repositories.Interfaces;

namespace HookahHelper.BLL.Services;

public class TobaccoService : ITobaccoService
{
    private readonly IMapper _mapper;
    private readonly ITobaccoRepository _repository;

    public TobaccoService(IMapper mapper, ITobaccoRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task Create(CreateTobaccoRequest request)
    {
        var entity = _mapper.Map<Tobacco>(request);
        await _repository.Create(entity);
    }

    public async Task<GetTobaccoResponse> GetById(string id)
    {
        var entity = await _repository.GetById(id);
        var response = _mapper.Map<GetTobaccoResponse>(entity);
        return response;
    }

    public async Task<GetAllResponse<GetTobaccoResponse>>GetAll(GetAllRequest request)
    {
        int total = await _repository.Count(request.FilterBy);
        var response = new GetAllResponse<GetTobaccoResponse>(total);
        if (total > 0)
        {
            int skip = request.Page * request.Take;
            var entities = await _repository.GetAll(skip, request.Take, request.SortBy, request.Column, request.FilterBy);
            var list = _mapper.Map<IEnumerable<GetTobaccoResponse>>(entities);
            response.List = list;
        }
        
        return response;
    }
    
    public async Task Update(UpdateTobaccoRequest request)
    {
        var entity = _mapper.Map<Tobacco>(request);
        await _repository.Update(entity);
    }

    public async Task Remove(string id)
    {
        await _repository.Remove(id);
    }
}