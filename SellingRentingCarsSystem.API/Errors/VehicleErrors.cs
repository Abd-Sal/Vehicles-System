namespace SellingRentingCarsSystem.API.Errors;

public class VehicleErrors
{
    //VehicleFeature
    public static readonly Error NullVehicleFeature =
        new(code: "VehicleFeature.Null",
            description: "VehicleFeature is required",
            statusCode: StatusCodes.Status400BadRequest);
    
    public static readonly Error NotFoundVehicleFeature =
        new(code: "VehicleFeature.NotFound",
            description: "VehicleFeature is not found",
            statusCode: StatusCodes.Status404NotFound);

    public static readonly Error DuplicatedVehicleFeature =
        new(code: "VehicleFeature.Duplicated",
            description: "VehicleFeature is already exist",
            statusCode: StatusCodes.Status409Conflict);

    //Vehicle
    public static readonly Error NotFoundVehicle =
        new(code: "Vehicle.NotFound",
            description: "Vehicle is not found",
            statusCode: StatusCodes.Status404NotFound);

    public static readonly Error NullVehicle =
        new(code: "Vehicle.Null",
            description: "Vehicle is required",
            statusCode: StatusCodes.Status400BadRequest);

    public static readonly Error DuplicatedVehicleVIN =
        new(code: "Vehicle.VIN.Duplicated",
            description: "Vehicle.VIN is already exist",
            statusCode: StatusCodes.Status409Conflict);

    public static readonly Error UnavailableVehicle =
        new(code: "Vehicle.Notavailable",
            description: "Vehicle is not availablee ",
            statusCode: StatusCodes.Status400BadRequest);
    
    public static readonly Error BookedVehicle =
        new(code: "Vehicle.Booked",
            description: "Vehicle is Booked",
            statusCode: StatusCodes.Status400BadRequest);


}
