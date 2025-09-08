namespace SellingRentingCarsSystem.API.DTOs;

public record SellVehicleResponse(
    string Id,
    string VehicleID,
    string CustomerID,
    DateTime SellDate,
    string PaymentID
);


