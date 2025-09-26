namespace SellingRentingCarsSystem.API.Validations;

public class VehicleRequestValidations : AbstractValidator<VehicleRequest>
{
    public VehicleRequestValidations()
    {
        RuleFor(x => x.VIN)
            .NotEmpty()
            .WithMessage("{PropertyName} is required")
            .Length(17, 20)
            .WithMessage("{PropertyName} must be between {MinLength} and {MaxLength} characters");

        RuleFor(x => x.ModelID)
            .NotEmpty()
            .WithMessage("{PropertyName} is required");

        RuleFor(x => x.ExteriorColor)
            .NotEmpty()
            .WithMessage("{PropertyName} is required")
            .MaximumLength(200)
            .WithMessage("{PropertyName} must not exceed {MaxLength} characters");

        RuleFor(x => x.InteriorColor)
            .NotEmpty()
            .WithMessage("{PropertyName} is required")
            .MaximumLength(200)
            .WithMessage("{PropertyName} must not exceed {MaxLength} characters");

        RuleFor(x => x.RangeMiles)
            .GreaterThanOrEqualTo(0)
            .NotNull();

        RuleFor(x => x.BodyTypeID)
            .NotEmpty()
            .WithMessage("{PropertyName} is required");

        RuleFor(x => x.PowerTrainID)
            .NotEmpty()
            .WithMessage("{PropertyName} is required");

        RuleFor(x => x.VehiclePrice)
            .NotEmpty()
            .WithMessage("{PropertyName} is required")
            .GreaterThan(0)
            .WithMessage("{PropertyName} must be greater than 0");
    }
} 