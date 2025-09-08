namespace SellingRentingCarsSystem.API.Implementations;

public class PaymentServices(AppDbContext appDbContext, IMapper mapper,
    ILogger<PaymentServices> logger) : IPaymentServices
{
    private readonly AppDbContext appDbContext = appDbContext;
    private readonly IMapper mapper = mapper;
    private readonly ILogger<PaymentServices> logger = logger;

    public async Task<Result<PaymentResponse>> DoPayment
        (PaymentRequest paymentRequest, CancellationToken cancellationToken = default)
    {
        if (paymentRequest is null)
            return Result.Failure<PaymentResponse>(PaymentErrors.NullPayment);

        var payment = paymentRequest.ToPayment(mapper);
        await appDbContext.Payments.AddAsync(payment, cancellationToken);
        await appDbContext.SaveChangesAsync(cancellationToken);

        logger.LogInformation("payment is done ID:({vehicleID})", payment.Id);

        return Result.Success(payment.ToPaymentResponse(mapper));
    }

    public async Task<Result<List<PaymentResponse>>> GetAllPaymentsForMaintenance
        (CancellationToken cancellationToken = default)
    {
        var result = (await appDbContext.Maintenances.AsNoTracking()
            .Include(x => x.Payment)
            .Select(x => x.Payment)
            .OrderByDescending(x => x.DateOfPay)
            .ToListAsync(cancellationToken))
            .ToPaymentResponses(mapper);

        return Result.Success(result);
    }

    public async Task<Result<List<PaymentResponse>>> GetAllPaymentsForRents
        (CancellationToken cancellationToken = default)
    {
        var result = (await appDbContext.RentVehicles.AsNoTracking()
            .Include(x => x.Payment)
            .Where(x => x.Payment != default(Payment))
            .Select(x => x.Payment)
            .OrderByDescending(x => x!.DateOfPay)
            .ToListAsync(cancellationToken))!
            .ToPaymentResponses(mapper);

        return Result.Success(result);
    }

    public async Task<Result<List<PaymentResponse>>> GetAllPaymentsForSells
        (CancellationToken cancellationToken = default)
    {
        var result = (await appDbContext.SellVehicles.AsNoTracking()
            .Include(x => x.Payment)
            .Select(x => x.Payment)
            .OrderByDescending(x => x.DateOfPay)
            .ToListAsync(cancellationToken))!
            .ToPaymentResponses(mapper);

        return Result.Success(result);
    }

    public async Task<Result<PaymentResponse>> GetPaymentByID
        (string paymentID, CancellationToken cancellationToken = default)
    {
        if (await appDbContext.Payments.FindAsync(paymentID, cancellationToken) is not { } payment)
            return Result.Failure<PaymentResponse>(PaymentErrors.NotFoundPayment);
        return Result.Success(payment.ToPaymentResponse(mapper));
    }
    
    public async Task<Result> RemovePayment
        (string paymentID, CancellationToken cancellationToken = default)
    {
        if (!(await appDbContext.Payments.AnyAsync(x => x.Id == paymentID, cancellationToken)))
            return Result.Failure(PaymentErrors.NotFoundPayment);

        await appDbContext.Payments.Where(x => x.Id == paymentID)
            .ExecuteDeleteAsync(cancellationToken);

        logger.LogInformation("payment is removed ID:({vehicleID})", paymentID);

        return Result.Success();
    }
}
