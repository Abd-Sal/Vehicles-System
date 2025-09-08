namespace SellingRentingCarsSystem.API.Abstractions.Consts;

public class DefaultFeatures
{
    //Performance & Drivetrain
    public static Feature Feature_AWD = new Feature
    {
        Id = "0198c37d-3f7a-794d-907c-0600cbd16aa9",
        FeatureName = "All-Wheel Drive (AWD)",
        Category = "Performance & Drivetrain"
    };

    public static Feature Feature_Four_Wheel_Drive = new Feature
    {
        Id = "0198c37d-3f7a-794d-907c-060112f409e1",
        FeatureName = "Four-Wheel Drive (4WD)",
        Category = "Performance & Drivetrain"
    };

    public static Feature Feature_Front_Wheel_Drive = new Feature
    {
        Id = "0198c37d-3f7a-794d-907c-0602419f4278",
        FeatureName = "Front-Wheel Drive (FWD)",
        Category = "Performance & Drivetrain"
    };

    public static Feature Feature_Rear_Wheel_Drive = new Feature
    {
        Id = "0198c37d-3f7a-794d-907c-0603bdb0daae",
        FeatureName = "Rear-Wheel Drive (RWD)",
        Category = "Performance & Drivetrain"
    };

    public static Feature Feature_Turbocharged_Engine = new Feature
    {
        Id = "0198c37d-3f7a-794d-907c-0606abe14a04",
        FeatureName = "Turbocharged Engine",
        Category = "Performance & Drivetrain"
    };

    public static Feature Feature_Paddle_Shifters = new Feature
    {
        Id = "0198c37d-3f7a-794d-907c-06076d236f30",
        FeatureName = "Paddle Shifters",
        Category = "Performance & Drivetrain"
    };

    public static Feature Feature_Sport_Mode = new Feature
    {
        Id = "0198c37d-3f7a-794d-907c-0608192c9e37",
        FeatureName = "Sport Mode",
        Category = "Performance & Drivetrain"
    };

    public static Feature Feature_Hybrid_Engine = new Feature
    {
        Id = "0198c37d-3f7a-794d-907c-06092e931a95",
        FeatureName = "Hybrid Engine",
        Category = "Performance & Drivetrain"
    };
    
    public static Feature Feature_Electric_Vehicle = new Feature
    {
        Id = "0198c37d-3f7a-794d-907c-060a9c6c314a",
        FeatureName = "Electric Vehicle (EV)",
        Category = "Performance & Drivetrain"
    };
    
    public static Feature Feature_Plug_in_Hybrid = new Feature
    {
        Id = "0198c37d-3f7a-794d-907c-060be490422a",
        FeatureName = "Plug-in Hybrid (PHEV)",
        Category = "Performance & Drivetrain"
    };
    
    public static Feature Feature_Adaptive_Suspension = new Feature
    {
        Id = "0198c37d-3f7a-794d-907c-060c687bbb70",
        FeatureName = "Adaptive Suspension",
        Category = "Performance & Drivetrain"
    };

    public static Feature[] FeaturesPerformanceDrivetrain = [
        Feature_Adaptive_Suspension,
        Feature_Plug_in_Hybrid,
        Feature_Electric_Vehicle,
        Feature_Hybrid_Engine,
        Feature_Sport_Mode,
        Feature_Paddle_Shifters,
        Feature_Turbocharged_Engine,
        Feature_Rear_Wheel_Drive,
        Feature_Front_Wheel_Drive,
        Feature_AWD,
        Feature_Four_Wheel_Drive
    ];

    //Exterior Features
    public static Feature Feature_Sunroof_Moonroof = new Feature
    {
        Id = "0198c37d-3f7a-794d-907c-060d0213d065",
        FeatureName = "Sunroof / Moonroof",
        Category = "Exterior Features"
    };

    public static Feature Feature_Panoramic_Roof = new Feature
    {
        Id = "0198c37d-3f7a-794d-907c-060eac154948",
        FeatureName = "Panoramic Roof",
        Category = "Exterior Features"
    };

