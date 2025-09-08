namespace SellingRentingCarsSystem.API.Abstractions.Consts;

public class DefaultBodyTypes
{
    public static BodyType BodyType_Convertible_2 = new BodyType
    {
        Id = "0198c34a-8ba0-7089-a560-47916546c9a9",
        TypeName = "Convertible",
        DoorCount = 2
    };

    public static BodyType BodyType_Convertible_4 = new BodyType
    {
        Id = "0198c34a-8ba0-7089-a560-479224bb6185",
        TypeName = "Convertible",
        DoorCount = 4
    };

    public static BodyType BodyType_Coupe = new BodyType
    {
        Id = "0198c34a-8ba0-7089-a560-47938977ae7c",
        TypeName = "Coupe",
        DoorCount = 2
    };

    public static BodyType BodyType_Crossover = new BodyType
    {
        Id = "0198c34a-8ba0-7089-a560-479495a61551",
        TypeName = "Crossover",
        DoorCount = 4
    };

    public static BodyType BodyType_Hatchback_2 = new BodyType
    {
        Id = "0198c34a-8ba0-7089-a560-4795267320fb",
        TypeName = "Hatchback",
        DoorCount = 2
    };

    public static BodyType BodyType_Hatchback_4 = new BodyType
    {
        Id = "0198c34a-8ba0-7089-a560-4796ba3aa031",
        TypeName = "Hatchback",
        DoorCount = 4
    };
    
    public static BodyType BodyType_Minivan_3 = new BodyType
    {
        Id = "0198c34a-8ba0-7089-a560-479737348d88",
        TypeName = "Minivan",
        DoorCount = 3
    };

    public static BodyType BodyType_Minivan_4 = new BodyType
    {
        Id = "0198c34a-8ba0-7089-a560-4798ee6d43e4",
        TypeName = "Minivan",
        DoorCount = 4
    };

    public static BodyType BodyType_Pickup_Truck_2 = new BodyType
    {
        Id = "0198c34a-8ba0-7089-a560-4799f3cd22ef",
        TypeName = "Pickup Truck",
        DoorCount = 2
    };

    public static BodyType BodyType_Pickup_Truck_4 = new BodyType
    {
        Id = "0198c34a-8ba0-7089-a560-479ae1fe64af",
        TypeName = "Pickup Truck",
        DoorCount = 4
    };

    public static BodyType BodyType_Sedan = new BodyType
    {
        Id = "0198c34a-8ba0-7089-a560-479ba551f176",
        TypeName = "Sedan",
        DoorCount = 4
    };

    public static BodyType BodyType_SUV = new BodyType
    {
        Id = "0198c34a-8ba0-7089-a560-479cc5b9e724",
        TypeName = "SUV",
        DoorCount = 4
    };

    public static BodyType BodyType_Wagon = new BodyType
    {
        Id = "0198c34a-8ba0-7089-a560-479df0e1384b",
        TypeName = "Wagon",
        DoorCount = 4
    };

    public static BodyType[] BodyTypes = [
        BodyType_Convertible_2,
        BodyType_Convertible_4,
        BodyType_Coupe,
        BodyType_Crossover,
        BodyType_Wagon,
        BodyType_Hatchback_2,
        BodyType_Hatchback_4,
        BodyType_Minivan_3,
        BodyType_Minivan_4,
        BodyType_Pickup_Truck_2,
        BodyType_Pickup_Truck_4,
        BodyType_Sedan,
        BodyType_SUV
    ];

}
