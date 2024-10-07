using FluentValidation;

namespace Fluent_Validation.Model;
public class UpdateUsernameModel
{
    public string NewUsername { get; set; }
}

public class UpdateUsernameModelValidator : AbstractValidator<UpdateUsernameModel>
{
    public UpdateUsernameModelValidator()
    {
        RuleFor(x => x.NewUsername)
            .NotEmpty().WithMessage("Yangi foydalanuvchi nomi kiritilishi shart")
            .MinimumLength(6).WithMessage("Foydalanuvchi nomi kamida 6 ta harfdan iborat bo'lishi kerak")
            .MaximumLength(32).WithMessage("Foydalanuvchi nomi 32 ta harfdan oshmasligi kerak");
    }
}