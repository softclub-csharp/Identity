using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages.User;

public class Login(IUserService service) : PageModel
{
    
    public void OnPost()
    {
        
    }
}