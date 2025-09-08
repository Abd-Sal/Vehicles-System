namespace SellingRentingCarsSystem.API.DTOs;

public record NearestDateToVehicleBeavailable(
    DateTime StartDate,
    DateTime? EndDate   //if this null : this means there is no booking for this vehicle after StartDate
);