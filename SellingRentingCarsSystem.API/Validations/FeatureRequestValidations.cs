namespace SellingRentingCarsSystem.API.Validations;

public class FeatureRequestValidations : AbstractValidator<FeatureRequest>
{
    public FeatureRequestValidations()
    {
        RuleFor(x => x.FeatureName)
            .NotEmpty()
            .WithMessage("{PropertyName} is required")
            .MaximumLength(200)
            .WithMessage("{PropertyName} must not exceed {MaxLength} characters");

        RuleFor(x => x.Category)
            .NotEmpty()
            .WithMessage("{PropertyName} is required")
            .MaximumLength(200)
            .WithMessage("{PropertyName} must not exceed {MaxLength} characters");
    }
} 