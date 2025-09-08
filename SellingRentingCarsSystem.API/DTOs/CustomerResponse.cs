namespace SellingRentingCarsSystem.API.DTOs;

public record CustomerResponse(
    string Id,
    string FirstName,
    string LastName,
    DateTime BirthDate,
    string NID,
    string Address,
    string PhoneNumber,
    string? Email,
    DateTime JoinDate
);

