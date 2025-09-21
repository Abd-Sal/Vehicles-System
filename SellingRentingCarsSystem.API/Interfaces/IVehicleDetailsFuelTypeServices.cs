namespace SellingRentingCarsSystem.API.Interfaces;

public interface IVehicleDetailsFuelTypeServices
{
    Task<Result<PaginatedList<FuelTypeResponse>>> GetAllFuelTypes(RequestFilters filters, CancellationToken cancellationToken = default);
    Task<Result<FuelTypeResponse>> GetFuelTypeByID(string fuelTypeID, CancellationToken cancellationToken = default);
    Task<Result<FuelTypeResponse>> GetFuelTypeByName(string fuelTypeName, CancellationToken cancellationToken = default);
    Task<Result<PaginatedList<FuelTypeResponse>>> SearchFuelTypesByName(string fuelTypeName, RequestFilters filters, CancellationToken cancellationToken = default);
    Task<Result<FuelTypeResponse>> AddFuelType(FuelTypeRequest fuelTypeRequest, CancellationToken cancellationToken = default);
    Task<Result<FuelTypeResponse>> UpdateFuelType(string fuelTypeID, FuelTypeRequest fuelTypeRequest, CancellationToken cancellationToken = default);
}
