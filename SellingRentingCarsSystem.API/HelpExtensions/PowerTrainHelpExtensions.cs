namespace SellingRentingCarsSystem.API.HelpExtensions;

public static class PowerTrainHelpExtensions
{
    public static string HashCode(this CombinationPowerTrainRequest powerTrain)
        => $"{powerTrain.HorsePower}-{powerTrain.EngineSize}-{powerTrain.CombinedRangeMiles}-" +
           $"{powerTrain.Torque}-{powerTrain.Cylinders}-{powerTrain.AspirationID}-" +
           $"{powerTrain.FuelTypeID}-{powerTrain.FuelDeliveryID}-{powerTrain.TransmissionTypeID}";
    public static string HashCode(this UpdateCombinationPowerTrainRequest powerTrain)
        => $"{powerTrain.HorsePower}-{powerTrain.EngineSize}-{powerTrain.CombinedRangeMiles}-" +
           $"{powerTrain.Torque}-{powerTrain.Cylinders}-{powerTrain.AspirationID}-" +
           $"{powerTrain.FuelTypeID}-{powerTrain.FuelDeliveryID}-{powerTrain.TransmissionTypeID}";
    
    public static string HashCode(this ElectricPowerTrainRequest powerTrain)
        => $"{powerTrain.HorsePower}-{powerTrain.ChargePortID}-{powerTrain.Torque}-" +
           $"{powerTrain.BatteryCapacityKWh}-{powerTrain.ElectricOnlyRangeMiles}";
    public static string HashCode(this UpdateElectricPowerTrainRequest powerTrain)
        => $"{powerTrain.HorsePower}-{powerTrain.ChargePortID}-{powerTrain.Torque}-" +
           $"{powerTrain.BatteryCapacityKWh}-{powerTrain.ElectricOnlyRangeMiles}";
    
    public static string HashCode(this HybridPowerTrainRequest powerTrain)
        => $"{powerTrain.HorsePower}-{powerTrain.ChargePortID}-{powerTrain.Torque}-" +
           $"{powerTrain.BatteryCapacityKWh}-{powerTrain.ElectricOnlyRangeMiles}-" +
           $"{powerTrain.FuelTypeID}-{powerTrain.FuelDeliveryID}-{powerTrain.CombinedRangeMiles}-" +
           $"{powerTrain.Cylinders}-{powerTrain.AspirationID}-{powerTrain.TransmissionTypeID}-" +
           $"{powerTrain.EngineSize}-{powerTrain.PlugInHybrid}";

    public static string HashCode(this UpdateHybridPowerTrainRequest powerTrain)
        => $"{powerTrain.HorsePower}-{powerTrain.ChargePortID}-{powerTrain.Torque}-" +
           $"{powerTrain.BatteryCapacityKWh}-{powerTrain.ElectricOnlyRangeMiles}-" +
           $"{powerTrain.FuelTypeID}-{powerTrain.FuelDeliveryID}-{powerTrain.CombinationRangeMiles}-" +
           $"{powerTrain.Cylinders}-{powerTrain.AspirationID}-{powerTrain.TransmissionTypeID}-" +
           $"{powerTrain.EngineSize}-{powerTrain.PlugInHybrid}";

}
