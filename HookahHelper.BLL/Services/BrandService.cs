using AutoMapper;
using HookahHelper.BLL.Services.Interfaces;
using HookahHelper.BLL.ViewModels.Brands;
using HookahHelper.BLL.ViewModels.Default;
using HookahHelper.DAL.Entities;
using HookahHelper.DAL.Repositories.Interfaces;

namespace HookahHelper.BLL.Services;

public class BrandService : IBrandService
{
    private readonly IMapper _mapper;
    private readonly IBrandRepository _repository;

    public BrandService(IMapper mapper, IBrandRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task Create(CreateBrandRequest request)
    {
        var entity = _mapper.Map<Brand>(request);
        await _repository.Create(entity);
    }

    public async Task<GetBrandResponse> GetById(string id)
    {
        var entity = await _repository.GetById(id);
        var response = _mapper.Map<GetBrandResponse>(entity);
        return response;
    }

    public async Task<GetAllResponse<GetBrandResponse>>GetAll(GetAllRequest request)
    {
        int total = await _repository.Count(request.FilterBy);
        var response = new GetAllResponse<GetBrandResponse>(total);
        if (total > 0)
        {
            int skip = request.Page * request.Take;
            var entities = await _repository.GetAll(skip, request.Take, request.SortBy, request.Column, request.FilterBy);
            var list = _mapper.Map<IEnumerable<GetBrandResponse>>(entities);
            response.List = list;
        }
        
        return response;
    }
    
    public async Task<IEnumerable<GetBrandOption>>GetOptions()
    {
        var entities = await _repository.GetAll();
        var response = _mapper.Map<IEnumerable<GetBrandOption>>(entities);
        
        return response;
    }
    
    public async Task Update(UpdateBrandRequest request)
    {
        var entity = _mapper.Map<Brand>(request);
        await _repository.Update(entity);
    }

    public async Task Remove(string id)
    {
        await _repository.Remove(id);
    }
}