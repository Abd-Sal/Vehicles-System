namespace SellingRentingCarsSystem.API.Validations;

public class FuelTypeRequestValidations : AbstractValidator<FuelTypeRequest>
{
    public FuelTypeRequestValidations()
    {
        var fuelTypes = string.Join(",", typeof(FuelTypes).GetEnumNames());

        RuleFor(x => x.FuelTypeName)
            .NotEmpty()
            .WithMessage("{PropertyName} is required")
            .MaximumLength(200)
            .WithMessage("{PropertyName} must not exceed {MaxLength} characters")
            .IsEnumName(enumType: typeof(FuelTypes), caseSensitive: true)
            .WithMessage($"FuelTypeName must be one of ({fuelTypes})");
    }
} 