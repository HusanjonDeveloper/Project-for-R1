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

    // Constructor orqali validatorni injekt qilish
    public CreateUserController(IValidator<CreateUserModel> validator)
    {
        _validator = validator;
    }

    // Foydalanuvchi yaratish uchun endpoint
    [HttpPost]
    public IActionResult CreateUser([FromBody] CreateUserModel model)
    {
        // Modelni validatsiya qilish
        ValidationResult result = _validator.Validate(model);

        // Agar validatsiyada xato bo'lsa, javob qaytariladi
        if (!result.IsValid)
        {
            return BadRequest(result.Errors);
        }

        // Agar validatsiya muvaffaqiyatli bo'lsa, davom ettiriladi
        return Ok("Foydalanuvchi muvaffaqiyatli yaratildi.");
    }
}