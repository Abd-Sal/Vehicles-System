namespace SellingRentingCarsSystem.API.DTOs;

public record BookingVehicleResponse(

    string Id,
    string VehicleID,
    string CustomerID,
    DateTime StartDate,
    DateTime EndDate,
    decimal ExpectedAmount
);

