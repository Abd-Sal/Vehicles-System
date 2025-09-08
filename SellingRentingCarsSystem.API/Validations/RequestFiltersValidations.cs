namespace SellingRentingCarsSystem.API.Validations;

public class RequestFiltersValidations : AbstractValidator<RequestFilters>
{
    public RequestFiltersValidations()
    {
        RuleFor(x => x.PageSize)
            .LessThan(x => 100);
    }
} 