    public static Feature Feature_Roof_Rack = new Feature
    {
        Id = "0198c37d-3f7a-794d-907c-060f479a835d",
        FeatureName = "Roof Rack",
        Category = "Exterior Features"
    };

    public static Feature Feature_Running_Boards_Side_Steps = new Feature
    {
        Id = "0198c37d-3f7a-794d-907c-0610ae354f6e",
        FeatureName = "Running Boards / Side Steps",
        Category = "Exterior Features"
    };

    public static Feature Feature_Tow_Hitch = new Feature
    {
        Id = "0198c37d-3f7a-794d-907c-0611314b61ba",
        FeatureName = "Tow Hitch",
        Category = "Exterior Features"
    };

    public static Feature Feature_Alloy_Wheels = new Feature
    {
        Id = "0198c37d-3f7a-794d-907c-061210e66588",
        FeatureName = "Alloy Wheels",
        Category = "Exterior Features"
    };

    public static Feature Feature_Premium_Wheels = new Feature
    {
        Id = "0198c3aa-45cb-7105-b8d4-7a377a7f7e54",
        FeatureName = "Premium Wheels",
        Category = "Exterior Features"
    };

    public static Feature Feature_Fog_Lights = new Feature
    {
        Id = "0198c3aa-45cb-7105-b8d4-7a38e767a25f",
        FeatureName = "Fog Lights",
        Category = "Exterior Features"
    };

    public static Feature Feature_LED_Headlights = new Feature
    {
        Id = "0198c3aa-45cb-7105-b8d4-7a391bccb1e7",
        FeatureName = "LED Headlights",
        Category = "Exterior Features"
    };

    public static Feature Feature_Automatic_Headlights = new Feature
    {
        Id = "0198c3aa-45cb-7105-b8d4-7a3a24fe9317",
        FeatureName = "Automatic Headlights",
        Category = "Exterior Features"
    };

    public static Feature Feature_Heated_Side_Mirrors = new Feature
    {
        Id = "0198c3aa-45cb-7105-b8d4-7a3bad4a44b8",
        FeatureName = "Heated Side Mirrors",
        Category = "Exterior Features"
    };

    public static Feature Feature_Power_Tailgate_Liftgate = new Feature
    {
        Id = "0198c3aa-45cb-7105-b8d4-7a3c9a38c7ca",
        FeatureName = "Power Tailgate / Liftgate",
        Category = "Exterior Features"
    };

    public static Feature[] FeaturesExteriorFeatures = [
        Feature_Power_Tailgate_Liftgate,
        Feature_Heated_Side_Mirrors,
        Feature_Automatic_Headlights,
        Feature_LED_Headlights,
        Feature_Fog_Lights,
        Feature_Premium_Wheels,
        Feature_Alloy_Wheels,
        Feature_Tow_Hitch,
        Feature_Running_Boards_Side_Steps,
        Feature_Roof_Rack,
        Feature_Panoramic_Roof,
        Feature_Sunroof_Moonroof
    ];

    //Interior & Comfort
    public static Feature Feature_Leather_Seats = new Feature
    {
        Id = "0198c3aa-45cb-7105-b8d4-7a3d009a1e3b",
        FeatureName = "Leather Seats",
        Category = "Interior & Comfort"
    };

    public static Feature Feature_Heated_Seats = new Feature
    {
        Id = "0198c3aa-45cb-7105-b8d4-7a3efbeea60f",
        FeatureName = "Heated Seats",
        Category = "Interior & Comfort"
    };

    public static Feature Feature_Ventilated__Cooled__Seats = new Feature
    {
        Id = "0198c3aa-45cc-712f-b1b0-da8160602b1b",
        FeatureName = "Ventilated (Cooled) Seats",
        Category = "Interior & Comfort"
    };

    public static Feature Feature_Massaging_Seats = new Feature
    {
        Id = "0198c3aa-45cc-712f-b1b0-da827fa92c10",
        FeatureName = "Massaging Seats",
        Category = "Interior & Comfort"
    };

