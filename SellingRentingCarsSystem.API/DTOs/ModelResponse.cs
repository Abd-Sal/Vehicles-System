namespace SellingRentingCarsSystem.API.DTOs;

public record ModelResponse(
    string Id,
    string MakeID,
    string ModelName,
    int ProductionYear
);

