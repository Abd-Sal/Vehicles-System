namespace SellingRentingCarsSystem.API.DTOs;

public record FullModelResponse(
    string Id,
    MakeResponse Make,
    string ModelName,
    int ProductionYear
);

