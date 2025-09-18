namespace SellingRentingCarsSystem.API.DTOs;

public record FullBookingVehicleResponse(
    string Id,
    VehicleResponse Vehicle,
    CustomerResponse Customer,
    DateTime StartDate,
    DateTime EndDate,
    decimal ExpectedAmount
);



