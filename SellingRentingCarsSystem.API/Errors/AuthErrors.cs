namespace SellingRentingCarsSystem.API.Errors;

public class AuthErrors
{
    public static readonly Error UnauthenticateUserByName =
        new(code: "User.Unauthenticate",
            description: "Username/Password is wrong!",
            statusCode: StatusCodes.Status401Unauthorized);

    public static readonly Error NotFoundUser =
        new(code: "User.NotFound",
            description: "User is not found",
            statusCode: StatusCodes.Status404NotFound);

    public static readonly Error InvalidCode =
        new(code: "User.InvalidCode",
            description: "Code is invalid",
            statusCode: StatusCodes.Status400BadRequest);

}
