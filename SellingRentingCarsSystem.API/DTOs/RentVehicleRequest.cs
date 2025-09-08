namespace SellingRentingCarsSystem.API.DTOs;

public record RentVehicleRequest(
    string VehicleID,
    string CustomerID,
    DateTime ExpectedEndRentDate,
    decimal ExpectedAmount,
    bool PayLater,
    PaymentRequest? Payment
);

