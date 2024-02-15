using AutoMapper;
using HookahHelper.BLL.Services.Interfaces;
using HookahHelper.BLL.ViewModels.Default;
using HookahHelper.BLL.ViewModels.Mix;
using HookahHelper.DAL.Entities;
using HookahHelper.DAL.Entities.Models;
using HookahHelper.DAL.Repositories.Interfaces;

namespace HookahHelper.BLL.Services;

public class MixService : IMixService
{
    private readonly IMixRepository _repository;
    private readonly IMapper _mapper;

    public MixService(IMixRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    
    public async Task<MixResponse> GetById(string id)
    {
        Mix? entity = await _repository.GetById(id);
        var response = _mapper.Map<MixResponse>(entity);
        return response;
    }

    public async Task Create(MixRequest request)
    {
        var entity = _mapper.Map<Mix>(request);
        await _repository.Create(entity);
    }
    
    public async Task<GetAllResponse<MixResponse>> GetAll(GetAllRequest request)
    {
        var filters = _mapper.Map<Filter>(request);
        int total = await _repository.Count(filters);
        var response = new GetAllResponse<MixResponse>(total);
        if (total > 0)
        {
            int skip = request.Page * request.Take;
            var entities = await _repository.GetAll(skip, request.Take, request.SortBy, request.Column, filters);
            var list = _mapper.Map<IEnumerable<MixResponse>>(entities);
            response.List = list;
        }
    
        return response;
    }
}