using System.Net;
using Domain.DTOs;
using Domain.Response;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Services;

public class UserService : IUserService
{
    private readonly UserManager<IdentityUser> _userManager;

    public UserService(UserManager<IdentityUser> userManager)
    {
        _userManager = userManager;
    }


    public async Task<Response<string>> Register(RegisterDto model)
    {
        try
        {
            var result = await _userManager.FindByNameAsync(model.UserName);
            if (result != null) return new Response<string>(HttpStatusCode.BadRequest, "Such a user already exists!");
            var user = new IdentityUser()
            {
                UserName = model.UserName,
                Email = model.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(model.Password)
            };

            await _userManager.CreateAsync(user);
            return new Response<string>($"success");
        }
        catch (Exception e)
        {
            return new Response<string>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Response<string>> Login(LoginDto model)
    {
        var user = await _userManager.FindByEmailAsync(model.UserName);
        if (user == null)
        {
            return new Response<string>(HttpStatusCode.BadRequest, "user not found");
        }

        var password = BCrypt.Net.BCrypt.HashPassword(model.Password);
        if (password == user.PasswordHash) return new Response<string>("Success");

        return new Response<string>(HttpStatusCode.BadRequest, "error occured");
    }
}