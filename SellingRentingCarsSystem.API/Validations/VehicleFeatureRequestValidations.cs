namespace SellingRentingCarsSystem.API.Validations;

public class VehicleFeatureRequestValidations : AbstractValidator<VehicleFeatureRequest>
{
    public VehicleFeatureRequestValidations()
    {
        RuleFor(x => x.FeatureID)
            .NotEmpty()
            .WithMessage("{PropertyName} is required");
    }
} 