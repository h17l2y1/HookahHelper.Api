using HookahHelper.BLL.ViewModels.Image;

namespace HookahHelper.BLL.Services.Interfaces;

public interface IImageService
{
    Task<GetImageResponse> GetById(int id);
    
    Task Create(CreateImageRequest request);
    
    Task Update(UpdateImageRequest request);
    
    Task Remove(int id);
}