namespace SellingRentingCarsSystem.API.AutoMapping.Extensions;

public static class AutoMapperCustomerExtensions
{
    //Customer
    public static Customer ToCustomer(this CustomerRequest customerRequest, IMapper mapper)
    => mapper.Map<Customer>(customerRequest);
    public static CustomerResponse ToCustomerResponse(this Customer customer, IMapper mapper)
        => mapper.Map<CustomerResponse>(customer);
    public static List<CustomerResponse> ToCustomerResponses(this IEnumerable<Customer> customers, IMapper mapper)
        => mapper.Map<List<CustomerResponse>>(customers);
    public static IQueryable<CustomerResponse> ToCustomerResponses(this IQueryable<Customer> customers, IMapper mapper, bool flag)
        => mapper.Map<IQueryable<CustomerResponse>>(customers);

}
