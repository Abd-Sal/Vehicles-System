namespace SellingRentingCarsSystem.API.Validations;

public class VehiclePowerTrainRequestValidations : AbstractValidator<VehiclePowerTrainRequest>
{
    public VehiclePowerTrainRequestValidations()
    {
        var powerTrainTypes = string.Join(",",typeof(PowerTrainTypes).GetEnumNames());

        RuleFor(x => x.PowerTrain)
            .NotEmpty()
            .WithMessage("{PropertyName} is required");
    }
} 