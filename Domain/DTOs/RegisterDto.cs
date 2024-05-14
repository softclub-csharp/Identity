using System.ComponentModel.DataAnnotations;

namespace Domain.DTOs;

public class RegisterDto
{
    public string UserName { get; set; }
    public string Email { get; set; }
    [DataType(DataType.Password)]
    public string Password { get; set; }
    [Compare("Password")][DataType(DataType.Password)]
    public string ConfirmPassword { get; set; }
}