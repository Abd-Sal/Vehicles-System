namespace SellingRentingCarsSystem.API.Validations;

public class UpdateElectricPowerTrainRequestValidations : AbstractValidator<UpdateElectricPowerTrainRequest>
{
    public UpdateElectricPowerTrainRequestValidations()
    {
        RuleFor(x => x.HorsePower)
            .GreaterThanOrEqualTo(1)
            .WithMessage("{PropertyName} must be greater than 0");

        RuleFor(x => x.Torque)
            .GreaterThanOrEqualTo(1)
            .WithMessage("{PropertyName} must be greater than 0");

        RuleFor(x => x.ElectricRangeMiles)
            .GreaterThan(0)
            .WithMessage("{PropertyName} must be greater than 0");

        RuleFor(x => x.ChargePortTypeID)
            .NotEmpty()
            .WithMessage("{PropertyName} is required");

        RuleFor(x => x.RangeMiles)
            .GreaterThanOrEqualTo(0)
            .WithMessage("{PropertyName} must be greater than 0");

        RuleFor(x => x.BatteryCapacityKWh)
            .GreaterThan(0)
            .WithMessage("{PropertyName} must be greater than 0");
    }
} 