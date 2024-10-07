using FluentValidation;

namespace Fluent_Validation.Model;

public class LoginModel
{
    public string Username { get; set; }
    public string Password { get; set; }
}

public class LoginModelValidator : AbstractValidator<LoginModel>
{
    public LoginModelValidator()
    {
        RuleFor(x => x.Username)
            .NotEmpty().WithMessage("Foydalanuvchi nomi kiritilishi kerak");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Parol kiritilishi kerak");
    }
}