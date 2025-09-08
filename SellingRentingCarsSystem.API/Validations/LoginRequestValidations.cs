namespace SellingRentingCarsSystem.API.Validations;

public class LoginRequestValidations : AbstractValidator<LoginRequest>
{
    public LoginRequestValidations()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("{PropertyName} is required");

        RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage("{PropertyName} is required");
    }
}
