using FluentValidation;

namespace Fluent_Validation.Model;

public class TextModel
{
    public string Content { get; set; }
}

public class TextModelValidator : AbstractValidator<TextModel>
{
    public TextModelValidator()
    {
        RuleFor(x => x.Content)
            .NotEmpty().WithMessage("Matn kiritilishi kerak");
    }
}