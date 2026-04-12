namespace HookahHelper.BLL.Config;

public class ImgurOptions
{
    public const string SectionName = "Imgur";

    public string ClientId { get; set; } = string.Empty;
    public string ClientSecret { get; set; } = string.Empty;
    public string? AccessToken { get; set; }
}
