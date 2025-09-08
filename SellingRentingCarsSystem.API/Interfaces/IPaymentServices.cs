namespace SellingRentingCarsSystem.API.Interfaces;

public interface IPaymentServices
{
    Task<Result<List<PaymentResponse>>> GetAllPaymentsForSells(CancellationToken cancellationToken = default);
    Task<Result<List<PaymentResponse>>> GetAllPaymentsForRents(CancellationToken cancellationToken = default);
    Task<Result<List<PaymentResponse>>> GetAllPaymentsForMaintenance(CancellationToken cancellationToken = default);
    Task<Result<PaymentResponse>> GetPaymentByID(string paymentID, CancellationToken cancellationToken = default);
    Task<Result<PaymentResponse>> DoPayment(PaymentRequest paymentRequest, CancellationToken cancellationToken = default);
    Task<Result> RemovePayment(string paymentID, CancellationToken cancellationToken = default);
}
