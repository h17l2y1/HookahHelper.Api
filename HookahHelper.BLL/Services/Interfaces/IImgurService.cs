namespace HookahHelper.BLL.Services.Interfaces;

public interface IImgurService
{
    Task<string> UploadImage(string name, string base64);
}