namespace SellingRentingCarsSystem.API.Validations;

public class ChangePasswordRequestValidations : AbstractValidator<ChangePasswordRequest>
{
    public ChangePasswordRequestValidations()
    {
        RuleFor(x => x.OldPassword)
           .NotEmpty()
           .WithMessage("{PropertyName} is null/empty");

        RuleFor(x => x.NewPassword)
            .NotEmpty()
            .WithMessage("{PropertyName} is null/empty")
            .Must(x => HelpToolsExtensions.PasswordFormat(x))
            .When(x => x.NewPassword is not null)
            .WithMessage("{PropertyName} should contain(A,a,@,1)")
            .NotEqual(x => x.OldPassword)
            .WithMessage("new password can not be same as current password");
    }
} 
