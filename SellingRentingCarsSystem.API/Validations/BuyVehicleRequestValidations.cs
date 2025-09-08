namespace SellingRentingCarsSystem.API.Validations;

public class BuyVehicleRequestValidations : AbstractValidator<BuyVehicleRequest>
{
    public BuyVehicleRequestValidations()
    {
        RuleFor(x => x.Vehicle)
            .NotNull()
            .WithMessage("{PropertyName} is required")
            .SetValidator(new VehicleRequestValidations());

        RuleFor(x => x.Payment)
            .NotNull()
            .WithMessage("{PropertyName} is required")
            .SetValidator(new PaymentRequestValidations());
    }
} 
