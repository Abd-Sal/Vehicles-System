namespace SellingRentingCarsSystem.API.DTOs;

public record BodyTypeRequest(
    string BodyTypeName,
    int DoorCount
);
