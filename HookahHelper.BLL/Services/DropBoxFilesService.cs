using Dropbox.Api;
using Dropbox.Api.Files;
using HookahHelper.BLL.Services.Interfaces;
using Microsoft.Extensions.Configuration;

namespace HookahHelper.BLL.Services;

public class DropBoxFilesService : IDropBoxFilesService
{
    private IConfiguration _configuration;
    public DropBoxFilesService(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public async Task<byte[]> GetFile(string file)
    {
        string accessToken = _configuration.GetSection("DropBoxAccessToken").Value;
        
        var name = "/" + file;
        
        using (var dropBox = new DropboxClient(accessToken))
        using (var response = await dropBox.Files.DownloadAsync(name))
        {
            var xxx = await dropBox.Files.GetPreviewAsync(name);
            var x = await response.GetContentAsByteArrayAsync();
            return x;
        }
    }

    public async Task WriteFile(string fileName, byte[] content)
    {
        string accessToken = _configuration.GetSection("DropBoxAccessToken").Value;
        using (var dropBox = new DropboxClient(accessToken))
        using (var memoryStream = new MemoryStream(content))
        {
            var updated = await dropBox.Files.UploadAsync(
                "/" + fileName,
                WriteMode.Overwrite.Instance,
                body: memoryStream);
        }
    }
}