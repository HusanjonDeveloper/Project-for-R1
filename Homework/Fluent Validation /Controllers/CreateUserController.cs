using Fluent_Validation.Model;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace Fluent_Validation.Controllers;

[ApiController]
[Route("api/[controller]")]

public class CreateUserController : ControllerBase
{
    private readonly IValidator<CreateUserModel> _validator;

   
    public CreateUserController(IValidator<CreateUserModel> validator)
    {
        _validator = validator;
    }

    [HttpPost("create-user")]
    public IActionResult CreateUser([FromBody] CreateUserModel model)
    {
  
        ValidationResult result = _validator.Validate(model);

     
        if (!result.IsValid)
        {
            return BadRequest(result.Errors);
        }

        return Ok("Foydalanuvchi muvaffaqiyatli yaratildi.");
    }
}
