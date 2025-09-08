namespace SellingRentingCarsSystem.API.Errors;

public class SellVehicleErrors
{
    public static readonly Error NullSellVehicle =
        new(code: "SellVehicle.Null",
            description: "SellVehicle is required",
            statusCode: StatusCodes.Status400BadRequest);

    public static readonly Error NotFoundSellVehicle =
        new(code: "SellVehicle.NotFound",
            description: "SellVehicle is not found",
            statusCode: StatusCodes.Status404NotFound);


}
