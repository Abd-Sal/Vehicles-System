namespace SellingRentingCarsSystem.API.Implementations;

public class SellServices(AppDbContext appDbContext, IMapper mapper,
    IPaymentServices paymentServices, IBookingServices bookingServices,
    ILogger<SellServices> logger) : ISellServices
{
    private readonly AppDbContext appDbContext = appDbContext;
    private readonly IMapper mapper = mapper;
    private readonly IPaymentServices paymentServices = paymentServices;
    private readonly IBookingServices bookingServices = bookingServices;
    private readonly ILogger<SellServices> logger = logger;

    public async Task<Result<PaginatedList<FullSellVehicleResponse>>> AllSelledVehicles
        (RequestFilters filters, CancellationToken cancellationToken = default)
    {
        var query = appDbContext.SellVehicles
            .ToFullSellVehicleResponses(mapper);

        var result = await PaginatedList<FullSellVehicleResponse>.CreateAsync(query, filters.PageNumber, filters.PageSize, cancellationToken);
        
        return Result.Success(result);
    }

    public async Task<Result> ReturnSelledVehicle
        (string sellVehicleID, CancellationToken cancellationToken = default)
    {
        if (await appDbContext.SellVehicles.FindAsync(sellVehicleID, cancellationToken) is not { } sellVehicle)
            return Result.Failure(SellVehicleErrors.NotFoundSellVehicle);

        await appDbContext.Vehicles.Where(x => x.Id == sellVehicle.VehicleID)
            .ExecuteUpdateAsync(setters =>
                setters
                    .SetProperty(x => x.VehicleStatus, VehiclesStatus.available.ToString()),
                cancellationToken
            );

        await appDbContext.SellVehicles.Where(x => x.Id == sellVehicleID)
            .ExecuteDeleteAsync(cancellationToken);

        var removePayment = await paymentServices.RemovePayment(sellVehicle.PaymentID, cancellationToken);
        if (removePayment.IsFailure)
            return Result.Failure(removePayment.Error);

        await appDbContext.SaveChangesAsync(cancellationToken);

        logger.LogInformation("vehicle:(ID:{vehicleID}) is returned", sellVehicle.VehicleID);

        return Result.Success();
    }

    public async Task<Result<SellVehicleResponse>> SellVehicle
        (SellVehicleRequest sellVehicleRequest, CancellationToken cancellationToken = default)
    {
        if (sellVehicleRequest is null)
            return Result.Failure<SellVehicleResponse>(SellVehicleErrors.NullSellVehicle);

        if (!(await appDbContext.Vehicles.AnyAsync(x => x.Id == sellVehicleRequest.VehicleID, cancellationToken)))
            return Result.Failure<SellVehicleResponse>(VehicleErrors.NotFoundVehicle);
        
        if (await appDbContext.Vehicles.AnyAsync(x => x.Id == sellVehicleRequest.VehicleID &&
            x.VehicleStatus != VehiclesStatus.available.ToString(), cancellationToken))
            return Result.Failure<SellVehicleResponse>(VehicleErrors.UnavailableVehicle);

        if (!(await appDbContext.Customers.AnyAsync(x => x.Id == sellVehicleRequest.CustomerID, cancellationToken)))
            return Result.Failure<SellVehicleResponse>(CustomerErrors.NotFoundCustomer);

        SellVehicle? sellVehicle = null;
        var payment = await paymentServices.DoPayment(sellVehicleRequest.Payment);
        if (payment.IsFailure)
            return Result.Failure<SellVehicleResponse>(payment.Error);

        sellVehicle = sellVehicleRequest.ToSellVehicle(mapper);
        sellVehicle.PaymentID = payment.Value.Id;
        await appDbContext.SellVehicles.AddAsync(sellVehicle, cancellationToken);

        await appDbContext.Vehicles.Where(x => x.Id == sellVehicle.VehicleID)
            .ExecuteUpdateAsync(setters =>
                setters
                    .SetProperty(x => x.VehicleStatus, VehiclesStatus.sold.ToString()),
                cancellationToken
            );

        var date = DateTime.UtcNow;
        var checkBookingDateRequest = new CheckBookingDateRequest(sellVehicleRequest.VehicleID, date, date.AddYears(1));
        var cancelBooks = await bookingServices.CancelBookingForVehicleInRangeDate(checkBookingDateRequest, cancellationToken);

        await appDbContext.SellVehicles.AddAsync(sellVehicle, cancellationToken);

        await appDbContext.SaveChangesAsync(cancellationToken);
            
        logger.LogInformation("vehicle:(ID:{vehicleID}) is sold", sellVehicleRequest.VehicleID);
        if(sellVehicle is not null)
            return Result.Success(sellVehicle.ToSellVehicleResponse(mapper));
        return Result.Failure<SellVehicleResponse>(GeneralErrors.UnexpectedError("Error In Sell Vehicle"));
    }

}
