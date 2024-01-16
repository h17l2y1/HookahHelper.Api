using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using HookahHelper.BLL.Providers.Interfaces;
using HookahHelper.BLL.ViewModels.Account;
using HookahHelper.DAL.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;


namespace HookahHelper.BLL.Providers;

public class JwtProvider : IJwtProvider
{
    private readonly IConfiguration _configuration;

    public JwtProvider(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    public LoginResponse GenerateJwtToken(User user)
    {
        var accessToken = CreateAccessToken(user);
        var refreshToken = CreateRefreshToken(user);
        
        var encodedAccess = new JwtSecurityTokenHandler().WriteToken(accessToken);
        var encodedRefresh = new JwtSecurityTokenHandler().WriteToken(refreshToken);
        
        var loginResponse = new LoginResponse()
        {
            AccessToken = encodedAccess,
            RefreshToken = encodedRefresh
        };
        return loginResponse;
    }
    
    private JwtSecurityToken CreateAccessToken(User user)
    {
        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Email, user.Email),
            new("role", user.Role),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            
        };
        
        return GetToken(claims, 8);
    }
    
    private JwtSecurityToken CreateRefreshToken(User user)
    {
        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Email, user.Email),
            new("role", user.Role),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        };
    
        return GetToken(claims, 24);
    }
    
    private JwtSecurityToken GetToken(IEnumerable<Claim> claims, int hours)
    {
        var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
        var jwtIssuer = _configuration["JWT:ValidIssuer"];
        var jwtValidAudience = _configuration["JWT:ValidAudience"];
        
        var token = new JwtSecurityToken(
            issuer:  jwtIssuer,
            audience: jwtValidAudience,
            expires: DateTime.Now.AddHours(hours),
            claims: claims,
            signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256));
    
        return token;
    }
}