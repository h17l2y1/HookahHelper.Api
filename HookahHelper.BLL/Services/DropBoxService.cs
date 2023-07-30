using Dropbox.Api;
using Dropbox.Api.Files;
using HookahHelper.BLL.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;
using System.Text.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace HookahHelper.BLL.Services;

public class Res
{
    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }
}

public class DropBoxService : IDropBoxService
{
    private IConfiguration _configuration;
    private readonly string _accessToken;
    private readonly string _appKey;
    private readonly string _appSecret;

    public DropBoxService(IConfiguration configuration)
    {
        _configuration = configuration;
        _accessToken = _configuration.GetSection("DropBoxAccessToken").Value;
        _appKey = _configuration.GetSection("DropBoxAccessToken").Value;
        _appSecret = _configuration.GetSection("DropBoxAccessToken").Value;
    }

    public async Task<string?> GetLinkOnImage(string fileName, string base64)
    {
        using (var dropboxClient = new DropboxClient(_accessToken))
        {
            await CheckConnect(dropboxClient);
            byte[] bytes = EncodeFile(base64);

            bool isFileExist = await IsFileExist(dropboxClient, fileName);

            string pathInDropBox = isFileExist ?
                await UpdateFile(dropboxClient, fileName, bytes) :
                await CreateFile(dropboxClient, fileName, bytes);

            string redirectLink = await CreateSharedLinkWithSettingsAsync(dropboxClient, pathInDropBox);
            string link = await GetFinalLink(redirectLink);
            return link;
        }
    }

    private async Task<string> GetFinalLink(string redirectLink)
    {
        using (var client = new HttpClient())
        {
            var response = await client.GetAsync(redirectLink);
            return response?.RequestMessage?.RequestUri?.AbsoluteUri;
        }
    }

    private byte[] EncodeFile(string base64)
    {
        int index = base64.IndexOf(",", StringComparison.Ordinal);
        base64 = base64.Substring(++index);
        byte[] bytes = Convert.FromBase64String(base64);
        return bytes;
    }

    private async Task<string> CreateFile(DropboxClient dropboxClient, string fileName, byte[] content)
    {
        var name = $"/{fileName}.png";
        using (var memoryStream = new MemoryStream(content))
        {
            var updated =
                await dropboxClient.Files.UploadAsync(name, WriteMode.Overwrite.Instance, body: memoryStream);
            return updated.PathLower;
        }
    }

    private async Task<string> UpdateFile(DropboxClient dropboxClient, string fileName, byte[] content)
    {
        var name = $"/{fileName}.png";
        await dropboxClient.Files.DeleteV2Async(name);
        
        using (var memoryStream = new MemoryStream(content))
        {
            var updated = await dropboxClient.Files.UploadAsync(name, WriteMode.Overwrite.Instance, body: memoryStream);
            return updated.PathLower;
        }
    }
    
    public async Task<byte[]> GetFile(string file)
    {
        var name = "/" + file;

        using (var dropBox = new DropboxClient(_accessToken))
        {
            using (var response = await dropBox.Files.DownloadAsync(name))
            {
                return await response.GetContentAsByteArrayAsync();
            }
        }
    }

    private async Task<bool> IsFileExist(DropboxClient dropboxClient, string name)
    {
        return await dropboxClient.Files.GetMetadataAsync(name) == null;
    }

    private async Task<string> CreateSharedLinkWithSettingsAsync(DropboxClient dropboxClient, string path)
    {
        var response = await dropboxClient.Sharing.CreateSharedLinkWithSettingsAsync(path);
        return response.Url + "&raw=1";
    }

    private Res Auth()
    {
        Chilkat.OAuth2 oauth2 = new Chilkat.OAuth2();
        oauth2.ListenPort = 3017;
        oauth2.AuthorizationEndpoint = "https://www.dropbox.com/oauth2/authorize";
        oauth2.TokenEndpoint = "https://api.dropboxapi.com/oauth2/token";

        oauth2.ClientId = _appKey;
        oauth2.ClientSecret = _appSecret;
        oauth2.CodeChallenge = false;
        oauth2.AddAuthQueryParam("token_access_type", "offline");

        string url = oauth2.StartAuth();
        if (oauth2.LastMethodSuccess != true)
        {
        }

        Process.Start(new ProcessStartInfo(url) {UseShellExecute = true});

        int numMsWaited = 0;
        while ((numMsWaited < 30000) && (oauth2.AuthFlowState < 3))
        {
            oauth2.SleepMs(100);
            numMsWaited = numMsWaited + 100;
        }

        if (oauth2.AuthFlowState == 5)
        {
            Debug.WriteLine("OAuth2 failed to complete.");
            Debug.WriteLine(oauth2.FailureInfo);
        }

        if (oauth2.AuthFlowState == 4)
        {
            Debug.WriteLine("OAuth2 authorization was denied.");
            Debug.WriteLine(oauth2.AccessTokenResponse);
        }

        if (oauth2.AuthFlowState != 3)
        {
            Debug.WriteLine("Unexpected AuthFlowState:" + Convert.ToString(oauth2.AuthFlowState));
        }

        Chilkat.JsonObject json = new Chilkat.JsonObject();
        json.Load(oauth2.AccessTokenResponse);
        json.EmitCompact = false;

        return new Res
        {
            AccessToken = oauth2.AccessToken,
            RefreshToken = oauth2.RefreshToken
        };
    }

    private async Task CheckConnect(DropboxClient dropboxClient)
    {
        try
        {
            _ = await dropboxClient.Check.UserAsync();
        }
        catch (Exception ex)
        {
            if (ex is AuthException)
            {
                var res = Auth();
                UpdateAppSetting("DropBoxAccessToken", res.AccessToken);
            }
        }
    }

    private void UpdateAppSetting(string key, string value)
    {
        var configJson = File.ReadAllText("appsettings.json");
        var config = JsonSerializer.Deserialize<Dictionary<string, object>>(configJson);
        config[key] = value;
        var updatedConfigJson = JsonSerializer.Serialize(config, new JsonSerializerOptions {WriteIndented = true});
        File.WriteAllText("appsettings.json", updatedConfigJson);
    }
}