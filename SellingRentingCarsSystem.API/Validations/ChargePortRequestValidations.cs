namespace SellingRentingCarsSystem.API.Validations;

public class ChargePortRequestValidations : AbstractValidator<ChargePortRequest>
{
    public ChargePortRequestValidations()
    {
        RuleFor(x => x.PortName)
            .NotEmpty()
            .WithMessage("{PropertyName} is required")
            .Length(2, 200)
            .WithMessage("{PropertyName} length have to be between {MinLength} and {MaxLength}");
    }
}
