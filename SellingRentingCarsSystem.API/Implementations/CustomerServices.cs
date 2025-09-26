namespace SellingRentingCarsSystem.API.Implementations;

public class CustomerServices(AppDbContext appDbContext, IMapper mapper,
    ILogger<CustomerServices> logger) : ICustomerServices
{
    private readonly AppDbContext appDbContext = appDbContext;
    private readonly IMapper mapper = mapper;


    public async Task<Result<CustomerResponse>> AddCustmomer
        (CustomerRequest customerRequest, CancellationToken cancellationToken = default)
    {
        if (customerRequest is null)
            return Result.Failure<CustomerResponse>(CustomerErrors.NullCustomer);

        if (await appDbContext.Customers.AnyAsync(x => x.NID == customerRequest.NID, cancellationToken))
            return Result.Failure<CustomerResponse>(CustomerErrors.DuplicatedCustomerNID);
        
        if (await appDbContext.Customers.AnyAsync(x => x.PhoneNumber == customerRequest.PhoneNumber, cancellationToken))
            return Result.Failure<CustomerResponse>(CustomerErrors.DuplicatedCustomerPhoneNumber);
        
        if (customerRequest.Email is not null &&
            await appDbContext.Customers.AnyAsync(x => x.Email == customerRequest.Email, cancellationToken))
            return Result.Failure<CustomerResponse>(CustomerErrors.DuplicatedCustomerEmail);

        var customer = customerRequest.ToCustomer(mapper);
        await appDbContext.Customers.AddAsync(customer);
        await appDbContext.SaveChangesAsync(cancellationToken);

        logger.LogInformation("user add new customer:(FullName:{FirstName} {LastName}, NID:{NID})", customer.FirstName, customer.LastName, customer.NID);

        return Result.Success(customer.ToCustomerResponse(mapper));
    }

    public async Task<Result<PaginatedList<FullBookingVehicleResponse>>> CustomerBooks
        (string customerID, RequestFilters filters, CancellationToken cancellationToken = default)
    {
        if (!(await appDbContext.Customers.AnyAsync(x => x.Id == customerID, cancellationToken)))
            return Result.Failure<PaginatedList<FullBookingVehicleResponse>>(CustomerErrors.NotFoundCustomer);

        var query = appDbContext.Bookings.AsNoTracking()
            .Where(x => x.CustomerID == customerID)
            .OrderByDescending(x => x.StartDate)
            .ToFullBookingResponse(mapper);

        var result = await PaginatedList<FullBookingVehicleResponse>.CreateAsync(query, filters.PageNumber, filters.PageSize, cancellationToken);

        return Result.Success(result);
    }

    public async Task<Result<PaginatedList<CustomerResponse>>> GetAllCustmomersAsync
        (RequestFilters filters, CancellationToken cancellationToken = default)
    {
        var query = appDbContext.Customers.AsNoTracking()
            .OrderByDescending(x => x.JoinDate)
            .ProjectTo<CustomerResponse>(mapper.ConfigurationProvider);

        var result = await PaginatedList<CustomerResponse>.CreateAsync(query, filters.PageNumber, filters.PageSize, cancellationToken);

        return Result.Success(result);  
    }

    public async Task<Result<CustomerResponse>> GetCustmomerAsync
        (string customerID, CancellationToken cancellationToken = default)
    {
        if (await appDbContext.Customers.SingleOrDefaultAsync(x => x.Id == customerID, cancellationToken) is not { } customer)
            return Result.Failure<CustomerResponse>(CustomerErrors.NotFoundCustomer);

        return Result.Success(customer.ToCustomerResponse(mapper));
    }

    public async Task<Result<PaginatedList<RentVehicleResponse>>> RentHistoryByCustmomer
        (string customerID, RequestFilters filters, CancellationToken cancellationToken = default)
    {
        if (!(await appDbContext.Customers.AnyAsync(x => x.Id == customerID, cancellationToken)))
            return Result.Failure<PaginatedList<RentVehicleResponse>>(CustomerErrors.NotFoundCustomer);

        var query = appDbContext.RentVehicles.AsNoTracking()
            .Where(x => x.CustomerID == customerID)
            .OrderByDescending(x => x.StartRentDate)
            .ProjectTo<RentVehicleResponse>(mapper.ConfigurationProvider);

        var result = await PaginatedList<RentVehicleResponse>.CreateAsync(query, filters.PageNumber, filters.PageSize, cancellationToken);

        return Result.Success(result);
    }

    public async Task<Result<PaginatedList<CustomerResponse>>> SearchForCustmomers
        (string customerName, RequestFilters filters, CancellationToken cancellationToken = default)
    {
        var query = appDbContext.Customers.AsNoTracking()
            .Where(x => (x.FirstName + " " + x.LastName).Contains(customerName.Trim()))
            .ProjectTo<CustomerResponse>(mapper.ConfigurationProvider);

        var result = await PaginatedList<CustomerResponse>.CreateAsync(query, filters.PageNumber, filters.PageSize, cancellationToken);

        return Result.Success(result);
    }

    public async Task<Result<PaginatedList<SellVehicleResponse>>> SellHistoryByCustmomer
        (string customerID, RequestFilters filters, CancellationToken cancellationToken = default)
    {
        if (!(await appDbContext.Customers.AnyAsync(x => x.Id == customerID, cancellationToken)))
            return Result.Failure<PaginatedList<SellVehicleResponse>>(CustomerErrors.NotFoundCustomer);

        var query = appDbContext.SellVehicles.AsNoTracking()
            .Where(x => x.CustomerID == customerID)
            .ProjectTo<SellVehicleResponse>(mapper.ConfigurationProvider);

        var result = await PaginatedList<SellVehicleResponse>.CreateAsync(query, filters.PageNumber, filters.PageSize, cancellationToken);

        return Result.Success(result);
    }

    public async Task<Result> UpdateCustmomer
        (string customerID, CustomerRequest customerRequest, CancellationToken cancellationToken = default)
    {
        if (customerRequest is null)
            return Result.Failure(CustomerErrors.NullCustomer);

        if (await appDbContext.Customers.FindAsync(customerID, cancellationToken) is not { } customer)
            return Result.Failure(CustomerErrors.NotFoundCustomer);

        if (await appDbContext.Customers.AnyAsync(x => x.Id != customerID && x.NID == customerRequest.NID, cancellationToken))
            return Result.Failure(CustomerErrors.DuplicatedCustomerNID);

        if (await appDbContext.Customers.AnyAsync(x => x.Id != customerID && x.PhoneNumber == customerRequest.PhoneNumber, cancellationToken))
            return Result.Failure(CustomerErrors.DuplicatedCustomerPhoneNumber);

        if (customerRequest.Email is not null && 
            await appDbContext.Customers.AnyAsync(x => x.Id != customerID && x.Email == customerRequest.Email, cancellationToken))
            return Result.Failure(CustomerErrors.DuplicatedCustomerEmail);


        await appDbContext.Customers.Where(x => x.Id == customerID)
            .ExecuteUpdateAsync(setters =>
                setters
                    .SetProperty(x => x.FirstName, customerRequest.FirstName)
                    .SetProperty(x => x.LastName, customerRequest.LastName)
                    .SetProperty(x => x.Address, customerRequest.Address)
                    .SetProperty(x => x.NID, customerRequest.NID)
                    .SetProperty(x => x.PhoneNumber, customerRequest.PhoneNumber)
                    .SetProperty(x => x.Email, customerRequest.Email)
                    .SetProperty(x => x.BirthDate, customerRequest.BirthDate),
                cancellationToken
            );

        logger.LogInformation("user update customer:(FullName:{fullname}, NID:{nid})", $"{customer.FirstName} {customer.LastName}", customer.NID);

        return Result.Success(customer.ToCustomerResponse(mapper));
    }

}
