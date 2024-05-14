using Domain.DTOs;
using Domain.Response;

namespace Infrastructure.Services;

public interface IUserService
{
    Task<Response<string>> Register(RegisterDto model);
    Task<Response<string>> Login(LoginDto model);
}