    public static Feature Feature_Power_Adjustable_Seats = new Feature
    {
        Id = "0198c3aa-45cc-712f-b1b0-da83d1d7b381",
        FeatureName = "Power Adjustable Seats",
        Category = "Interior & Comfort"
    };

    public static Feature Feature_Memory_Seats = new Feature
    {
        Id = "0198c3aa-45cc-712f-b1b0-da846d833585",
        FeatureName = "Memory Seats ( remembers position for multiple drivers)",
        Category = "Interior & Comfort"
    };

    public static Feature Feature_Wood_Alloy_Interior_Trim = new Feature
    {
        Id = "0198c3aa-45cc-712f-b1b0-da85da2a2899",
        FeatureName = "Wood/Alloy Interior Trim",
        Category = "Interior & Comfort"
    };

    public static Feature Feature_Panoramic_Glass_Roof = new Feature
    {
        Id = "0198c3aa-45cc-712f-b1b0-da86bf2fd67a",
        FeatureName = "Panoramic Glass Roof",
        Category = "Interior & Comfort"
    };

    public static Feature Feature_Heads_Up_Display = new Feature
    {
        Id = "0198c3aa-45cc-712f-b1b0-da87bb6e7f76",
        FeatureName = "Heads-Up Display (HUD)",
        Category = "Interior & Comfort"
    };

    public static Feature Feature_Keyless_Entry = new Feature
    {
        Id = "0198c3aa-45cc-712f-b1b0-da882ca8857b",
        FeatureName = "Keyless Entry",
        Category = "Interior & Comfort"
    };

    public static Feature Feature_Push_Button_Start = new Feature
    {
        Id = "0198c3aa-45cc-712f-b1b0-da8966841e38",
        FeatureName = "Push Button Start",
        Category = "Interior & Comfort"
    };

    public static Feature Feature_Ambient_Interior_Lighting = new Feature
    {
        Id = "0198c3aa-45cc-712f-b1b0-da8a78158876",
        FeatureName = "Ambient Interior Lighting",
        Category = "Interior & Comfort"
    };

    public static Feature Feature_Dual_Zone_Climate_Control = new Feature
    {
        Id = "0198c3aa-45cc-712f-b1b0-da8b0551855f",
        FeatureName = "Dual-Zone Climate Control",
        Category = "Interior & Comfort"
    };

    public static Feature Feature_Triple_Zone_Climate_Control = new Feature
    {
        Id = "0198c3aa-45cc-712f-b1b0-da8cfb6d753d",
        FeatureName = "Triple-Zone Climate Control",
        Category = "Interior & Comfort"
    };

    public static Feature[] FeaturesInteriorComfort = [
        Feature_Triple_Zone_Climate_Control,
        Feature_Dual_Zone_Climate_Control,
        Feature_Ambient_Interior_Lighting,
        Feature_Push_Button_Start,
        Feature_Keyless_Entry,
        Feature_Heads_Up_Display,
        Feature_Panoramic_Glass_Roof,
        Feature_Wood_Alloy_Interior_Trim,
        Feature_Memory_Seats,
        Feature_Power_Adjustable_Seats,
        Feature_Massaging_Seats,
        Feature_Ventilated__Cooled__Seats,
        Feature_Leather_Seats,
        Feature_Heated_Seats
    ];
    
    //Infotainment & Technology
    public static Feature Feature_Bluetooth_Connectivity = new Feature
    {
        Id = "0198c3aa-45cc-712f-b1b0-da8db366cb87",
        FeatureName = "Bluetooth Connectivity",
        Category = "Infotainment & Technology"
    };

    public static Feature Feature_Apple_CarPlay = new Feature
    {
        Id = "0198c3aa-45cc-712f-b1b0-da8e1322aecf",
        FeatureName = "Apple CarPlay",
        Category = "Infotainment & Technology"
    };

