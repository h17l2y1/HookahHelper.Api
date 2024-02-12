using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using HookahHelper.BLL.Models;
using HookahHelper.BLL.Services.Interfaces;
using HookahHelper.BLL.Providers.Interfaces;
using HookahHelper.BLL.ViewModels.Account;
using HookahHelper.DAL.Entities;
using HookahHelper.DAL.Repositories.Interfaces;
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
    private readonly IBlackListRefreshTokenRepository _blackListRefreshTokenRepository;
    private readonly IRefreshTokenRepository _refreshTokenRepository;

    public AccountService(IMapper mapper, IConfiguration configuration, 
        UserManager<User> userManager, IJwtProvider jwtProvider, 
        IBlackListRefreshTokenRepository blackListRefreshTokenRepository, 
        IRefreshTokenRepository refreshTokenRepository)
    {
        _mapper = mapper;
        _userManager = userManager;
        _jwtProvider = jwtProvider;
        _configuration = configuration;
        _blackListRefreshTokenRepository = blackListRefreshTokenRepository;
        _refreshTokenRepository = refreshTokenRepository;
    }

    public async Task SignUp(SignUp model)
    {
        var emailExist = await _userManager.FindByEmailAsync(model.Email);

        if (emailExist != null)
        {
            throw new Exception("Email already exist");
        }
        
        var user = _mapper.Map<User>(model);
        user.UserName = model.FirstName+model.LastName;
        var result = await _userManager.CreateAsync(user, model.Password);
        if (!result.Succeeded)
        {
            throw new Exception(result.Errors.First().Description);
        }
    }

    public async Task<LoginResponse> Login(Login model)
    {
        var user = await _userManager.FindByEmailAsync(model.Email);

        if (user == null)
        {
            throw new Exception("User email does not found");
        }
        
        if (await _userManager.CheckPasswordAsync(user, model.Password))
        {
            RefreshTokenData token = _jwtProvider.GenerateJwtToken(user);
            var entity = new RefreshToken()
            {
                UserId = user.Id,
                Token = token.RefreshToken,
                ExpiredDate = token.ExpiredDate
            };
            await _refreshTokenRepository.Create(entity);

            var loginResponse = new LoginResponse()
            {
                AccessToken = token.AccessToken,
                RefreshToken = token.RefreshToken,
            };
            return loginResponse;
        }

        throw new Exception("Password error");
    }

    public async Task<LoginResponse> RefreshAuthToken(RefreshTokenRequest request)
    {
        TokenValidationParameters validationParameters = GetTokenValidationParameters();
        ClaimsPrincipal claimsPrincipal = new JwtSecurityTokenHandler().ValidateToken(request.RefreshToken, validationParameters, out SecurityToken validatedToken);
        string expiredTimestampString = claimsPrincipal.Claims.First(x => x.Type == "exp").Value;
        DateTime expiredDateTime = UnixTimeStampToDateTime(Double.Parse(expiredTimestampString));
        bool isTokenInvalid = await _refreshTokenRepository.IsTokenInvalid(request.RefreshToken);
        if (isTokenInvalid)
        {
            throw new Exception("Refresh Token Invalid");
        }
        
        string userEmail = claimsPrincipal.Claims.First(x => x.Type == ClaimTypes.Email).Value;
        User user = await _userManager.FindByEmailAsync(userEmail);
        
        RefreshTokenData token = _jwtProvider.GenerateJwtToken(user);
        
        var loginResponse = new LoginResponse()
        {
            AccessToken = token.AccessToken,
            RefreshToken = token.RefreshToken,
        };
        return loginResponse;
    }

    private TokenValidationParameters GetTokenValidationParameters()
    {
        return new TokenValidationParameters()
        {
            ValidateLifetime = false,
            ValidateAudience = false,
            ValidateIssuer = false,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"])),
        };
    }
    
    private DateTime UnixTimeStampToDateTime(double unixTimeStamp)
    {
        DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
        dateTime = dateTime.AddSeconds(unixTimeStamp).ToLocalTime();
        return dateTime;
    }
}
