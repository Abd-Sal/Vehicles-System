namespace SellingRentingCarsSystem.API.Errors;

public class CustomerErrors
{
    public static readonly Error NullCustomer =
        new(code: "Customer.Null",
            description: "Customer is required",
            statusCode: StatusCodes.Status400BadRequest);

    public static readonly Error NotFoundCustomer =
        new(code: "Customer.NotFound",
            description: "Customer is not found",
            statusCode: StatusCodes.Status404NotFound);

    public static readonly Error DuplicatedCustomerNID =
        new(code: "Customer.DuplicatedNID",
            description: "Customer NID is already exist",
            statusCode: StatusCodes.Status409Conflict);

    public static readonly Error DuplicatedCustomerPhoneNumber =
        new(code: "Customer.DuplicatedPhone",
            description: "Customer PhoneNumber is already exist",
            statusCode: StatusCodes.Status409Conflict);
    
    public static readonly Error DuplicatedCustomerEmail =
        new(code: "Customer.DuplicatedEmail",
            description: "Customer Email is already exist",
            statusCode: StatusCodes.Status409Conflict);

}