    public static Feature Feature_Android_Auto = new Feature
    {
        Id = "0198c3aa-45cc-712f-b1b0-da8fc8fa85cb",
        FeatureName = "Android Auto",
        Category = "Infotainment & Technology"
    };

    public static Feature Feature_Navigation_System = new Feature
    {
        Id = "0198c3aa-45cc-712f-b1b0-da900ee6bc93",
        FeatureName = "Navigation System",
        Category = "Infotainment & Technology"
    };

    public static Feature Feature_Premium_Sound_System = new Feature
    {
        Id = "0198c3aa-45cc-712f-b1b0-da91590c6685",
        FeatureName = "Premium Sound System (e.g., Bose, Harman Kardon)",
        Category = "Infotainment & Technology"
    };

    public static Feature Feature_Upgraded_Sound_System = new Feature
    {
        Id = "0198c3aa-45cc-712f-b1b0-da923058318c",
        FeatureName = "Upgraded Sound System (e.g., \"Premium\" tier)",
        Category = "Infotainment & Technology"
    };

    public static Feature Feature_Satellite_Radio = new Feature
    {
        Id = "0198c3aa-45cc-712f-b1b0-da93bdb3f109",
        FeatureName = "Satellite Radio (e.g., SiriusXM)",
        Category = "Infotainment & Technology"
    };

    public static Feature Feature_HD_Radio = new Feature
    {
        Id = "0198c3aa-45cc-712f-b1b0-da948b0ca775",
        FeatureName = "HD Radio",
        Category = "Infotainment & Technology"
    };

    public static Feature Feature_In_Car_WiFi_Hotspot = new Feature
    {
        Id = "0198c3aa-45cc-712f-b1b0-da95f5adcfac",
        FeatureName = "In-Car Wi-Fi Hotspot",
        Category = "Infotainment & Technology"
    };
    
    public static Feature Feature_Wireless_Charging_Pad = new Feature
    {
        Id = "0198c3aa-45cc-712f-b1b0-da96cc8be799",
        FeatureName = "Wireless Charging Pad",
        Category = "Infotainment & Technology"
    };
    public static Feature Feature_Multiple_USB_Ports_USB_C_Ports = new Feature
    {
        Id = "0198c3bb-6f78-7ea6-a82d-54a9932fc0c1",
        FeatureName = "Multiple USB Ports / USB-C Ports",
        Category = "Infotainment & Technology"
    };
    public static Feature Feature_Rear_Seat_Entertainment = new Feature
    {
        Id = "0198c3bb-6f7a-7184-b3f8-8d644baa9b86",
        FeatureName = "Rear Seat Entertainment (e.g., headrest screens)",
        Category = "Infotainment & Technology"
    };

    public static Feature[] FeaturesInfotainmentTechnology = [
        Feature_Rear_Seat_Entertainment,
        Feature_Multiple_USB_Ports_USB_C_Ports,
        Feature_Wireless_Charging_Pad,
        Feature_In_Car_WiFi_Hotspot,
        Feature_HD_Radio,
        Feature_Satellite_Radio,
        Feature_Upgraded_Sound_System,
        Feature_Premium_Sound_System,
        Feature_Navigation_System,
        Feature_Bluetooth_Connectivity,
        Feature_Apple_CarPlay,
        Feature_Android_Auto
    ];


    //Safety & Driver Assistance
    public static Feature Feature_Adaptive_Cruise_Control = new Feature
    {
        Id = "0198c3bb-6f7a-7184-b3f8-8d6545056006",
        FeatureName = "Adaptive Cruise Control",
        Category = "Safety & Driver Assistance"
    };

    public static Feature Feature_Lane_Keep_Assist = new Feature
    {
        Id = "0198c3bb-6f7a-7184-b3f8-8d665c4f6b7d",
        FeatureName = "Lane Keep Assist",
        Category = "Safety & Driver Assistance"
    };

    public static Feature Feature_Blind_Spot_Monitoring = new Feature
    {
        Id = "0198c3bb-6f7a-7184-b3f8-8d67e9c00727",
        FeatureName = "Blind Spot Monitoring",
        Category = "Safety & Driver Assistance"
    };

