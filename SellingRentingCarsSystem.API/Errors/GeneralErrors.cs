namespace SellingRentingCarsSystem.API.Errors;

public class GeneralErrors
{
    public static Error UnexpectedError(string errorPlace) =>
        new(code: "System.UnexpectedError",
            description: $"Unexpected error happen in background({errorPlace})",
            statusCode: StatusCodes.Status500InternalServerError);

}
