namespace SellingRentingCarsSystem.API.AutoMapping.Profile;

public class AutoMapperTransmissionTypeProfile : AutoMapper.Profile
{
    public AutoMapperTransmissionTypeProfile()
    {
        //TransmissionType
        TransmissionTypeMapping();
        TransmissionTypeResponseMapping();
    }
    //TransmissionType
    private void TransmissionTypeMapping()
        => CreateMap<TransmissionTypeRequest, TransmissionType>().ReverseMap();
    private void TransmissionTypeResponseMapping()
        => CreateMap<TransmissionType, TransmissionTypeResponse>().ReverseMap();
}
