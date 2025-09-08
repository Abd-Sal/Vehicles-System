namespace SellingRentingCarsSystem.API.DTOs;

public record SellVehicleRequest(
    string VehicleID,
    string CustomerID,
    PaymentRequest Payment
);

