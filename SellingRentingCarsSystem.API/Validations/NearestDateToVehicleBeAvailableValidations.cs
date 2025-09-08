namespace SellingRentingCarsSystem.API.Validations;

public class NearestDateToVehicleBeavailableValidations : AbstractValidator<NearestDateToVehicleBeavailable>
{
    public NearestDateToVehicleBeavailableValidations()
    {
        RuleFor(x => x.StartDate)
            .NotEmpty()
            .WithMessage("{PropertyName} is required")
            .Must(x => x.Date >= DateTime.UtcNow.Date)
            .WithMessage("{PropertyName} must be greater than or equal to current date");

        RuleFor(x => x.EndDate)
            .GreaterThan(x => x.StartDate)
            .When(x => x.EndDate.HasValue)
            .WithMessage("{PropertyName} must be greater than StartDate when provided");
    }
} 
