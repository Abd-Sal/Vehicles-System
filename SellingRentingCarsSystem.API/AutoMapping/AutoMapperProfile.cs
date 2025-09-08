namespace SellingRentingCarsSystem.API.AutoMapping;

public class AutoMapperProfile : AutoMapper.Profile
{
    public AutoMapperProfile()
    {
        //BodyType
        BodyTypeMapping();
        BodyTypeMappingResponse();

        //PowerTrain
        CombinatinoPowerTrainMapping();
        ElectricPowerTrainMapping();
        HybridPowerTrainMapping();
        PowerTrainResponseMapping();

        //Feature
        FeatureMapping();
        FeatureResponseMapping();

        //FuelType
        FuelTypeMapping();
        FuelTypeResponseMapping();

        //Make
        MakeMapping();
        MakeResponseMapping();

        //Model
        ModelMapping();
        ModelResponseMapping();

        //TransmissionType
        TransmissionTypeMapping();
        TransmissionTypeResponseMapping();

        //VehicleFeature
        VehicleFeatureMapping();
        VehicleFeatureResponseMapping();

        //Vehicle
        VehicleMapping();
        VehicleResponseMapping();

        //Maintenance
        MaintenanceMapping();
        MaintenanceResponseMapping();

        //Payment
        PaymentMapping();
        PaymentResponseMapping();

        //RentVehicle
        RentMapping();
        StopRentMapping();
        RentResponseMap();

        //Tag
        TagResponseMapping();

        //Booking
        BookingMapping();
        BookingResponseMapping();

        //Customer
        CustomerMapping();
        CustomerResponseMapping();

        //SellVehicle
        SellVehicleMapping();
        SellVehicleResponseMapping();

        //Image
        ImageMapping();
        ImageResponseMapping();

        //FuelDelivery
        FuelDeliveryMapping();
        FuelDeliveryResponseMapping();

        //Aspiration
        AspirationMapping();
        AspirationResponseMapping();

        //ChargePort
        ChargePortMapping();
        ChargePortResponseMapping();
    }

    //BodyType
    private void BodyTypeMapping()
        => CreateMap<BodyTypeRequest, BodyType>()
        .ForMember(dest => dest.TypeName, opt => opt.MapFrom(src => src.BodyTypeName))
        .ReverseMap()
        .ForMember(dest => dest.BodyTypeName, opt => opt.MapFrom(src => src.TypeName));
    private void BodyTypeMappingResponse()
        => CreateMap<BodyType, BodyTypeResponse>().ReverseMap();

    //PowerTrain
    private void CombinatinoPowerTrainMapping()
        => CreateMap<CombinationPowerTrainRequest, PowerTrain>().ReverseMap()
        .ForMember(dest => dest.CombinedRangeMiles, opt => opt.MapFrom(src => src.CombinedRangeMiles))
        .ForMember(dest => dest.FuelTypeID, opt => opt.MapFrom(src => src.FuelTypeID));
    private void ElectricPowerTrainMapping()
        => CreateMap<ElectricPowerTrainRequest, PowerTrain>().ReverseMap();
    private void HybridPowerTrainMapping()
        => CreateMap<HybridPowerTrainRequest, PowerTrain>();
    private void PowerTrainResponseMapping()
        => CreateMap<PowerTrainResponse, PowerTrain>().ReverseMap()
        .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
        .ForMember(dest => dest.PowerTrainType, opt => opt.MapFrom(src => src.PowerTrainType))
        .ForMember(dest => dest.HorsePower, opt => opt.MapFrom(src => src.HorsePower))
        .ForMember(dest => dest.Torque, opt => opt.MapFrom(src => src.Torque))
        .ForMember(dest => dest.CombinedRangeMiles, opt => 
        {
            opt.Condition(src => src.CombinedRangeMiles != null);
            opt.MapFrom(src => src.CombinedRangeMiles);    
        })
        .ForMember(dest => dest.ElectricOnlyRangeMiles, opt =>
        {
            opt.Condition(src => src.ElectricOnlyRangeMiles != null);
            opt.MapFrom(src => src.ElectricOnlyRangeMiles);
        })
        .ForMember(dest => dest.ChargePortID, opt =>
        {
            opt.Condition(src => src.ChargePort != null);
            opt.MapFrom(src => src.ChargePortID);
        })
        .ForMember(dest => dest.BatteryCapacityKWh, opt =>
        {
            opt.Condition(src => src.BatteryCapacityKWh != null);
            opt.MapFrom(src => src.BatteryCapacityKWh);
        })
        .ForMember(dest => dest.FuelDeliveryID, opt =>
        {
            opt.Condition(src => src.FuelDeliveryID != null);
            opt.MapFrom(src => src.FuelDeliveryID);
        })
        .ForMember(dest => dest.FuelTypeID, opt =>
        {
            opt.Condition(src => src.FuelTypeID != null);
            opt.MapFrom(src => src.FuelTypeID);
        })
        .ForMember(dest => dest.AspirationID, opt =>
        {
            opt.Condition(src => src.AspirationID != null);
            opt.MapFrom(src => src.AspirationID);
        })
        .ForMember(dest => dest.EngineSize, opt =>
        {
            opt.Condition(src => src.EngineSize != null);
            opt.MapFrom(src => src.EngineSize);
        })
        .ForMember(dest => dest.Cylinders, opt =>
        {
            opt.Condition(src => src.Cylinders != null);
            opt.MapFrom(src => src.Cylinders);
        });


