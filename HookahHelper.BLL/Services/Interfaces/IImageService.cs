using HookahHelper.BLL.ViewModels.Default;
using HookahHelper.BLL.ViewModels.Image;
using HookahHelper.DAL.Entities;

namespace HookahHelper.BLL.Services.Interfaces;

public interface IImageService
{
    Task<GetImageResponse> GetById(string id);
    Task<GetAllResponse<Image>> GetAll(GetAllRequest request);
    Task Create(CreateImageRequest request);
    Task Update(UpdateImageRequest request);
    Task Remove(string id);
}