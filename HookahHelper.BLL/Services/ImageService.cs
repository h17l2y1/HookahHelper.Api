using AutoMapper;
using HookahHelper.BLL.Services.Interfaces;
using HookahHelper.BLL.ViewModels.Default;
using HookahHelper.BLL.ViewModels.Image;
using HookahHelper.DAL.Entities;
using HookahHelper.DAL.Repositories.Interfaces;

namespace HookahHelper.BLL.Services;

public class ImageService:IImageService
{
    private readonly IMapper _mapper;
    private readonly IImageRepository _repository;

    public ImageService(IMapper mapper, IImageRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task Create(CreateImageRequest request)
    {
        var entity = _mapper.Map<Image>(request);
        await _repository.Create(entity);
    }

    public async Task<GetImageResponse> GetById(string id)
    {
        var entity = await _repository.GetById(id);
        var response = _mapper.Map<GetImageResponse>(entity);
        return response;
    }

    public async Task<GetAllResponse<Image>>GetAll(GetAllRequest request)
    {
        int total = await _repository.Count();
        var response = new GetAllResponse<Image>(total);
        if (total > 0)
        {
            response.List = await _repository.GetAll2(request.Skip, request.Take);
        }
        
        return response;
    }


    public async Task Update(UpdateImageRequest request)
    {
        bool isExist = await _repository.IsExist(request.Id);
        if (isExist)
        {
            var entity = _mapper.Map<Image>(request);
            await _repository.Update(entity);
        }
    }

    public async Task Remove(string id)
    {
        await _repository.Remove(id);
    }
}