    public static Feature Feature_Rear_Cross_Traffic_Alert = new Feature
    {
        Id = "0198c3bb-6f7a-7184-b3f8-8d685fe255d6",
        FeatureName = "Rear Cross Traffic Alert",
        Category = "Safety & Driver Assistance"
    };

    public static Feature Feature_Forward_Collision_Warning = new Feature
    {
        Id = "0198c3bb-6f7a-7184-b3f8-8d69982d09b3",
        FeatureName = "Forward Collision Warning",
        Category = "Safety & Driver Assistance"
    };

    public static Feature Feature_Automatic_Emergency_Braking = new Feature
    {
        Id = "0198c3bb-6f7a-7184-b3f8-8d6a733e8b02",
        FeatureName = "Automatic Emergency Braking",
        Category = "Safety & Driver Assistance"
    };

    public static Feature Feature_Pedestrian_Detection = new Feature
    {
        Id = "0198c3bb-6f7a-7184-b3f8-8d6b089fe7ee",
        FeatureName = "Pedestrian Detection",
        Category = "Safety & Driver Assistance"
    };

    public static Feature Feature_Lane_Departure_Warning = new Feature
    {
        Id = "0198c3bb-6f7a-7184-b3f8-8d6ca4a86e86",
        FeatureName = "Lane Departure Warning",
        Category = "Safety & Driver Assistance"
    };

    public static Feature Feature_360_Degree_Camera = new Feature
    {
        Id = "0198c3bb-6f7a-7184-b3f8-8d6d08df5abc",
        FeatureName = "360-Degree Camera",
        Category = "Infotainment & Technology"
    };

    public static Feature Feature_Parking_Sensors = new Feature
    {
        Id = "0198c3bb-6f7b-7130-aa6c-701ee8be51aa",
        FeatureName = "Parking Sensors (Front & Rear)",
        Category = "Safety & Driver Assistance"
    };

    public static Feature Feature_Hill_Descent_Control = new Feature
    {
        Id = "0198c3bb-6f7b-7130-aa6c-701feec0e253",
        FeatureName = "Hill Descent Control",
        Category = "Safety & Driver Assistance"
    };

    public static Feature Feature_Traction_Control = new Feature
    {
        Id = "0198c3bb-6f7b-7130-aa6c-70204277ab61",
        FeatureName = "Traction Control",
        Category = "Safety & Driver Assistance"
    };

    public static Feature Feature_Electronic_Stability_Control = new Feature
    {
        Id = "0198c3bb-6f7b-7130-aa6c-7021e101a654",
        FeatureName = "Electronic Stability Control",
        Category = "Safety & Driver Assistance"
    };

    public static Feature Feature_Tire_Pressure_Monitoring_System = new Feature
    {
        Id = "0198fce0-8cc9-767f-84cf-30b75ca9a719",
        FeatureName = "Tire Pressure Monitoring System (TPMS)",
        Category = "Safety & Driver Assistance"
    };

    public static Feature[] FeaturesSafetyDriverAssistance = [
        Feature_Tire_Pressure_Monitoring_System,
        Feature_Electronic_Stability_Control,
        Feature_Traction_Control,
        Feature_Hill_Descent_Control,
        Feature_Parking_Sensors,
        Feature_360_Degree_Camera,
        Feature_Lane_Departure_Warning,
        Feature_Pedestrian_Detection,
        Feature_Automatic_Emergency_Braking,
        Feature_Forward_Collision_Warning,
        Feature_Adaptive_Cruise_Control,
        Feature_Lane_Keep_Assist,
        Feature_Blind_Spot_Monitoring,
        Feature_Rear_Cross_Traffic_Alert
    ];
    
    //Cargo & Practicality
    public static Feature Feature_Split_Folding_Rear_Seats = new Feature
    {
        Id = "0198c3bb-6f7b-7130-aa6c-702227a1987c",
        FeatureName = "Split-Folding Rear Seats (60/40)",
        Category = "Cargo & Practicality"
    };

