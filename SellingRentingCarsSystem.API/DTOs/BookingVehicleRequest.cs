namespace SellingRentingCarsSystem.API.DTOs;

public record BookingVehicleRequest(
    string VehicleID,
    string CustomerID,
    DateTime StartDate,
    DateTime EndDate,
    decimal ExpectedAmount
);


