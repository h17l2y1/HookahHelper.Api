using System.Text;
using HookahHelper.BLL.Config;
using HookahHelper.BLL.Models;
using HookahHelper.BLL.Services.Interfaces;
using ImgurSharp;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace HookahHelper.BLL.Services;

public class ImgurService : IImgurService
{
    private readonly ImgurOptions _options;
    private readonly HttpClient _client;

    public ImgurService(HttpClient client, IOptions<ImgurOptions> options)
    {
        _client = client;
        _options = options.Value;
    }

    public async Task<string> UploadImage(string name, string base64)
    {
        string payload = ExtractBase64Payload(base64);
        ImgurImage image = await UploadImageAsync(payload, name, "title", "description");

        if (string.IsNullOrWhiteSpace(image.Link))
        {
            throw new InvalidOperationException("Imgur returned an empty link.");
        }

        return image.Link;
    }

    private async Task<ImgurImage> UploadImageAsync(string base64Image, string name, string title, string description)
    {
        using var request = new HttpRequestMessage(HttpMethod.Post, "upload");
        request.Headers.Add("Authorization", BuildAuthorizationHeader());

        var jsonData = JsonConvert.SerializeObject(new
        {
            image = base64Image,
            name,
            title,
            description
        });

        request.Content = new StringContent(jsonData, Encoding.UTF8, "application/json");

        HttpResponseMessage response = await _client.SendAsync(request);
        string content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new InvalidOperationException($"Imgur upload failed with status {(int)response.StatusCode}: {content}");
        }

        ResponseRootObject<ImgurImage>? imgRoot = JsonConvert.DeserializeObject<ResponseRootObject<ImgurImage>>(content);

        if (imgRoot is null || !imgRoot.Success || imgRoot.Data is null)
        {
            throw new InvalidOperationException($"Unexpected Imgur response: {content}");
        }

        return imgRoot.Data;
    }

    private string BuildAuthorizationHeader()
    {
        if (!string.IsNullOrWhiteSpace(_options.AccessToken))
        {
            return "Bearer " + _options.AccessToken;
        }

        if (string.IsNullOrWhiteSpace(_options.ClientId))
        {
            throw new InvalidOperationException("Imgur ClientId is not configured.");
        }

        return "Client-ID " + _options.ClientId;
    }

    private static string ExtractBase64Payload(string base64)
    {
        if (string.IsNullOrWhiteSpace(base64))
        {
            throw new ArgumentException("Image payload is empty.", nameof(base64));
        }

        int commaIndex = base64.IndexOf(",", StringComparison.Ordinal);

        return commaIndex >= 0 ? base64[(commaIndex + 1)..] : base64;
    }
}
