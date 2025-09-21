namespace SellingRentingCarsSystem.API.Interfaces;

public interface IVehicleDetailsChargePortServices
{

    Task<Result<PaginatedList<ChargePortResponse>>> GetAllChargePorts(RequestFilters filters, CancellationToken cancellationToken = default);
    Task<Result<ChargePortResponse>> GetChargePortByID(string chargePortID, CancellationToken cancellationToken = default);
    Task<Result<ChargePortResponse>> GetChargePortByName(string chargePortName, CancellationToken cancellationToken = default);
    Task<Result<PaginatedList<ChargePortResponse>>> SearchChargePortsByName(string chargePortName, RequestFilters filters, CancellationToken cancellationToken = default);
    Task<Result<ChargePortResponse>> UpdateChargePort(string chargePortID, ChargePortRequest chargePortRequest, CancellationToken cancellationToken = default);
    Task<Result<ChargePortResponse>> AddChargePort(ChargePortRequest chargePortRequest, CancellationToken cancellationToken = default);

}
