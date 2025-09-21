namespace SellingRentingCarsSystem.API.Interfaces;

public interface IVehicleDetailsFuelDeliveryServices
{
    Task<Result<PaginatedList<FuelDeliveryResponse>>> GetAllFuelDeliveries(RequestFilters filters, CancellationToken cancellationToken = default);
    Task<Result<FuelDeliveryResponse>> GetFuelDeliveryByID(string fuelDeliveryID, CancellationToken cancellationToken = default);
    Task<Result<FuelDeliveryResponse>> GetFuelDeliveryByName(string fuelDeliveryName, CancellationToken cancellationToken = default);
    Task<Result<PaginatedList<FuelDeliveryResponse>>> SearchFuelDeliveriesByName(string fuelDeliveryName, RequestFilters filters, CancellationToken cancellationToken = default);
    Task<Result<FuelDeliveryResponse>> AddFuelDelivery(FuelDeliveryRequest fuelDeliveryRequest, CancellationToken cancellationToken = default);
    Task<Result<FuelDeliveryResponse>> UpdateFuelDelivery(string fuelDeliveryID, FuelDeliveryRequest fuelDeliveryRequest, CancellationToken cancellationToken = default);

}
