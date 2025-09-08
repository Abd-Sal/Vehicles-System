namespace SellingRentingCarsSystem.API.Validations;

public class UpdateCombinationPowerTrainRequestValidations : AbstractValidator<UpdateCombinationPowerTrainRequest>
{
    public UpdateCombinationPowerTrainRequestValidations()
    {
        RuleFor(x => x.HorsePower)
            .GreaterThan(0)
            .WithMessage("{PropertyName} must be greater than 0");

        RuleFor(x => x.Torque)
            .GreaterThan(0)
            .WithMessage("{PropertyName} must be greater than 0");

        RuleFor(x => x.CombinedRangeMiles)
            .GreaterThan(0)
            .WithMessage("{PropertyName} must be greater than 0");

        RuleFor(x => x.RangeMiles)
            .GreaterThanOrEqualTo(0)
            .WithMessage("{PropertyName} must be greater than or equal 0");

        RuleFor(x => x.FuelDeliveryID)
            .NotEmpty()
            .WithMessage("{PropertyName} is required");

        RuleFor(x => x.AspirationID)
            .NotEmpty()
            .WithMessage("{PropertyName} is required");

        RuleFor(x => x.EngineSize)
            .Must(x => x > 0 && x <= 24)
            .WithMessage("{PropertyName} must be greater than 0 and less than 24");

        RuleFor(x => x.Cylinders)
            .Must(x => x >= 1 && x <= 48)
            .WithMessage("{PropertyName} must be greater than 0 and less than 48");
    }
} 