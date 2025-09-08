namespace SellingRentingCarsSystem.API.Abstractions.Consts;

public class DefaultFuelDeliveries
{
    public  static FuelDelivery FuelDelivery_Carburetor = new FuelDelivery
    {
        Id = "0198c34a-8ba0-7089-a560-47a4b56add0f",
        TypeName = "Carburetor"
    };

    public static FuelDelivery FuelDelivery_Direct_Injection = new FuelDelivery
    {
        Id = "0198c34a-8ba0-7089-a560-47a5de2fab4e",
        TypeName = "Direct Injection"
    };

    public static FuelDelivery FuelDelivery_EFI = new FuelDelivery
    {
        Id = "0198c34a-8ba0-7089-a560-47a66e3bc0e9",
        TypeName = "EFI (Electronic Fuel Injection)"
    };

    public static FuelDelivery FuelDelivery_Multi_Point_Fuel_Injection = new FuelDelivery
    {
        Id = "0198c34a-8ba0-7089-a560-47a76a7833ff",
        TypeName = "Multi Point Fuel Injection"
    };

    public static FuelDelivery FuelDelivery_Sequential_Fuel_Injection = new FuelDelivery
    {
        Id = "0198c34a-8ba0-7089-a560-47a8923e476f",
        TypeName = "Sequential Fuel Injection"
    };

    public static FuelDelivery FuelDelivery_Single_Point_Fuel_Injection = new FuelDelivery
    {
        Id = "0198c34a-8ba0-7089-a560-47a9e03b9c8d",
        TypeName = "Single Point Fuel Injection"
    };

    public static FuelDelivery[] FuelDeliveries = [
        FuelDelivery_Single_Point_Fuel_Injection,
        FuelDelivery_Sequential_Fuel_Injection,
        FuelDelivery_Multi_Point_Fuel_Injection,
        FuelDelivery_EFI,
        FuelDelivery_Direct_Injection,
        FuelDelivery_Carburetor
    ];
}
