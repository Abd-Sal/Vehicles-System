namespace SellingRentingCarsSystem.API.Errors;

public class RentVehicleErrors
{
    public static readonly Error NullRentVehicle =
        new(code: "RentVehicle.Null",
            description: "RentVehicle is required",
            statusCode: StatusCodes.Status400BadRequest);

    public static readonly Error NotFoundRentVehicle =
        new(code: "RentVehicle.NotFound",
            description: "RentVehicle is not found",
            statusCode: StatusCodes.Status404NotFound);

    public static readonly Error DuplicatedPaidRentVehicle =
        new(code: "RentVehicle.DuplicatedPaid",
            description: "RentVehicle is already paid",
            statusCode: StatusCodes.Status400BadRequest);

    public static readonly Error WrongDetailsRentVehicle =
        new(code: "RentVehicle.WrongDetails",
            description: "RentVehicle has wrong details (VehicleID OR CustomerID)",
            statusCode: StatusCodes.Status400BadRequest);
}
