using Fluent_Validation.Model;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace Fluent_Validation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GeneralInfoController : ControllerBase
{
    private readonly IValidator<GeneralInfoModel> _validator;

    public GeneralInfoController(IValidator<GeneralInfoModel> validator)
    {
        _validator = validator;
    }

    [HttpPost]
    public IActionResult UpdateGeneralInfo([FromBody] GeneralInfoModel model)
    {
        ValidationResult result = _validator.Validate(model);

        if (!result.IsValid)
        {
            return BadRequest(result.Errors);
        }

        return Ok("Ma'lumot muvaffaqiyatli yangilandi.");
    }
}