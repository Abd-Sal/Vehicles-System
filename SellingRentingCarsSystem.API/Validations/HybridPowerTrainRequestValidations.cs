namespace SellingRentingCarsSystem.API.Validations;

public class HybridPowerTrainRequestValidations : AbstractValidator<HybridPowerTrainRequest>
{
    public HybridPowerTrainRequestValidations()
    {
        var fuelDeliveryTypes = string.Join(",", typeof(FuelDeliveryTypes).GetEnumNames());
        var powerTrainAspirationTypes = string.Join(",", typeof(PowerTrainAspirationTypes).GetEnumNames());

        RuleFor(x => x.HorsePower)
            .GreaterThan(0)
            .WithMessage("{PropertyName} must be greater than 0");

        RuleFor(x => x.Torque)
            .GreaterThan(0)
            .WithMessage("{PropertyName} must be greater than 0");

        RuleFor(x => x.CombinedRangeMiles)
            .GreaterThanOrEqualTo(1)
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

        RuleFor(x => x.ElectricOnlyRangeMiles)
            .GreaterThan(0)
            .WithMessage("{PropertyName} must be greater than 0");

        RuleFor(x => x.ChargePortID)
            .NotEmpty()
            .WithMessage("{PropertyName} is required");

        RuleFor(x => x.BatteryCapacityKWh)
            .GreaterThan(0)
            .WithMessage("{PropertyName} must be greater than 0");

        RuleFor(x => x.PlugInHybrid).NotNull();
    }
} 