using AutoMapper;
using HookahHelper.BLL.Services.Interfaces;
using HookahHelper.BLL.ViewModels.Account;
using HookahHelper.DAL.Entities;
using Microsoft.AspNetCore.Identity;

namespace HookahHelper.BLL.Services;

public class AccountService : IAccountService
{
    private readonly IMapper _mapper;

    private readonly UserManager<User> _userManager;

    // private readonly SignInManager<User> _signInManager;

    public AccountService(IMapper mapper, UserManager<User> userManager)
    {
        _mapper = mapper;
        _userManager = userManager;
    }

    public async Task SignUp(SignUp model)
    {
        var user = _mapper.Map<User>(model);
        user.UserName = "TestUser";
        // user.PasswordHash = "";
        var result = await _userManager.CreateAsync(user, model.Password);
        // await _repository.Create(entity);
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