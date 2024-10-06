using Microsoft.AspNetCore.Mvc;
using WebApplication1.Model;
using WebApplication1.Validators;

namespace WebApplication1.Controller;

[Route("api/[controller]")]
[ApiController]

public class UsersController : ControllerBase
{
    [HttpPost]
    public IActionResult Register([FromBody] CreateUserModel model)
    {

        var validator = new RegisterValidator();
        
        var result  = validator.Validate(model);
        
        if (!result.IsValid)
            return BadRequest(result.Errors);
        
        // logic here
        return Ok("data");
    }
}