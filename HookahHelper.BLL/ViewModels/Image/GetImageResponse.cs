namespace HookahHelper.BLL.ViewModels.Image;

public record GetImageResponse
{
    public required int id { get; set; }
    public required string Name { get; set; }
    public required string Link { get; set; }
    public required string Type { get; set; }
}