    public static Feature Feature_Fold_Flat_Passenger_Seat = new Feature
    {
        Id = "0198c3bb-6f7b-7130-aa6c-7023071ea551",
        FeatureName = "Fold-Flat Passenger Seat",
        Category = "Cargo & Practicality"
    };

    public static Feature Feature_Hands_Free_Power_Tailgate = new Feature
    {
        Id = "0198c3bb-6f7b-7130-aa6c-702496604deb",
        FeatureName = "Hands-Free Power Tailgate (open with foot motion)",
        Category = "Cargo & Practicality"
    };

    public static Feature Feature_Cargo_Cover_Tonneau_Cover = new Feature
    {
        Id = "0198c3bb-6f7b-7130-aa6c-7025efdce2c7",
        FeatureName = "Cargo Cover / Tonneau Cover",
        Category = "Cargo & Practicality"
    };

    public static Feature Feature_Cargo_Net = new Feature
    {
        Id = "0198c3bb-6f7b-7130-aa6c-7026eac881b3",
        FeatureName = "Cargo Net",
        Category = "Cargo & Practicality"
    };

    public static Feature Feature_Underfloor_Storage = new Feature
    {
        Id = "0198c3bb-6f7b-7130-aa6c-70271bc46020",
        FeatureName = "Underfloor Storage",
        Category = "Cargo & Practicality"
    };

    public static Feature[] FeaturesCargoPracticality= [
        Feature_Underfloor_Storage,
        Feature_Cargo_Net,
        Feature_Cargo_Cover_Tonneau_Cover,
        Feature_Hands_Free_Power_Tailgate,
        Feature_Fold_Flat_Passenger_Seat,
        Feature_Split_Folding_Rear_Seats
    ];

    ///Convenience
    public static Feature Feature_Remote_Start = new Feature
    {
        Id = "0198c3bb-6f7b-7130-aa6c-7028fbd4a0a6",
        FeatureName = "Remote Start",
        Category = "Convenience"
    };

    public static Feature Feature_Automatic_Parking_Assist = new Feature
    {
        Id = "0198c3bb-6f7b-7130-aa6c-70297bcbdbf1",
        FeatureName = "Automatic Parking Assist",
        Category = "Convenience"
    };

    public static Feature Feature_Rain_Sensing_Wipers = new Feature
    {
        Id = "0198c3bb-6f7b-7130-aa6c-702a24c2763b",
        FeatureName = "Rain-Sensing Wipers",
        Category = "Convenience"
    };

    public static Feature Feature_Auto_Dimming_Rearview_Mirror = new Feature
    {
        Id = "0198c3bb-6f7b-7130-aa6c-702b5f744319",
        FeatureName = "Auto-Dimming Rearview Mirror",
        Category = "Convenience"
    };

    public static Feature Feature_Heated_Steering_Wheel = new Feature
    {
        Id = "0198c3bb-6f7b-7130-aa6c-702cc0220f1c",
        FeatureName = "Heated Steering Wheel",
        Category = "Convenience"
    };

    public static Feature Feature_Cooled_Glovebox = new Feature
    {
        Id = "0198c3bb-6f7b-7130-aa6c-702d71db424a",
        FeatureName = "Cooled Glovebox",
        Category = "Convenience"
    };

    public static Feature Feature_Sunshades = new Feature
    {
        Id = "0198c3bb-6f7b-7130-aa6c-702eb7394e98",
        FeatureName = "Sunshades (Rear Window & Side Windows)",
        Category = "Convenience"
    };

    public static Feature[] FeaturesConvenience = [
        Feature_Sunshades,
        Feature_Cooled_Glovebox,
        Feature_Heated_Steering_Wheel,
        Feature_Auto_Dimming_Rearview_Mirror,
        Feature_Rain_Sensing_Wipers,
        Feature_Automatic_Parking_Assist,
        Feature_Remote_Start
    ];

}
