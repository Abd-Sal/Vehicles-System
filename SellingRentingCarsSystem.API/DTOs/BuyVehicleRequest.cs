namespace SellingRentingCarsSystem.API.DTOs;

public record BuyVehicleRequest(
    VehicleRequest Vehicle,
    PaymentRequest Payment
);
