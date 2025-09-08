namespace SellingRentingCarsSystem.API.Abstractions.Consts;

public class DefaultTransmissionTypes
{
    public static TransmissionType TransmissionType_Manual_Transmission = new TransmissionType
    {
        Id = "0198c363-eb2b-7b9d-9d0f-eb336e0cb29f",
        TypeName = "Manual Transmission"
    };

    public static TransmissionType TransmissionType_Automatic_Transmission = new TransmissionType
    {
        Id = "0198c363-eb2b-7b9d-9d0f-eb34e43edba2",
        TypeName = "Automatic Transmission"
    };


    public static TransmissionType TransmissionType_CVT = new TransmissionType
    {
        Id = "0198c363-eb2b-7b9d-9d0f-eb35b235b53b",
        TypeName = "Continuously Variable Transmission (CVT)"
    };

    public static TransmissionType TransmissionType_Automated_Manual_Transmission = new TransmissionType
    {
        Id = "0198c363-eb2b-7b9d-9d0f-eb36db29defb",
        TypeName = "Automated Manual Transmission"
    };

    public static TransmissionType TransmissionType_Intelligent_Manual_Transmission = new TransmissionType
    {
        Id = "0198c363-eb2b-7b9d-9d0f-eb375f841792",
        TypeName = "Intelligent Manual Transmission (iMS)"
    };

    public static TransmissionType TransmissionType_Sequential_Manual_Transmission = new TransmissionType
    {
        Id = "0198c363-eb2b-7b9d-9d0f-eb3818a1c58e",
        TypeName = "Sequential Manual Transmission (SMT)"
    };

    public static TransmissionType[] TransmissionTypes = [
        TransmissionType_Sequential_Manual_Transmission,
        TransmissionType_Intelligent_Manual_Transmission,
        TransmissionType_Automated_Manual_Transmission,
        TransmissionType_CVT,
        TransmissionType_Automatic_Transmission,
        TransmissionType_Manual_Transmission
    ];

}
