namespace HookahHelper.BLL.Services.Interfaces;

public interface IDropBoxService
{
    Task<string?> GetLinkOnImage(string name, string base64);
}