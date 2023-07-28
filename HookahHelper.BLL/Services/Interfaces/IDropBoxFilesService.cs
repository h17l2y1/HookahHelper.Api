namespace HookahHelper.BLL.Services.Interfaces;

public interface IDropBoxFilesService
{
    Task<byte[]> GetFile(string file);
    Task WriteFile(string fileName, byte[] content);
}