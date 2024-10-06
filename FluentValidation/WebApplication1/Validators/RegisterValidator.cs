using FluentValidation;
using WebApplication1.Model;

namespace WebApplication1.Validators;

public class RegisterValidator : AbstractValidator<CreateUserModel>
{

    public RegisterValidator()
    {
        RuleFor(x => x.Firstname)
            .NotNull()
            .MinimumLength(5)
            .MaximumLength(17);

        string role = "Husan";

        if (role == "Husan")
        {
            
        }
        else
        {
            RuleFor(x => x.Username)
                .NotNull()
                .MinimumLength(5)
                .MaximumLength(17)
                .WithErrorCode("17 dan kop")
                .Must(x => x.StartsWith("Husan"))
                .WithErrorCode("Husan degan user name tanlash mumkin emas");

            When(x => x.Address != null, () =>
            {
                RuleFor(x => x.Address)
                    .SetValidator(new AdminValidator()!);
            });

            RuleFor(s => Convert.ToInt32(s.Age))
                .GreaterThan(8)
                .WithErrorCode("kamida 8 yosh bolish kerak");
            
            When(x => x.Age < 18 && x.Age > 8, () =>
            {
                RuleFor(s => s.Contacts).NotNull()
                    .Must(c => c.Count() >= 2)
                    .WithErrorCode("kamida 2 ta contect bolishi kerak");
            })
            .Otherwise(() =>
            {
                When(a => a.Age > 18 && a.Age < 40 , () =>
                {
                    RuleFor(s => s.Contacts)
                        .NotNull()
                        .Must(d => d.Count > 0);
                })
                .Otherwise(() =>
                {
                    RuleFor(s => s.Contacts)
                        .NotNull();
                });
            });

            /*
            var userAge = 15;

            if (userAge < 18)
            {
                
            }
            else
            {
                if (userAge > 18 && userAge < 30)
                {
                    // action
                }
                else
                {
                    
                }
            }
            */
            
        }
    }
    
    // string item  = " ";
}


public class AdminValidator : AbstractValidator<Address>
{
    public AdminValidator()
    {
        RuleFor(x => x.ZipCode)
            .GreaterThan(100000)
            .LessThan(10100000);

        RuleFor(x => x.Country)
            .Must(x => x == "Uzbekistan");
        
        
        RuleFor( x => x.City)
            .Must( c => c == "Bulgaria");
    }
}