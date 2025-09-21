namespace SellingRentingCarsSystem.API.Interfaces;

public interface IVehicleDetailsTransmissionTypeServices
{
    Task<Result<PaginatedList<TransmissionTypeResponse>>> GetAllTransmissionTypes(RequestFilters filters, CancellationToken cancellationToken = default);
    Task<Result<TransmissionTypeResponse>> GetTransmissionTypeByID(string transmissionTypeID, CancellationToken cancellationToken = default);
    Task<Result<TransmissionTypeResponse>> GetTransmissionTypeByName(string transmissionTypeName, CancellationToken cancellationToken = default);
    Task<Result<PaginatedList<TransmissionTypeResponse>>> SearchTransmissionTypesByName(string transmissionTypeName, RequestFilters filters, CancellationToken cancellationToken = default);
    Task<Result<TransmissionTypeResponse>> AddTransmissionType(TransmissionTypeRequest transmissionTypeRequest, CancellationToken cancellationToken = default);
    Task<Result<TransmissionTypeResponse>> UpdateTransmissionType(string transmissionTypeID, TransmissionTypeRequest transmissionTypeRequest, CancellationToken cancellationToken = default);
}
