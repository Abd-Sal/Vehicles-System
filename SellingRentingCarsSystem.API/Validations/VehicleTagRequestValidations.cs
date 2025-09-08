namespace SellingRentingCarsSystem.API.Validations;

public class VehicleTagRequestValidations : AbstractValidator<VehicleTagRequest>
{
    public VehicleTagRequestValidations()
    {
        RuleFor(x => x.VehicleID)
            .NotEmpty()
            .WithMessage("{PropertyName} is required");

        RuleFor(x => x.TagID)
            .NotEmpty()
            .WithMessage("{PropertyName} is required");
    }
} 