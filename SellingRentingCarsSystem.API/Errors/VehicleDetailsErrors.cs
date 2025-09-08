namespace SellingRentingCarsSystem.API.Errors;

public class VehicleDetailsErrors
{
    //BodyType
    public readonly static Error NullBodyType =
        new(code: "BodyType.Null",
            description: "bodytype is required",
            statusCode: StatusCodes.Status400BadRequest);

    public readonly static Error NotFoundBodyType =
        new(code: "BodyType.NotFound",
            description: "bodytype is not found",
            statusCode: StatusCodes.Status404NotFound);
    
    public readonly static Error DuplicatedBodyType =
        new(code: "BodyType.Duplicated",
            description: "bodytype is already exist",
            statusCode: StatusCodes.Status409Conflict);

    //PowerTrain
    public readonly static Error NullPowerTrain=
        new(code: "PowerTrain.Null",
            description: "PowerTrain is required",
            statusCode: StatusCodes.Status400BadRequest);

    public readonly static Error NotFoundPowerTrain=
        new(code: "PowerTrain.NotFound",
            description: "PowerTrain is not found",
            statusCode: StatusCodes.Status404NotFound);

    public readonly static Error DuplicatedPowerTrain=
        new(code: "PowerTrain.Duplicated",
            description: "PowerTrain is already exist",
            statusCode: StatusCodes.Status409Conflict);

    public readonly static Error WrongePowerTrain=
        new(code: "PowerTrain.Wronge",
            description: "PowerTrain is wronge",
            statusCode: StatusCodes.Status404NotFound);

    //Feature
    public readonly static Error NullFeature =
        new(code: "Feature.Null",
            description: "feature is required",
            statusCode: StatusCodes.Status400BadRequest);

    public readonly static Error NotfoundFeature =
        new(code: "Feature.NotFound",
            description: "feature is not found",
            statusCode: StatusCodes.Status404NotFound);

    public readonly static Error DuplicatedFeature =
        new(code: "Feature.Duplicated",
            description: "feature is already exist",
            statusCode: StatusCodes.Status409Conflict);

    //FuelType
    public readonly static Error NullFuelType =
        new(code: "FuelType.Null",
            description: "FuelType is required",
            statusCode: StatusCodes.Status400BadRequest);

    public readonly static Error NotfoundFuelType=
        new(code: "FuelType.NotFound",
            description: "FuelType is not found",
            statusCode: StatusCodes.Status404NotFound);

    public readonly static Error DuplicatedFuelType=
        new(code: "FuelType.Duplicated",
            description: "FuelType is already exist",
            statusCode: StatusCodes.Status409Conflict);

    //Make
    public readonly static Error NullMake =
        new(code: "Make.Null",
            description: "Make is required",
            statusCode: StatusCodes.Status400BadRequest);

    public readonly static Error NotFoundMake =
        new(code: "Make.NotFound",
            description: "Make is not found",
            statusCode: StatusCodes.Status400BadRequest);

    public readonly static Error DuplicatedMake =
        new(code: "Make.Duplicated",
            description: "Make is already exist",
            statusCode: StatusCodes.Status409Conflict);

    //Model
    public readonly static Error NullModel =
        new(code: "Model.Null",
            description: "Model is required",
            statusCode: StatusCodes.Status400BadRequest);

    public readonly static Error NotFoundModel =
        new(code: "Model.NotFound",
            description: "Model is not found",
            statusCode: StatusCodes.Status400BadRequest);

    public readonly static Error DuplicatedModel =
        new(code: "Model.Duplicated",
            description: "Model is already exist",
            statusCode: StatusCodes.Status409Conflict);

    //TransmissionType
    public readonly static Error NullTransmissionType =
        new(code: "TransmissionType.Null",
            description: "TransmissionType is required",
            statusCode: StatusCodes.Status400BadRequest);

    public readonly static Error NotFoundTransmissionType =
        new(code: "TransmissionType.NotFound",
            description: "TransmissionType is not found",
            statusCode: StatusCodes.Status400BadRequest);

    public readonly static Error DuplicatedTransmissionType =
        new(code: "TransmissionType.Duplicated",
            description: "TransmissionType is already exist",
            statusCode: StatusCodes.Status409Conflict);

    //Maintenance
    public readonly static Error NullMaintenance =
        new(code: "Maintenance.Null",
            description: "Maintenance is required",
            statusCode: StatusCodes.Status400BadRequest);

    //FuelDelivery
    public readonly static Error NullFuelDelivery =
        new(code: "FuelDelivery.Null",
            description: "FuelDelivery is required",
            statusCode: StatusCodes.Status400BadRequest);

    public readonly static Error NotFoundFuelDelivery =
        new(code: "FuelDelivery.NotFound",
            description: "FuelDelivery is not found",
            statusCode: StatusCodes.Status404NotFound);
    
    public readonly static Error DuplicatedFuelDelivery =
        new(code: "FuelDelivery.Duplicated",
            description: "FuelDelivery is already exist",
            statusCode: StatusCodes.Status409Conflict);

    //Aspiration
    public readonly static Error NullAspiration =
    new(code: "Aspiration.Null",
        description: "Aspiration is required",
        statusCode: StatusCodes.Status400BadRequest);

    public readonly static Error NotFoundAspiration =
        new(code: "Aspiration.NotFound",
            description: "Aspiration is not found",
            statusCode: StatusCodes.Status404NotFound);

    public readonly static Error DuplicatedAspiration =
        new(code: "Aspiration.Duplicated",
            description: "Aspiration is already exist",
            statusCode: StatusCodes.Status409Conflict);

    //ChargePort
    public readonly static Error NullChargePort =
    new(code: "ChargePort.Null",
        description: "ChargePort is required",
        statusCode: StatusCodes.Status400BadRequest);

    public readonly static Error NotFoundChargePort =
        new(code: "ChargePort.NotFound",
            description: "ChargePort is not found",
            statusCode: StatusCodes.Status404NotFound);

    public readonly static Error DuplicatedChargePort =
        new(code: "ChargePort.Duplicated",
            description: "ChargePort is already exist",
            statusCode: StatusCodes.Status409Conflict);

}
