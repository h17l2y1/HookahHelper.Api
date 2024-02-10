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
    private readonly ITobaccoRepository _tobaccoRepository;
    private readonly IImgurService _imgurService;
    private readonly ITobaccoTagRepository _tobaccoTagRepository;

    public TobaccoService(IMapper mapper, ITobaccoRepository tobaccoRepository, IImgurService imgurService, ITobaccoTagRepository tobaccoTagRepository)
    {
        _mapper = mapper;
        _tobaccoRepository = tobaccoRepository;
        _imgurService = imgurService;
        _tobaccoTagRepository = tobaccoTagRepository;
    }

    public async Task Create(CreateTobaccoRequest request)
    {
        var entity = _mapper.Map<Tobacco>(request);
        entity.Image.Link = _imgurService.UploadImage(request.Name, request.Image.Base64);
        await _tobaccoRepository.Create(entity);
    }

    public async Task<GetTobaccoResponse> GetById(string id)
    {
        Tobacco? entity = await _tobaccoRepository.GetById(id);
        var response = _mapper.Map<GetTobaccoResponse>(entity);
        return response;
    }

    public async Task<GetAllResponse<GetTobaccoResponse>>GetAll(GetAllRequest request)
    {
        var filters = _mapper.Map<Filter>(request);
        int total = await _tobaccoRepository.Count(filters);
        var response = new GetAllResponse<GetTobaccoResponse>(total);
        if (total > 0)
        {
            int skip = request.Page * request.Take;
            IEnumerable<Tobacco> entities = await _tobaccoRepository.GetAll(skip, request.Take, request.SortBy, request.Column, filters);
            var list = _mapper.Map<IEnumerable<GetTobaccoResponse>>(entities);
            response.List = list;
        }
        
        return response;
    }
    
    public async Task Update(UpdateTobaccoRequest request)
    {
        if (request.Image.Base64 != null)
        {
            request.Image.Link = _imgurService.UploadImage(request.Name, request.Image.Base64);
        }
        
        var entity = _mapper.Map<Tobacco>(request);
            
        var removedTagsViews = request.TobaccoTags!.Where(x => x.IsRemoved == true);
        var newTagsViews = request.TobaccoTags!.Where(x => x.IsNew == true);
        if (removedTagsViews.Any())
        {
            var removedTags = _mapper.Map<IEnumerable<TobaccoTag>>(removedTagsViews);
            await _tobaccoTagRepository.RemoveRange(removedTags);
        }
        if (newTagsViews.Any())
        {
            var newTags = _mapper.Map<IEnumerable<TobaccoTag>>(newTagsViews);
            await _tobaccoTagRepository.Create(newTags);
        }

        await _tobaccoRepository.Update(entity);
    }

    public async Task Remove(string id)
    {
        await _tobaccoRepository.Remove(id);
    }

    public async Task<IEnumerable<GetTobaccoResponse>> GetByBrandId(string brandId)
    {
        IEnumerable<Tobacco> entities = await _tobaccoRepository.GetByBrandId(brandId);
        var response = _mapper.Map<IEnumerable<GetTobaccoResponse>>(entities);
        return response;
    }
}