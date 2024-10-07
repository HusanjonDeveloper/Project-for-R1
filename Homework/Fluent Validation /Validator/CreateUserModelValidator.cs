using Fluent_Validation.Model;

namespace Fluent_Validation.Validator;
using FluentValidation;

public class CreateUserModelValidator : AbstractValidator<CreateUserModel>
{
    public CreateUserModelValidator()
    {
        // Firstname (Ism) validatsiyasi
        RuleFor(x => x.Firstname)
            .NotEmpty().WithMessage("Ism bo'sh bo'lishi mumkin emas")
            .MinimumLength(3).WithMessage("Ism kamida 3 ta harfdan iborat bo'lishi kerak")
            .MaximumLength(16).WithMessage("Ism 16 ta harfdan oshmasligi kerak")
            .Matches("^[A-Z]").WithMessage("Ism katta harf bilan boshlanishi kerak");

        // Lastname (Familiya) validatsiyasi
        RuleFor(x => x.Lastname)
            .NotEmpty().WithMessage("Familiya bo'sh bo'lishi mumkin emas")
            .MinimumLength(2).WithMessage("Familiya kamida 2 ta harfdan iborat bo'lishi kerak")
            .MaximumLength(16).WithMessage("Familiya 16 ta harfdan oshmasligi kerak")
            .Matches("^[A-Z]").WithMessage("Familiya katta harf bilan boshlanishi kerak");

        // Username validatsiyasi
        RuleFor(x => x.Username)
            .NotEmpty().WithMessage("Foydalanuvchi nomi bo'sh bo'lishi mumkin emas")
            .MinimumLength(6).WithMessage("Foydalanuvchi nomi kamida 6 ta harfdan iborat bo'lishi kerak")
            .MaximumLength(32).WithMessage("Foydalanuvchi nomi 32 ta harfdan oshmasligi kerak");

        // Password validatsiyasi
        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Parol bo'sh bo'lishi mumkin emas")
            .MinimumLength(8).WithMessage("Parol kamida 8 ta harfdan iborat bo'lishi kerak")
            .MaximumLength(32).WithMessage("Parol 32 ta harfdan oshmasligi kerak")
            .Matches("[0-9]").WithMessage("Parol kamida 1 ta raqam o'z ichiga olishi kerak")
            .Matches("[A-Za-z]").WithMessage("Parol kamida 1 ta harf o'z ichiga olishi kerak");

        // Confirm Password validatsiyasi
        RuleFor(x => x.ConfirmPassword)
            .Equal(x => x.Password).WithMessage("Tasdiqlash paroli asosiy parol bilan bir xil bo'lishi kerak");

        // Gender (Jins) validatsiyasi
        RuleFor(x => x.Gender)
            .NotEmpty().WithMessage("Jins tanlanishi kerak")
            .Must(x => x == "Male" || x == "Female").WithMessage("Jins faqat 'Male' yoki 'Female' bo'lishi mumkin");
    }
}