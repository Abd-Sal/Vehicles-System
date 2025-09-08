namespace SellingRentingCarsSystem.API.Validations;

public class CustomerRequestValidations : AbstractValidator<CustomerRequest>
{
    public CustomerRequestValidations()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty()
            .WithMessage("{PropertyName} is required")
            .Length(2, 100)
            .WithMessage("{PropertyName} must be between {MinLength} and {MaxLength} characters");

        RuleFor(x => x.LastName)
            .NotEmpty()
            .WithMessage("{PropertyName} is required")
            .Length(2, 100)
            .WithMessage("{PropertyName} must be between {MinLength} and {MaxLength} characters");

        RuleFor(x => x.BirthDate)
            .NotEmpty()
            .WithMessage("{PropertyName} is required")
            .LessThan(DateTime.UtcNow.AddYears(-16))
            .WithMessage("{PropertyName} must be in the past");

        RuleFor(x => x.NID)
            .NotEmpty()
            .WithMessage("{PropertyName} is required")
            .Length(2, 50)
            .WithMessage("{PropertyName} must be between {MinLength} and {MaxLength} characters");

        RuleFor(x => x.Address)
            .NotEmpty()
            .WithMessage("{PropertyName} is required")
            .Length(2, 450)
            .WithMessage("{PropertyName} must be between {MinLength} and {MaxLength} characters");

        RuleFor(x => x.PhoneNumber)
            .NotEmpty()
            .WithMessage("{PropertyName} is required")
            .Length(2, 50)
            .WithMessage("{PropertyName} must be between {MinLength} and {MaxLength} characters")
            .Must(BeAValidPhoneNumber)
            .WithMessage("{PropertyName} have to be only digits");
    }
    private bool BeAValidPhoneNumber(string phoneNumber)
    {
        return !string.IsNullOrWhiteSpace(phoneNumber) &&
               phoneNumber.All(char.IsDigit) &&
               phoneNumber.Length >= 10 &&
               phoneNumber.Length <= 15;
    }
} 