namespace SellingRentingCarsSystem.API.Validations;

public class MakeRequestValidations : AbstractValidator<MakeRequest>
{
    public MakeRequestValidations()
    {
        RuleFor(x => x.MakeName)
            .NotEmpty()
            .WithMessage("{PropertyName} is required")
            .MaximumLength(200)
            .WithMessage("{PropertyName} must not exceed {MaxLength} characters");

        RuleFor(x => x.CountryOfOrigin)
            .NotEmpty()
            .WithMessage("{PropertyName} is required")
            .MaximumLength(200)
            .WithMessage("{PropertyName} must not exceed {MaxLength} characters");
    }
} 