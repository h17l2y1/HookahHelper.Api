using AutoMapper;
using HookahHelper.BLL.Services.Interfaces;
using HookahHelper.BLL.ViewModels.Brands;
using HookahHelper.BLL.ViewModels.Default;
using HookahHelper.DAL.Entities;
using HookahHelper.DAL.Entities.Models;
using HookahHelper.DAL.Repositories.Interfaces;

namespace HookahHelper.BLL.Services;

public class BrandService : IBrandService
{
    private readonly IMapper _mapper;
    private readonly IBrandRepository _brandRepository;
    private readonly ILineRepository _lineRepository;
    private readonly IDropBoxService _dropBox;

    public BrandService(IMapper mapper, IBrandRepository brandRepository, ILineRepository lineRepository, IDropBoxService dropBox)
    {
        _mapper = mapper;
        _brandRepository = brandRepository;
        _lineRepository = lineRepository;
        _dropBox = dropBox;
    }

    public async Task Create(CreateBrandRequest request)
    {
        var link = await _dropBox.GetCreateLink(request.Name, request.Image.Base64);
        var entity = _mapper.Map<Brand>(request);
        entity.Image.Name = $"brand: {request.Name}";
        entity.Image.Link = link;
        await _brandRepository.Create(entity);
    }

    public async Task<GetBrandResponse> GetById(string id)
    {
        var entity = await _brandRepository.GetById(id);
        var response = _mapper.Map<GetBrandResponse>(entity);
        return response;
    }

    public async Task<GetAllResponse<GetBrandResponse>> GetAll(GetAllRequest request) 
    {
        var filters = _mapper.Map<Filter>(request);
        int total = await _brandRepository.Count(filters);
        var response = new GetAllResponse<GetBrandResponse>(total);
        if (total > 0)
        {
            int skip = request.Page * request.Take;
            var entities = await _brandRepository.GetAll(skip, request.Take, request.SortBy, request.Column, filters);
            var list = _mapper.Map<IEnumerable<GetBrandResponse>>(entities);
            response.List = list;
        }

        return response;
    }

    public async Task<IEnumerable<GetBrandOption>> GetOptions()
    {
        var entities = await _brandRepository.GetAll();
        var response = _mapper.Map<IEnumerable<GetBrandOption>>(entities);

        return response;
    }

    public async Task Update(UpdateBrandRequest request)
    {
        var link = await _dropBox.GetUpdateLink(request.Name, request.Image.Base64);
        var newLines = request.Lines?.Where(x => x.IsNew);
        var updatedLines = request.Lines?.Where(x => !x.IsNew);

        if (newLines != null)
        {
            foreach (var newLine in newLines)
            {
                newLine.BrandId = request.Id;
            }
            
            var lines = _mapper.Map<IEnumerable<Line>>(newLines);
            await _lineRepository.Create(lines);
        }

        request.Lines = updatedLines;
        var entity = _mapper.Map<Brand>(request);
        entity.Image.Name = $"brand: {request.Name}";
        entity.Image.Link = link;
        await _brandRepository.Update(entity);
    }

    public async Task Remove(string id)
    {
        await _brandRepository.Remove(id);
    }
}