namespace SellingRentingCarsSystem.API.Validations;

public class CheckBookingDateRequestValidations : AbstractValidator<CheckBookingDateRequest>
{
    public CheckBookingDateRequestValidations()
    {
        RuleFor(x => x.VehicleID)
            .NotEmpty()
            .WithMessage("{PropertyName} is required");

        RuleFor(x => x.StartDate)
            .NotEmpty()
            .WithMessage("{PropertyName} is required")
            .Must(x => x.Date >= DateTime.UtcNow.Date)
            .WithMessage("{PropertyName} must be greater than or equal to current date");

        RuleFor(x => x.EndDate)
            .NotEmpty()
            .WithMessage("{PropertyName} is required")
            .GreaterThan(x => x.StartDate)
            .WithMessage("{PropertyName} must be greater than StartDate")
            .Must(x => x.Date >= DateTime.UtcNow.Date)
            .WithMessage("{PropertyName} must be greater than or equal to current date");
    }
} 