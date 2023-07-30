using AutoMapper;
using HookahHelper.BLL.Services.Interfaces;
using HookahHelper.BLL.ViewModels.Default;
using HookahHelper.BLL.ViewModels.Tobacco;
using HookahHelper.DAL.Entities;
using HookahHelper.DAL.Entities.Models;
using HookahHelper.DAL.Repositories.Interfaces;

namespace HookahHelper.BLL.Services;

public class TobaccoService : ITobaccoService
{
    private readonly IMapper _mapper;
    private readonly ITobaccoRepository _repository;
    private readonly IDropBoxService _dropBox;

    public TobaccoService(IMapper mapper, ITobaccoRepository repository, IDropBoxService dropBox)
    {
        _mapper = mapper;
        _repository = repository;
        _dropBox = dropBox;
    }

    public async Task Create(CreateTobaccoRequest request)
    {
        var link = await _dropBox.GetLinkOnImage(request.Name, request.Image.Base64);
        var entity = _mapper.Map<Tobacco>(request);
        entity.Image.Name = $"tobacco: {request.Name}";
        entity.Image.Link = link;
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
        var filters = _mapper.Map<Filter>(request);
        int total = await _repository.Count(filters);
        var response = new GetAllResponse<GetTobaccoResponse>(total);
        if (total > 0)
        {
            int skip = request.Page * request.Take;
            var entities = await _repository.GetAll(skip, request.Take, request.SortBy, request.Column, filters);
            var list = _mapper.Map<IEnumerable<GetTobaccoResponse>>(entities);
            response.List = list;
        }
        
        return response;
    }
    
    public async Task Update(UpdateTobaccoRequest request)
    {
        var link = await _dropBox.GetLinkOnImage(request.Name, request.Image.Base64);
        var entity = _mapper.Map<Tobacco>(request);
        entity.Image.Name = $"tobacco: {request.Name}";
        entity.Image.Link = link;
        await _repository.Update(entity);
    }

    public async Task Remove(string id)
    {
        await _repository.Remove(id);
    }
}