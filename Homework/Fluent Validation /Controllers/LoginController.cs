using Fluent_Validation.Model;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace Fluent_Validation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LoginController : ControllerBase
{
    private readonly IValidator<LoginModel> _validator;

    public LoginController(IValidator<LoginModel> validator)
    {
        _validator = validator;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginModel model)
    {
        ValidationResult result = _validator.Validate(model);

        if (!result.IsValid)
        {
            return BadRequest(result.Errors);
        }
        
        return Ok("Kirish muvaffaqiyatli amalga oshirildi.");
    }
}
