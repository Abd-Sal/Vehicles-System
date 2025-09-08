namespace SellingRentingCarsSystem.API.Validations;

public class UpdateHybridPowerTrainRequestValidations : AbstractValidator<UpdateHybridPowerTrainRequest>
{
    public UpdateHybridPowerTrainRequestValidations()
    {
        RuleFor(x => x.HorsePower)
            .GreaterThan(0)
            .WithMessage("{PropertyName} must be greater than 0");

        RuleFor(x => x.Torque)
            .GreaterThan(0)
            .WithMessage("{PropertyName} must be greater than 0");

        RuleFor(x => x.CombinationRangeMiles)
            .GreaterThan(0)
            .WithMessage("{PropertyName} must be greater than 0");

        RuleFor(x => x.FuelDeliveryID)
            .NotEmpty()
            .WithMessage("{PropertyName} is required");

        RuleFor(x => x.AspirationID)
            .NotEmpty()
            .WithMessage("{PropertyName} is required");

        RuleFor(x => x.EngineSize)
            .Must(x => x > 0 && x <= 24)
            .WithMessage("{PropertyName} must be greater than 0 and less then 24");

        RuleFor(x => x.Cylinders)
            .Must(x => x >= 1 && x <= 48)
            .WithMessage("{PropertyName} must be greater than 0 and less than 48");

        RuleFor(x => x.ElectricRangeMiles)
            .GreaterThan(0)
            .WithMessage("{PropertyName} must be greater than 0");

        RuleFor(x => x.ChargePortTypeID)
            .NotEmpty()
            .WithMessage("{PropertyName} is required");

        RuleFor(x => x.RangeMiles)
            .GreaterThanOrEqualTo(0)
            .WithMessage("{PropertyName} must be greater than or equal 0");

        RuleFor(x => x.BatteryCapacityKWh)
            .GreaterThan(0)
            .WithMessage("{PropertyName} must be greater than 0");

        RuleFor(x => x.PlugInHybrid)
            .NotNull();
    }
} 