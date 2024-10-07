using Fluent_Validation.Model;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace Fluent_Validation.Controllers;


[ApiController]
[Route("api/[controller]")]
public class TextController : ControllerBase
{
    private readonly IValidator<TextModel> _validator;

    public TextController(IValidator<TextModel> validator)
    {
        _validator = validator;
    }

    [HttpPost]
    public IActionResult SubmitText([FromBody] TextModel model)
    {
        ValidationResult result = _validator.Validate(model);

        if (!result.IsValid)
        {
            return BadRequest(result.Errors);
        }

        return Ok("Matn muvaffaqiyatli yuborildi.");
    }
}