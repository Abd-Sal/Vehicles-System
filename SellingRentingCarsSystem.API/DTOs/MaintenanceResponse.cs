namespace SellingRentingCarsSystem.API.DTOs;

public record MaintenanceResponse(
    string Id,
    string VehicleID,
    string Title,
    string Description,
    string PaymentID,
    DateTime DoneAt
);
