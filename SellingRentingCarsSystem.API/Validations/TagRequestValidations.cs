namespace SellingRentingCarsSystem.API.Validations;

public class TagRequestValidations : AbstractValidator<TagRequest>
{
    public TagRequestValidations()
    {
        RuleFor(x => x.TagName)
            .NotEmpty()
            .WithMessage("{PropertyName} is required")
            .MaximumLength(200)
            .WithMessage("{PropertyName} must not exceed {MaxLength} characters");
    }
} 
