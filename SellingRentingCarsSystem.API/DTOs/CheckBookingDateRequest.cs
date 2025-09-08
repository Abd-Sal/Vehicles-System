namespace SellingRentingCarsSystem.API.DTOs;

public record CheckBookingDateRequest(
    string VehicleID,
    DateTime StartDate,
    DateTime EndDate
);
