namespace SellingRentingCarsSystem.API.Validations;

public class TransmissionTypeRequestValidations : AbstractValidator<TransmissionTypeRequest>
{
    public TransmissionTypeRequestValidations()
    {
        RuleFor(x => x.TransmissionTypeName)
            .NotEmpty()
            .WithMessage("{PropertyName} is required")
            .MaximumLength(200)
            .WithMessage("{PropertyName} must not exceed {MaxLength} characters");
    }
} 