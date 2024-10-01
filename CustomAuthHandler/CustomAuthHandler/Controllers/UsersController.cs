using Microsoft.AspNetCore.Mvc;

namespace CustomAuthHandler.Controllers;
[Route("api/[controller]")]
[ApiController]

public class UsersController : Controller
{
    public IActionResult Login()
    {
        return Ok();
    }
}