using System.Text;
using HookahHelper.BLL.Models;
using HookahHelper.BLL.Services.Interfaces;
using ImgurSharp;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace HookahHelper.BLL.Services;

public class ImgurService : IImgurService
{
    private readonly string _clientId;
    private readonly HttpClient _client;
    private readonly string _baseUrl = "https://api.imgur.com/3/";
    
    public ImgurService(IConfiguration configuration)
    {
        _clientId = configuration.GetSection("Imgur:ClientId").Value!;
        _client = new HttpClient();
        _client.DefaultRequestHeaders.Add("Authorization", "Client-ID " + _clientId);
    }

    public async Task<string> UploadImage(string name, string base64)
    {
        int index = base64.IndexOf(",", StringComparison.Ordinal);
        base64 = base64.Substring(++index);
        ImgurImage image = await UploadImageAnonymous(base64, name, "title", "description");
        return image.Link;
    }
    
    private async Task<ImgurImage> UploadImageAnonymous(string base64Image, string name, string title, string description)
    {
        var jsonData = JsonConvert.SerializeObject(new
        {
            image = base64Image,
            name,
            title,
            description
        });

        var jsonContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
        HttpResponseMessage response = await _client.PostAsync(_baseUrl + "upload", jsonContent);

        string content = await response.Content.ReadAsStringAsync();

        ResponseRootObject<ImgurImage> imgRoot = JsonConvert.DeserializeObject<ResponseRootObject<ImgurImage>>(content);

        return imgRoot.Data;
    }
}