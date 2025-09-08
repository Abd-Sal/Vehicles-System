namespace SellingRentingCarsSystem.API.Errors;

public class PaymentErrors
{
    public static readonly Error NullPayment =
        new(code: "Payment.Null",
            description: "Payment is required",
            statusCode: StatusCodes.Status400BadRequest);

    public static readonly Error NotFoundPayment =
        new(code: "Payment.NotFound",
            description: "Payment is not found",
            statusCode: StatusCodes.Status404NotFound);
}
