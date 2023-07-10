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
        // User user = _mapper.Map<SignUpAccountView, User>(view);
        // IdentityResult result = await _userManager.CreateAsync(user);
        //
        var entities = await _repository.GetAll();
        // var response = _mapper.Map(entities);
        return null;
    }


    public Task Update(UpdateBrandRequest request)
    {
        // bool isExist = _repository.GetById(request.Id)
        //
        // var entity = _mapper.Map<Brand>(request);
        // await _repository.Update(entity);
        throw new NotImplementedException();
    }

    public Task Remove(string id)
    {
        throw new NotImplementedException();
    }
}