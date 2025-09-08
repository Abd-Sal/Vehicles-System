namespace SellingRentingCarsSystem.API.DTOs;

public record RentedVehicleResponse(
    string RentID,
    string VehicleID,
    string CustomerID,
    string FullCarModel,
    DateTime StartDate,
    DateTime ExpectedEndDate,
    decimal ExpectedAmount
);