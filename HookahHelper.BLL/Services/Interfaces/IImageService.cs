using HookahHelper.BLL.ViewModels.Image;

namespace HookahHelper.BLL.Services.Interfaces;

public interface IImageService
{
    Task<GetImageResponse> GetById(string id);
    
    Task Create(CreateImageRequest request);
    
    Task Update(UpdateImageRequest request);
    
    Task Remove(string id);
}