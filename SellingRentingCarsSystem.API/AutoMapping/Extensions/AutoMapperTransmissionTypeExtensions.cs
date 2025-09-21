namespace SellingRentingCarsSystem.API.AutoMapping.Extensions;

public static class AutoMapperTransmissionTypeExtensions
{
    //TransmissionType
    public static TransmissionType ToTransmissionType(this TransmissionTypeRequest transmissionTypeRequest, IMapper mapper)
        => mapper.Map<TransmissionType>(transmissionTypeRequest);
    public static TransmissionTypeResponse ToTransmissionTypeResponse(this TransmissionType transmissionType, IMapper mapper)
        => mapper.Map<TransmissionTypeResponse>(transmissionType);
    public static List<TransmissionTypeResponse> ToTransmissionTypeResponses(this IEnumerable<TransmissionType> transmissionTypes, IMapper mapper)
        => mapper.Map<List<TransmissionTypeResponse>>(transmissionTypes);

}
