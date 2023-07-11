namespace HookahHelper.BLL.ViewModels.Image;

public record UpdateImageRequest
{
    public required string Id { get; set; }
    public string Name { get; set; }
    public string Base64 { get; set; }
}