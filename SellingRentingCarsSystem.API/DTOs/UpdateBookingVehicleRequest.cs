namespace SellingRentingCarsSystem.API.DTOs;

public record UpdateBookingVehicleRequest(
    DateTime StartDate,
    DateTime EndDate,
    decimal ExpectedAmount
);


