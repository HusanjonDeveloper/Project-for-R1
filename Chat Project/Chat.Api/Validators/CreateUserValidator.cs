using Chat.Api.Constants;
using Chat.Api.Models.UserModels;
using FluentValidation;

namespace Chat.Api.Validators;

public class CreateUserValidator:AbstractValidator<CreateUserModel>
{
    public CreateUserValidator()
    {
      RuleForFirstname().Wait();
      RuleForLastname();
      RuleForUsername();
      RuleForPassword();
      RuleForGender();
    }


    async Task RuleForFirstname()
    {

        RuleFor(u => u.FirstName)
            .NotNull()
            .Length(min: 3, max: 17)
            /*.Must(f => f[0].ToString().ToUpper() == f[0].ToString())*/
            .Must(f => char.IsLetter(f[0]))
            /*.Matches("^\\p{Lu}.*")*/
            .WithErrorCode("First character must be letter");


        When(u => char.IsLetter(u.FirstName[0]),
             () =>
            {
                RuleFor(u => u.FirstName)
                    .Must(f => char.IsUpper(f[0]))
                    .WithErrorCode("First latter must be capital");
            });
    }


    void RuleForLastname()
    {


        RuleFor(u => u.LastName)
            .NotNull()
            .Length(min: 3, max: 17)
            /*.Must(f => f[0].ToString().ToUpper() == f[0].ToString())*/
            .Must(f => char.IsLetter(f[0]))
            /*.Matches("^\\p{Lu}.*")*/
            .WithErrorCode("First character must be letter");


        When(u => 
                !string.IsNullOrEmpty(u.LastName)  
                  && char.IsLetter(u.LastName[0]),
            () =>
            {
                RuleFor(u => u.LastName)
                    .Must(f => char.IsUpper(f[0]))
                    .WithErrorCode("First latter must be capital");
            });
    }

    void RuleForUsername()
    {
        RuleFor(u => u.Username)
            .NotNull()
            .Length(min: 6, max: 32)
            .WithErrorCode("At least 6 characters")
            .Matches("^[a-zA-Z][a-zA-Z0-9_]*$")
            .WithErrorCode("username must [A-z] and [0-9] and [ _ ] ");


    }
    void RuleForPassword()
    {
        RuleFor(u => u.Password)
            .NotNull()
            .Length(min: 8, max: 32)
            .WithErrorCode("At least 8 characters")
            .Matches("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[\\W_]).{8,}$")
            .WithErrorCode("password must be strong ");

        RuleFor(u => u.ConfirmPassword)
            .Equal(u => u.Password)
            .WithErrorCode("Confirm password didn't match")
            ;

        /*When(u => u.Password != u.ConfirmPassword, 
            () => throw new Exception("Confirm password didn't match"));*/

        

    }

    void RuleForGender()
    {
        RuleFor(u => u.Gender)
            .NotNull()
            .WithMessage("Gender cannot be null");


        When(u => u.Gender is not null, () =>
        {
            RuleFor(u => u.Gender)
                .NotEmpty()
                .WithMessage("Gender cannot be empty");


            When(u => !string.IsNullOrWhiteSpace(u.Gender), () =>
            {
                RuleFor(u => u.Gender)
                    .Must(g => g?.ToLower() is UserConstants.Male or UserConstants.Female)
                    .WithMessage("Gender value must be Male or Female");
            });

            // null ?
            // "       "
            //""
            //"sdjdsfb"


        });
    }


    //Firstname = Maruf
    //f[0] = M

    // a => A,, A => A
}