namespace SellingRentingCarsSystem.API.Validations;

public class ModelRequestValidations : AbstractValidator<ModelRequest>
{
    public ModelRequestValidations()
    {
        RuleFor(x => x.MakeID)
            .NotEmpty()
            .WithMessage("{PropertyName} is required");

        RuleFor(x => x.ModelName)
            .NotEmpty()
            .WithMessage("{PropertyName} is required")
            .MaximumLength(200)
            .WithMessage("{PropertyName} must not exceed {MaxLength} characters");

        RuleFor(x => x.ProductoinYear)
            .NotEmpty()
            .WithMessage("{PropertyName} is required")
            .GreaterThan(1900)
            .WithMessage("{PropertyName} must be greater than 1900")
            .LessThanOrEqualTo(DateTime.UtcNow.Year)
            .WithMessage("{PropertyName} cannot be in the future");
    }
} 