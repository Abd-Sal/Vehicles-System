namespace SellingRentingCarsSystem.API.Validations;

public class AspirationRequestValidations : AbstractValidator<AspirationRequest>
{
    public AspirationRequestValidations()
    {
        RuleFor(x => x.TypeName)
            .NotEmpty()
            .WithMessage("{PropertyName} is required")
            .Length(2, 200)
            .WithMessage("{PropertyName} length have to be between {MinLength} and {MaxLength}");

    }
}
