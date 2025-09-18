namespace SellingRentingCarsSystem.API.DTOs;

public record FullMaintenanceResponse(
    string Id,
    VehicleResponse Vehicle,
    string Title,
    string Description,
    PaymentResponse Payment,
    DateTime DoneAt
);
