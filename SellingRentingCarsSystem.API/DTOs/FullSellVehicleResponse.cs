namespace SellingRentingCarsSystem.API.DTOs;

public record FullSellVehicleResponse(
    string Id,
    VehicleResponse VehicleResponse,
    CustomerResponse Customer,
    DateTime SellDate,
    PaymentResponse Payment
);


