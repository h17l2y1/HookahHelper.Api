using AutoMapper;
using HookahHelper.BLL.Services.Interfaces;
using HookahHelper.BLL.ViewModels.Country;
using HookahHelper.BLL.ViewModels.Default;
using HookahHelper.DAL.Entities;
using HookahHelper.DAL.Entities.Models;
using HookahHelper.DAL.Repositories.Interfaces;

namespace HookahHelper.BLL.Services;

public class CountryService : ICountryService
{
    private readonly IMapper _mapper;
    private readonly ICountryRepository _repository;

    public CountryService(IMapper mapper, ICountryRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task Create(CreateCountryRequest request)
    {
        var entity = _mapper.Map<Country>(request);
        await _repository.Create(entity);
    }

    public async Task<GetCountryResponse> GetById(string id)
    {
        Country? entity = await _repository.GetById(id);
        var response = _mapper.Map<GetCountryResponse>(entity);
        return response;
    }

    public async Task<IEnumerable<GetCountryResponse>> GetOptions()
    {
        IEnumerable<Country> entities = await _repository.GetOptions();
        var response = _mapper.Map<IEnumerable<GetCountryResponse>>(entities);

        return response;
    }

    public async Task Update(UpdateCountryRequest request)
    {
        var entity = _mapper.Map<Country>(request);
        await _repository.Update(entity);
    }

    public async Task Remove(string id)
    {
        await _repository.Remove(id);
    }
}