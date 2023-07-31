using System.Net;
using HookahHelper.BLL.Models;
using HookahHelper.BLL.Services.Interfaces;
using System.Text.Json;
using Microsoft.Extensions.Configuration;

namespace HookahHelper.BLL.Services;

public class ImgurService : IImgurService
{
    private IConfiguration _configuration;
    private readonly string _clientId;

    public ImgurService(IConfiguration configuration)
    {
        _configuration = configuration;
        _clientId = _configuration.GetSection("Imgur:ClientId").Value;
    }
    
    public string UploadImage(string name, string base64)
    {
        byte[] bytes = EncodeFile(base64);
        
        HttpWebRequest req = WebRequest.CreateHttp("https://api.imgur.com/3/image");
        req.Method = "POST";
        req.Accept = "application/json";
        req.Headers.Add("Authorization", "Client-ID " + _clientId);
        req.KeepAlive = true;
        req.ContentType = "application/x-www-form-urlencoded";
        req.ServicePoint.Expect100Continue = false;
        req.GetRequestStream().Write(bytes, 0, bytes.Length);
    
        var response = new StreamReader(req.GetResponse().GetResponseStream()).ReadToEnd();
        ImgurResponse imgurResponse = JsonSerializer.Deserialize<ImgurResponse>(response);
        return imgurResponse.data.link;
    }
    
    private byte[] EncodeFile(string base64)
    {
        int index = base64.IndexOf(",", StringComparison.Ordinal);
        base64 = base64.Substring(++index);
        byte[] bytes = Convert.FromBase64String(base64);
        return bytes;
    }
    
}