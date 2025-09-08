namespace SellingRentingCarsSystem.API.Validations;

public class ElectricPowerTrainRequestValidations : AbstractValidator<ElectricPowerTrainRequest>
{
    public ElectricPowerTrainRequestValidations()
    {
        RuleFor(x => x.HorsePower)
            .GreaterThan(0)
            .WithMessage("{PropertyName} must be greater than 0");

        RuleFor(x => x.Torque)
            .GreaterThan(0)
            .WithMessage("{PropertyName} must be greater than 0");

        RuleFor(x => x.ElectricRangeMiles)
            .GreaterThan(0)
            .WithMessage("{PropertyName} must be greater than 0");

        RuleFor(x => x.ChargePortTypeID)
            .NotEmpty()
            .WithMessage("{PropertyName} is required");

        RuleFor(x => x.BatteryCapacityKWh)
            .GreaterThan(0)
            .WithMessage("{PropertyName} must be greater than 0");
    }
} 