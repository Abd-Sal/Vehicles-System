namespace SellingRentingCarsSystem.API.Validations;

public class PaymentRequestValidations : AbstractValidator<PaymentRequest>
{
    public PaymentRequestValidations()
    {
        RuleFor(x => x.PayType)
            .NotEmpty()
            .WithMessage("{PropertyName} is required")
            .Must(x => "cash credit".Contains(x.Trim().ToLower()))
            .WithMessage("{PropertyName} must be either 'cash' or 'credit'")
            .Length(2, 200)
            .WithMessage("{PropertyName} must be between {MinLength} and {MaxLength} characters");

        RuleFor(x => x.Amount)
            .NotEmpty()
            .WithMessage("{PropertyName} is required")
            .GreaterThan(0)
            .WithMessage("{PropertyName} must be greater than 0");

        RuleFor(x => x.Title)
            .MaximumLength(200)
            .When(x => !string.IsNullOrEmpty(x.Title))
            .WithMessage("{PropertyName} must not exceed {MaxLength} characters");

        RuleFor(x => x.Description)
            .MaximumLength(500)
            .When(x => !string.IsNullOrEmpty(x.Description))
            .WithMessage("{PropertyName} must not exceed {MaxLength} characters");
    }
} 