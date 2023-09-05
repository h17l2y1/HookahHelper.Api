namespace HookahHelper.Api.Models;

public class JwtSettings 
{
    public static string Key => "JWT";
    public string? ValidAudience { get; init; } = string.Empty;
    public string? ValidIssuer { get; init; } = string.Empty;
    public string? Secret { get; init; } = string.Empty;
}