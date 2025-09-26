namespace SellingRentingCarsSystem.API.Validations;

public class ImageRequestValidations : AbstractValidator<ImageRequest>
{
    public ImageRequestValidations()
    {
        RuleFor(x => x.Caption)
            .MaximumLength(200)
            .When(x => !string.IsNullOrEmpty(x.Caption))
            .WithMessage("{PropertyName} must not exceed {MaxLength} characters");

        RuleFor(x => x.Image)
            .NotEmpty()
            .WithMessage("{PropertyName} is required");
    }
} 