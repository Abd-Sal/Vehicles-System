namespace SellingRentingCarsSystem.API.Validations;

public class ForgetPasswordRequestValidations : AbstractValidator<ForgetPasswordRequest>
{
    public ForgetPasswordRequestValidations()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress();
    }
} 
