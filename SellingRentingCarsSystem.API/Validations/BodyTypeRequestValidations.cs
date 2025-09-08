namespace SellingRentingCarsSystem.API.Validations;

public class BodyTypeRequestValidations : AbstractValidator<BodyTypeRequest>
{
    public BodyTypeRequestValidations()
    {
        RuleFor(x => x.BodyTypeName)
            .NotEmpty()
            .WithMessage("{PropertyName} is required")
            .Length(2, 200)
            .WithMessage("{PropertyName} must be between {MinLength} and {MaxLength} characters");

        RuleFor(x => x.DoorCount)
            .NotEmpty()
            .WithMessage("{PropertyName} is required")
            .GreaterThanOrEqualTo(0)
            .WithMessage("{PropertyName} must be greater than or equal 0");
    }
} 
