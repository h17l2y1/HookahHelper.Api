using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using AutoMapper;
using HookahHelper.BLL.Services.Interfaces;
using HookahHelper.BLL.Providers.Interfaces;
using HookahHelper.BLL.ViewModels.Account;
using HookahHelper.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace HookahHelper.BLL.Services;

public class AccountService : IAccountService
{
    private readonly IMapper _mapper;
    private readonly IConfiguration _configuration;
    private readonly UserManager<User> _userManager;
    private readonly IJwtProvider _jwtProvider;

    public AccountService(IMapper mapper, IConfiguration configuration, UserManager<User> userManager, IJwtProvider JwtProvider)
    {
        _mapper = mapper;
        _userManager = userManager;
        _jwtProvider = JwtProvider;
        _configuration = configuration;
    }

    public async Task SignUp(SignUp model)
    {
        var user = _mapper.Map<User>(model);
        user.UserName = model.FirstName+model.LastName;
        var result = await _userManager.CreateAsync(user, model.Password);
    }

    public async Task<string> Authenticate(Login model)
    {
        string step0 = string.Empty;
        string step1 = string.Empty;
        string step2 = string.Empty;
        
        try
        {
            step0 = JsonSerializer.Serialize(model);
            var user = await _userManager.FindByEmailAsync(model.Email);
            step1 = JsonSerializer.Serialize(user);
            
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                step2 = "in IF";
                var token = _jwtProvider.GenerateJwtToken(user);
                return token;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            // throw;
            string jsonString = JsonSerializer.Serialize(ex.Message);
            string jsonString2 = JsonSerializer.Serialize(ex.StackTrace);

            var xxx = new
            {
                step0 = step0,
                step1 = step1,
                step2 = step2,
                Message = JsonSerializer.Serialize(ex.Message),
                StackTrace = ex.StackTrace,
                Inner = ex.InnerException?.Message,
            };
            
            return JsonSerializer.Serialize(xxx);;

        }

        return null;
    }
    
    private string GenerateJwtToken(User user)
    {
        var accessToken = CreateAccessToken(user);
        var refreshToken = CreateRefreshToken(user);
        
        var encodedAccess = new JwtSecurityTokenHandler().WriteToken(accessToken);
        var encodedRefresh = new JwtSecurityTokenHandler().WriteToken(refreshToken);
        
        return encodedAccess;
        
    }

    private JwtSecurityToken CreateAccessToken(User user)
    {
        var claims = new List<Claim>
        {
            new(ClaimTypes.Email, user.Email),
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
