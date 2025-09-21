namespace SellingRentingCarsSystem.API.AutoMapping.Profile;

public class AutoMapperPaymentProfile : AutoMapper.Profile
{
    public AutoMapperPaymentProfile()
    {
        //Payment
        PaymentMapping();
        PaymentResponseMapping();
    }

    //Payment
    private void PaymentMapping()
        => CreateMap<PaymentRequest, Payment>().ReverseMap();
    private void PaymentResponseMapping()
        => CreateMap<Payment, PaymentResponse>().ReverseMap();
}
