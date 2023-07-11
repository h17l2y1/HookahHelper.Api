namespace HookahHelper.BLL.ViewModels.Image;

public record CreateImageRequest
{
    public string Name { get; set; }
    public string Base64 { get; set; }
}