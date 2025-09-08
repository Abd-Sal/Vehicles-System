namespace SellingRentingCarsSystem.API.Validations;

public class MaintenanceRequestValidations : AbstractValidator<MaintenanceRequest>
{
    public MaintenanceRequestValidations()
    {
        RuleFor(x => x.VehicleID)
            .NotEmpty()
            .WithMessage("{PropertyName} is required");

        RuleFor(x => x.Title)
            .NotEmpty()
            .WithMessage("{PropertyName} is required")
            .MaximumLength(500)
            .WithMessage("{PropertyName} must not exceed {MaxLength} characters");

        RuleFor(x => x.Description)
            .NotEmpty()
            .WithMessage("{PropertyName} is required")
            .MaximumLength(4000)
            .WithMessage("{PropertyName} must not exceed {MaxLength} characters");

        RuleFor(x => x.Payment)
            .NotNull()
            .WithMessage("{PropertyName} is required")
            .SetValidator(new PaymentRequestValidations());
    }
} 