namespace SellingRentingCarsSystem.API.Validations;

public class FullCombinationVehicleRequestValidations : AbstractValidator<FullCombinationVehicleRequest>
{
    public FullCombinationVehicleRequestValidations()
    {
        RuleFor(x => x.VIN)
            .NotEmpty()
            .WithMessage("{PropertyName} is required")
            .Length(17, 20)
            .WithMessage("{PropertyName} must be between {MinLength} and {MaxLength} characters");

        RuleFor(x => x.Model)
            .NotNull()
            .WithMessage("{PropertyName} is required")
            .SetValidator(new ModelRequestValidations());

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

        RuleFor(x => x.BodyType)
            .NotNull()
            .WithMessage("{PropertyName} is required")
            .SetValidator(new BodyTypeRequestValidations());

        RuleFor(x => x.FuelType)
            .NotNull()
            .WithMessage("{PropertyName} is required")
            .SetValidator(new FuelTypeRequestValidations());

        RuleFor(x => x.TransmissionType)
            .NotNull()
            .WithMessage("{PropertyName} is required")
            .SetValidator(new TransmissionTypeRequestValidations());

        RuleFor(x => x.PowerTrain)
            .NotNull()
            .WithMessage("{PropertyName} is required")
            .SetValidator(new CombinationPowerTrainRequestValidations());

        RuleFor(x => x.VehiclePrice)
            .GreaterThanOrEqualTo(1)
            .WithMessage("{PropertyName} must be greater than 0");
    }
} 