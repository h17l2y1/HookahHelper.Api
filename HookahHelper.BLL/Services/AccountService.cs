using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using HookahHelper.BLL.Services.Interfaces;
using HookahHelper.BLL.Providers.Interfaces;
using HookahHelper.BLL.ViewModels.Account;
using HookahHelper.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace HookahHelper.BLL.Services;

public class AccountService : IAccountService
{
    private readonly IMapper _mapper;
    private readonly IConfiguration _configuration;
    private readonly UserManager<User> _userManager;
    private readonly IJwtProvider _jwtProvider;

    public AccountService(IMapper mapper, IConfiguration configuration, UserManager<User> userManager, IJwtProvider jwtProvider)
    {
        _mapper = mapper;
        _userManager = userManager;
        _jwtProvider = jwtProvider;
        _configuration = configuration;
    }

    public async Task SignUp(SignUp model)
    {
        var user = _mapper.Map<User>(model);
        user.UserName = model.FirstName+model.LastName;
        var result = await _userManager.CreateAsync(user, model.Password);
        if (!result.Succeeded)
        {
            throw new Exception(result.Errors.First().Description);
        }
    }

    public async Task<LoginResponse> Authenticate(Login model)
    {
        var user = await _userManager.FindByEmailAsync(model.Email);

        if (user == null)
        {
            throw new Exception("User email does not found");
        }
        
        if (await _userManager.CheckPasswordAsync(user, model.Password))
        {
            LoginResponse token = _jwtProvider.GenerateJwtToken(user);
            return token;
        }

        throw new Exception("Password error");
    }

    public async Task<LoginResponse> RefreshAuthToken(string refreshToken)
    {
        var validationParameters = new TokenValidationParameters()
        {
            ValidateLifetime = true,
            ValidateAudience = false,
            ValidateIssuer = false,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"])),
        };

        var tokenHandler = new JwtSecurityTokenHandler(); 
        ClaimsPrincipal claimsPrincipal = tokenHandler.ValidateToken(refreshToken, validationParameters, out SecurityToken validatedToken);


        string userEmail = claimsPrincipal.Claims.First(x => x.Type == "email").Value;
        User user = await _userManager.FindByEmailAsync(userEmail);
        
        LoginResponse token = _jwtProvider.GenerateJwtToken(user);
        return token;
    }
}
