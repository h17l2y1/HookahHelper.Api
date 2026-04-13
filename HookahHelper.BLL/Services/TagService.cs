using AutoMapper;
using HookahHelper.BLL.Services.Interfaces;
using HookahHelper.BLL.ViewModels.Default;
using HookahHelper.BLL.ViewModels.Tag;
using HookahHelper.DAL.Entities;
using HookahHelper.DAL.Entities.Models;
using HookahHelper.DAL.Repositories.Interfaces;

namespace HookahHelper.BLL.Services;

public class TagService : ITagService
{
    private readonly IMapper _mapper;
    private readonly ITagRepository _repository;

    public TagService(IMapper mapper, ITagRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task Create(CreateTagRequest request)
    {
        await CheckIsExist(request.Name, request.IsGlobal);
        var entity = _mapper.Map<Tag>(request);
        await _repository.Create(entity);
    }

    public async Task<GetTagResponse> GetById(int id)
    {
        Tag? entity = await _repository.GetById(id);
        var response = _mapper.Map<GetTagResponse>(entity);
        return response;
    }

    public async Task<GetAllResponse<GetTagResponse>> GetAll(GetAllRequest request)
    {
        var filters = _mapper.Map<Filter>(request);
        int total = await _repository.Count(filters);
        var response = new GetAllResponse<GetTagResponse>(total);
        if (total > 0)
        {
            int skip = request.Page * request.Take;
            var entities = await _repository.GetAll(skip, request.Take, request.SortBy, request.Column, filters);
            var list = _mapper.Map<IEnumerable<GetTagResponse>>(entities);
            response.List = list;
        }
    
        return response;
    }

    public async Task<IEnumerable<GetTagResponse>> GetOptions()
    {
        var entities = await _repository.GetAll();
        var response = _mapper.Map<IEnumerable<GetTagResponse>>(entities);

        return response;
    }

    public async Task<IEnumerable<GetTagResponse>> GetGlobalOptions()
    {
        var entities = await _repository.GetGlobals();
        var response = _mapper.Map<IEnumerable<GetTagResponse>>(entities);

        return response;
    }
    
    public async Task Update(UpdateTagRequest request)
    {
        await CheckIsExist(request.Name, request.IsGlobal);
        var entity = _mapper.Map<Tag>(request);
        await _repository.Update(entity);
    }

    public async Task Remove(int id)
    {
        await _repository.Remove(id);
    }

    private async Task CheckIsExist(string name, bool isGlobal)
    {
        var isExist = await _repository.IsExist(name, isGlobal);
        if (isExist)
        {
            throw new Exception($"Tag {name} already exist");
        }
    }
}