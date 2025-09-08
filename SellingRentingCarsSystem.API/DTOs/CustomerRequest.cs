namespace SellingRentingCarsSystem.API.DTOs;

public record CustomerRequest(
    string FirstName,
    string LastName,
    DateTime BirthDate,
    string NID,
    string Address,
    string PhoneNumber,
    string? Email
);

