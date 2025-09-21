namespace SellingRentingCarsSystem.API.AutoMapping.Profile;

public class AutoMapperCustomerProfile : AutoMapper.Profile
{
    public AutoMapperCustomerProfile()
    {
        //Customer
        CustomerMapping();
        CustomerResponseMapping();
    }
    //Customer
    private void CustomerMapping()
        => CreateMap<CustomerRequest, Customer>().ReverseMap();
    private void CustomerResponseMapping()
        => CreateMap<Customer, CustomerResponse>().ReverseMap();
}
