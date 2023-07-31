namespace HookahHelper.BLL.Models;

public class ImgurResponse
{
    public required Data data { get; set; }
    public required bool success { get; set; }
    public required int status { get; set; }
}

public class Data
{
    public required string id { get; set; }
    public required int datetime { get; set; }
    public required string type { get; set; }
    public required bool animated { get; set; }
    public required int width { get; set; }
    public required int height { get; set; }
    public required int size { get; set; }
    public required int views { get; set; }
    public required int bandwidth { get; set; }
    public required bool favorite { get; set; }
    public required int account_id { get; set; }
    public required bool is_ad { get; set; }
    public required bool in_most_viral { get; set; }
    public required bool has_sound { get; set; }
    public required List<object> tags { get; set; }
    public required int ad_type { get; set; }
    public required string ad_url { get; set; }
    public required string edited { get; set; }
    public required bool in_gallery { get; set; }
    public required string deletehash { get; set; }
    public required string name { get; set; }
    public required string link { get; set; }
}