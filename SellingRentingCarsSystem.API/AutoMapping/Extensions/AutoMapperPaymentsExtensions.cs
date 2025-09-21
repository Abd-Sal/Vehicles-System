namespace SellingRentingCarsSystem.API.AutoMapping.Extensions;

public static class AutoMapperPaymentsExtensions
{
    //Payment
    public static Payment ToPayment(this PaymentRequest paymentRequest, IMapper mapper)
        => mapper.Map<Payment>(paymentRequest);
    public static PaymentResponse ToPaymentResponse(this Payment payment, IMapper mapper)
        => mapper.Map<PaymentResponse>(payment);
    public static List<PaymentResponse> ToPaymentResponses(this IEnumerable<Payment> payments, IMapper mapper)
        => mapper.Map<List<PaymentResponse>>(payments);

}