    //Feature
    private void FeatureMapping()
        => CreateMap<FeatureRequest, Feature>().ReverseMap();
    private void FeatureResponseMapping()
        => CreateMap<Feature, FeatureResponse>().ReverseMap();

    //FuelType
    private void FuelTypeMapping()
        => CreateMap<FuelTypeRequest, FuelType>()
        .ForMember(dest => dest.TypeName, opt => opt.MapFrom(src => src.FuelTypeName));
    private void FuelTypeResponseMapping()
        => CreateMap<FuelType, FuelTypeResponse>();

    //Make
    private void MakeMapping()
        => CreateMap<MakeRequest, Make>().ReverseMap();
    private void MakeResponseMapping()
        => CreateMap<Make, MakeResponse>().ReverseMap();

    //Model
    private void ModelMapping()
        => CreateMap<ModelRequest, Model>().ReverseMap();
    private void ModelResponseMapping()
        => CreateMap<Model, ModelResponse>().ReverseMap();

    //TransmissionType
    private void TransmissionTypeMapping()
        => CreateMap<TransmissionTypeRequest, TransmissionType>().ReverseMap();
    private void TransmissionTypeResponseMapping()
        => CreateMap<TransmissionType, TransmissionTypeResponse>().ReverseMap();

    //VehicleFeature
    private void VehicleFeatureMapping()
        => CreateMap<VehicleFeatureRequest, VehicleFeature>().ReverseMap();
    private void VehicleFeatureResponseMapping()
        => CreateMap<VehicleFeature, VehicleFeatureResponse>().ReverseMap();

    //Vehicle
    private void VehicleMapping()
        => CreateMap<VehicleRequest, Vehicle>().ReverseMap();
    private void VehicleResponseMapping()
        => CreateMap<Vehicle, BriefVehicleResponse>().ReverseMap();

    //Maintenance
    private void MaintenanceMapping()
        => CreateMap<MaintenanceRequest, Maintenance>().ReverseMap();
    private void MaintenanceResponseMapping()
        => CreateMap<Maintenance,  MaintenanceResponse>().ReverseMap();

    //Payment
    private void PaymentMapping()
        => CreateMap<PaymentRequest, Payment>().ReverseMap();
    private void PaymentResponseMapping()
        => CreateMap<Payment, PaymentResponse>().ReverseMap();

    //RentVehicle
    private void RentMapping()
        => CreateMap<RentVehicleRequest, RentVehicle>().ReverseMap();
    private void StopRentMapping()
        => CreateMap<StopRentVehicleRequest, RentVehicle>().ReverseMap();
    private void RentResponseMap()
        => CreateMap<RentVehicle, RentVehicleResponse>()
            .ForMember(dest => dest.EndAtMile, opt => opt.MapFrom(src => src.EndAtMile ?? 0))
            .ForMember(dest => dest.ActualEndRentDate, opt => opt.MapFrom(src => src.ActualEndRentDate ?? DateTime.MinValue))
            .ForMember(dest => dest.Amount, opt => opt.MapFrom(src => src.Amount ?? 0))
            .ReverseMap();

    //Tag
    private void TagResponseMapping()
        => CreateMap<Tag, TagResponse>().ReverseMap();

    //Booking
    private void BookingMapping()
        => CreateMap<BookingVehicleRequest, Booking>().ReverseMap();
    private void BookingResponseMapping()
        => CreateMap<Booking, BookingVehicleResponse>().ReverseMap();

    //Customer
    private void CustomerMapping()
        => CreateMap<CustomerRequest, Customer>().ReverseMap();
    private void CustomerResponseMapping()
        => CreateMap<Customer, CustomerResponse>().ReverseMap();

    //SellVehicle
    private void SellVehicleMapping()
        => CreateMap<SellVehicleRequest, SellVehicle>().ReverseMap();
    private void SellVehicleResponseMapping()
        => CreateMap<SellVehicle, SellVehicleResponse>().ReverseMap();

    //Image
    private void ImageMapping()
        => CreateMap<ImageRequest, Image>()
           .ForMember(dest => dest.SizeInBytes, opt => opt.MapFrom(src => src.Image.Length))
            .ReverseMap();
    private void ImageResponseMapping()
        => CreateMap<Image, ImageResponse>().ReverseMap();


    //FuelDelivery
    private void FuelDeliveryMapping()
        => CreateMap<FuelDeliveryRequest, FuelDelivery>();
    private void FuelDeliveryResponseMapping()
        => CreateMap<FuelDelivery, FuelDeliveryResponse>();


    //Aspiration
    private void AspirationMapping()
        => CreateMap<AspirationRequest, Aspiration>();
    private void AspirationResponseMapping()
        => CreateMap<Aspiration, AspirationResponse>();


    //ChargePort
    private void ChargePortMapping()
        => CreateMap<ChargePortRequest, ChargePort>();
    private void ChargePortResponseMapping()
        => CreateMap<ChargePort, ChargePortResponse>();

}

