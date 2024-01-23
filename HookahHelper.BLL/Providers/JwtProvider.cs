using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using HookahHelper.BLL.Models;
using HookahHelper.BLL.Providers.Interfaces;
using HookahHelper.BLL.ViewModels.Account;
using HookahHelper.DAL.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace HookahHelper.BLL.Providers;

public class JwtProvider : IJwtProvider
{
    private readonly IConfiguration _configuration;
    private readonly int _accessTokenLifeTime = 1;
    private readonly int _refreshTokenLifeTime = 48;

    public JwtProvider(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    public RefreshTokenData GenerateJwtToken(User user)
    {
        var accessToken = CreateToken(user, _accessTokenLifeTime);
        var refreshToken = CreateToken(user, _refreshTokenLifeTime);
        
        var encodedAccess = new JwtSecurityTokenHandler().WriteToken(accessToken);
        var encodedRefresh = new JwtSecurityTokenHandler().WriteToken(refreshToken);
        
        var loginResponse = new LoginResponse()
        {
            AccessToken = encodedAccess,
            RefreshToken = encodedRefresh
        };
        var response = new RefreshTokenData()
        {
            AccessToken = loginResponse.AccessToken,
            RefreshToken = loginResponse.RefreshToken,
            ExpiredDate = DateTime.Now.AddHours(_refreshTokenLifeTime),
            UserId = user.Id
        };
        return response;
    }
    
    private JwtSecurityToken CreateToken(User user, int hours)
    {
        var claims = new List<Claim>
        {
            new("name", $"{user.FirstName} {user.LastName}"),
            new("email", user.Email),
            new("role", user.Role),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };
        
        return GetToken(claims, hours);
    }
    
    private JwtSecurityToken GetToken(IEnumerable<Claim> claims, int hours)
    {
        var secretKey = _configuration.GetValue<string>("JWT:Secret");
        var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

        var token = new JwtSecurityToken(
            expires: DateTime.Now.AddHours(hours),
            claims: claims,
            signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256));
    
        return token;
    }
}