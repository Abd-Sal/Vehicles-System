namespace SellingRentingCarsSystem.API.Validations;

public class VehicleStatusRequestValidations : AbstractValidator<VehicleStatusRequest>
{
    public VehicleStatusRequestValidations()
    {
        var statusesVehicle = string.Join(",", typeof(VehiclesStatus).GetEnumNames());

        RuleFor(x => x.Status)
            .NotEmpty()
            .WithMessage("{PropertyName} is required")
            .MaximumLength(200)
            .WithMessage("{PropertyName} must not exceed {MaxLength} characters")
            .IsEnumName(enumType: typeof(VehiclesStatus), caseSensitive: true)
            .WithMessage($"Status must be one of the these values ({statusesVehicle})");
    }
} 