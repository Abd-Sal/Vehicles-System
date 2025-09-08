namespace SellingRentingCarsSystem.API.Interfaces;

public interface ICustomerServices
{
    Task<Result<CustomerResponse>> AddCustmomer(CustomerRequest customerRequest, CancellationToken cancellationToken = default);
    Task<Result> UpdateCustmomer(string customerID, CustomerRequest customerRequest, CancellationToken cancellationToken = default);
    Task<Result<PaginatedList<CustomerResponse>>> GetAllCustmomersAsync(RequestFilters filters, CancellationToken cancellationToken = default);
    Task<Result<CustomerResponse>> GetCustmomerAsync(string customerID, CancellationToken cancellationToken = default);
    Task<Result<PaginatedList<CustomerResponse>>> SearchForCustmomers(string customerName, RequestFilters filters, CancellationToken cancellationToken = default);
    Task<Result<PaginatedList<RentVehicleResponse>>> RentHistoryByCustmomer(string customerID, RequestFilters filters, CancellationToken cancellationToken = default);
    Task<Result<PaginatedList<SellVehicleResponse>>> SellHistoryByCustmomer(string customerID, RequestFilters filters, CancellationToken cancellationToken = default);
    Task<Result<PaginatedList<BookingVehicleResponse>>> CustomerBooks(string customerID, RequestFilters filters, CancellationToken cancellationToken = default);
}
