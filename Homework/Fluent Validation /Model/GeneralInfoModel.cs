using FluentValidation;

namespace Fluent_Validation.Model;

public class GeneralInfoModel
{
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
}

public class GeneralInfoModelValidator : AbstractValidator<GeneralInfoModel>
{
    public GeneralInfoModelValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email manzili kiritilishi shart")
            .EmailAddress().WithMessage("To'g'ri email manzil kiriting");

        RuleFor(x => x.PhoneNumber)
            .NotEmpty().WithMessage("Telefon raqami bo'sh bo'lmasligi kerak")
            .Matches(@"^\+998[0-9]{9}$").WithMessage("Telefon raqami +998 bilan boshlanishi kerak va 9 ta raqam bo'lishi kerak");
    }
}