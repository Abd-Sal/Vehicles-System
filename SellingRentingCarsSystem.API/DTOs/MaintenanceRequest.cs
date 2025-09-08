namespace SellingRentingCarsSystem.API.DTOs;

public record MaintenanceRequest(
    string VehicleID,
    string Title,
    string Description,
    PaymentRequest Payment
);