namespace SellingRentingCarsSystem.API.Validations;

public class SellVehicleRequestValidations : AbstractValidator<SellVehicleRequest>
{
    public SellVehicleRequestValidations()
    {
        RuleFor(x => x.VehicleID)
            .NotEmpty()
            .WithMessage("{PropertyName} is required");

        RuleFor(x => x.CustomerID)
            .NotEmpty()
            .WithMessage("{PropertyName} is required");

        RuleFor(x => x.Payment)
            .NotNull()
            .WithMessage("{PropertyName} is required")
            .SetValidator(new PaymentRequestValidations());
    }
} 