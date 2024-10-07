using Fluent_Validation.Model;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace Fluent_Validation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UpdateUsernameController : ControllerBase
{
    private readonly IValidator<UpdateUsernameModel> _validator;

    public UpdateUsernameController(IValidator<UpdateUsernameModel> validator)
    {
        _validator = validator;
    }

    [HttpPut("update-username")]
    public IActionResult UpdateUsername([FromBody] UpdateUsernameModel model)
    {
        ValidationResult result = _validator.Validate(model);

        if (!result.IsValid)
        {
            return BadRequest(result.Errors);
        }

        return Ok("Foydalanuvchi nomi muvaffaqiyatli yangilandi.");
    }
}