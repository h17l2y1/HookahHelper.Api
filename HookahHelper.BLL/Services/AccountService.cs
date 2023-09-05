using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using HookahHelper.BLL.Services.Interfaces;
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

    // private readonly SignInManager<User> _signInManager;

    public AccountService(IMapper mapper, IConfiguration configuration, UserManager<User> userManager)
    {
        _mapper = mapper;
        _userManager = userManager;
        _configuration = configuration;
    }

    public async Task SignUp(SignUp model)
    {
        var user = _mapper.Map<User>(model);
        user.UserName = "TestUser";
        // user.PasswordHash = "";
        var result = await _userManager.CreateAsync(user, model.Password);
        // await _repository.Create(entity);
    }

    public async Task<string> Authenticate(Login model)
    {
        // var test = await _userManager.
        var user = await _userManager.FindByEmailAsync(model.Email);

        if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
        {
            var token = GenerateJwtToken(user);
            return token;
        }
        return null;
    }
    
    private string GenerateJwtToken(IdentityUser user)
    {
        var jwtKey = _configuration["JWT:Secret"];
        var jwtIssuer = _configuration["JWT:ValidIssuer"];

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Email),
            // new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: jwtIssuer,
            audience: null,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(2),
            // expires: DateTime.UtcNow.AddHours(1),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public async Task SignUp1(SignUp model)
    {
        var user = new User
            { FirstName = model.FirstName, LastName = model.LastName, Email = model.Email, Password = model.Password };
        var result = await _userManager.CreateAsync(user, model.Password);

        // if (result.Succeeded)
        // {
        //     await _signInManager.SignInAsync(user, isPersistent: false);
        // }
    }
}
//     нужно ли передавать код в Program.cs для настройки identity
// Где пихнуть Authorize?