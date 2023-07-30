namespace HookahHelper.BLL.Services.Interfaces;

public interface IDropBoxService
{
    Task<string?> GetCreateLink(string name, string base64);

    Task<string?> GetUpdateLink(string fileName, string base64);
}