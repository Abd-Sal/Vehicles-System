namespace SellingRentingCarsSystem.API.Abstractions.Consts;

public class DefaultFuelTypes
{
    public static FuelType FuelType_Petrol = new FuelType{
        Id = "0198c34a-8ba0-7089-a560-478e327a78d4",
        TypeName = "Petrol",
    };

    public static FuelType FuelType_Diesel = new FuelType{
        Id = "0198c34a-8ba0-7089-a560-478f770543a1",
        TypeName = "Diesel",
    };

    public static FuelType FuelType_Gas = new FuelType{
        Id = "0198c34a-8ba0-7089-a560-479090f26269",
        TypeName = "Gas",
    };

    public static FuelType[] FuelTypes = [
        FuelType_Petrol,
        FuelType_Diesel,
        FuelType_Gas
    ];
}
