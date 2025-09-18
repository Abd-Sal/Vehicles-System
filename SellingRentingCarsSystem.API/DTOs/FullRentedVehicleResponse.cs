namespace SellingRentingCarsSystem.API.DTOs;

public record FullRentedVehicleResponse(
    string RentID,
    VehicleResponse Vehicle,
    CustomerResponse Customer,
    DateTime StartDate,
    DateTime ExpectedEndDate,
    decimal ExpectedAmount
);