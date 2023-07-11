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

    public async Task<GetAllResponse<Brand>>GetAll(GetAllRequest request)
    {
        int total = await _repository.Count();
        var response = new GetAllResponse<Brand>(total);
        if (total > 0)
        {
            int skip = (request.Page - 1) * request.Take;
            response.List = await _repository.GetAll(skip, request.Take);
        }
        
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