namespace SellingRentingCarsSystem.API.Validations;

public class RefreshTokenRequestValidations : AbstractValidator<RefreshTokenRequest>
{
    public RefreshTokenRequestValidations()
    {
        RuleFor(x => x.Token)
            .NotEmpty()
            .WithMessage("{PropertyName} is required");

        RuleFor(x => x.RefreshToken)
            .NotEmpty()
            .WithMessage("{PropertyName} is required");
    }
}
