namespace SellingRentingCarsSystem.API.Validations;

public class VehiclePowerTrainRequestValidations : AbstractValidator<VehiclePowerTrainRequest>
{
    public VehiclePowerTrainRequestValidations()
    {
        var powerTrainTypes = string.Join(",",typeof(PowerTrainTypes).GetEnumNames());

        RuleFor(x => x.PowerTrain)
            .NotEmpty()
            .WithMessage("{PropertyName} is required")
            .IsEnumName(typeof(PowerTrainTypes), caseSensitive: true)
            .WithMessage($"PowerTrain have to be one of these types ({powerTrainTypes})");
    }
} 