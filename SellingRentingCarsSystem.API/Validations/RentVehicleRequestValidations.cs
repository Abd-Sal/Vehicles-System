namespace SellingRentingCarsSystem.API.Validations;

public class RentVehicleRequestValidations : AbstractValidator<RentVehicleRequest>
{
    public RentVehicleRequestValidations()
    {
        RuleFor(x => x.VehicleID)
            .NotEmpty()
            .WithMessage("{PropertyName} is required");

        RuleFor(x => x.CustomerID)
            .NotEmpty()
            .WithMessage("{PropertyName} is required");

        //RuleFor(x => x.StartAtMile)
        //    .GreaterThanOrEqualTo(0)
        //    .WithMessage("{PropertyName} must be greater than or equal to 0");

        RuleFor(x => x.ExpectedEndRentDate)
            .NotEmpty()
            .WithMessage("{PropertyName} is required")
            .GreaterThan(DateTime.UtcNow)
            .WithMessage("{PropertyName} must be greater than current date");

        RuleFor(x => x.ExpectedAmount)
            .GreaterThan(0)
            .WithMessage("{PropertyName} must be greater than 0");

        RuleFor(x => x.Payment)
            .SetValidator(new PaymentRequestValidations()!)
            .When(x => x.Payment != null && !x.PayLater);
    }
} 