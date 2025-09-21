namespace SellingRentingCarsSystem.API.AutoMapping.Profile;

public class AutoMapperPowerTrainProfile : AutoMapper.Profile
{
    public AutoMapperPowerTrainProfile()
    {
        //PowerTrain
        CombinatinoPowerTrainMapping();
        ElectricPowerTrainMapping();
        HybridPowerTrainMapping();
        PowerTrainResponseMapping();
    }
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
}
