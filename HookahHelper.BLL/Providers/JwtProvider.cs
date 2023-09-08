using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using HookahHelper.BLL.Providers.Interfaces;
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
    
    public string GenerateJwtToken(User user)
    {
        var accessToken = CreateAccessToken(user);
        var refreshToken = CreateRefreshToken(user);
        
        var encodedAccess = new JwtSecurityTokenHandler().WriteToken(accessToken);
        var encodedRefresh = new JwtSecurityTokenHandler().WriteToken(refreshToken);

        // var tokens = new JwtView { AccessToken = encodedAccess, RefreshToken = encodedRefresh };
        
        return encodedAccess;
    }
    
    private JwtSecurityToken CreateAccessToken(User user)
    {
        var claims = new List<Claim>
        {
            new(ClaimTypes.Email, user.Email),
            // new(ClaimTypes.Role, user.Role),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        };
        
        return GetToken(claims);
    }
    
    private JwtSecurityToken CreateRefreshToken(User user)
    {
        var claims = new List<Claim>
        {
            new(ClaimTypes.Email, user.Email),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        };
    
        return GetToken(claims);
    }
    
    private JwtSecurityToken GetToken(IEnumerable<Claim> claims)
    {
        var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
        var jwtIssuer = _configuration["JWT:ValidIssuer"];
        var jwtValidAudience = _configuration["JWT:ValidAudience"];
        
        var token = new JwtSecurityToken(
            issuer:  jwtIssuer,
            audience: jwtValidAudience,
            expires: DateTime.Now.AddHours(3),
            claims: claims,
            signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256));
    
        return token;
    }
}