namespace SellingRentingCarsSystem.API.Validations;

public class StopRentVehicleRequestValidations : AbstractValidator<StopRentVehicleRequest>
{
    public StopRentVehicleRequestValidations()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("{PropertyName} is required");

        RuleFor(x => x.VehicleID)
            .NotEmpty()
            .WithMessage("{PropertyName} is required");

        RuleFor(x => x.CustomerID)
            .NotEmpty()
            .WithMessage("{PropertyName} is required");

        RuleFor(x => x.EndMile)
            .GreaterThanOrEqualTo(0)
            .WithMessage("{PropertyName} must be greater than or equal to 0");

        RuleFor(x => x.ActualEndRentDate)
            .NotEmpty()
            .WithMessage("{PropertyName} is required")
            .LessThanOrEqualTo(DateTime.UtcNow)
            .WithMessage("{PropertyName} cannot be in the future");

        RuleFor(x => x.DamageAmount)
            .GreaterThanOrEqualTo(0)
            .When(x => x.DamageAmount.HasValue)
            .WithMessage("{PropertyName} must be greater than or equal to 0");

        RuleFor(x => x.DamageDescription)
            .MaximumLength(1000)
            .When(x => !string.IsNullOrEmpty(x.DamageDescription))
            .WithMessage("{PropertyName} must not exceed {MaxLength} characters");

        RuleFor(x => x.Amount)
            .GreaterThan(0)
            .WithMessage("{PropertyName} must be greater than 0");

        RuleFor(x => x.Payment)
            .SetValidator(new PaymentRequestValidations()!)
            .When(x => x.Payment != null);
    }
} 