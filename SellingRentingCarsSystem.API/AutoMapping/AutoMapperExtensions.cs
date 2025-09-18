using System.Threading.Tasks;

namespace SellingRentingCarsSystem.API.AutoMapping;

public static class AutoMapperExtensions
{
    //BodyType
    public static BodyType ToBodyType(this BodyTypeRequest bodyTypeRequest, IMapper mapper)
        => mapper.Map<BodyType>(bodyTypeRequest);
    public static BodyTypeResponse ToBodyTypeResponse(this BodyType bodyType, IMapper mapper)
        => mapper.Map<BodyTypeResponse>(bodyType);
    public static List<BodyTypeResponse> ToBodyTypeResponses(this IEnumerable<BodyType> bodyTypes, IMapper mapper)
        => mapper.Map<List<BodyTypeResponse>>(bodyTypes);

    //PowerTrain
    public static PowerTrain ToPowerTrain(this CombinationPowerTrainRequest combinationPowerTrainRequest, IMapper mapper)
        => mapper.Map<PowerTrain>(combinationPowerTrainRequest);
    public static PowerTrain ToPowerTrain(this ElectricPowerTrainRequest electricPowerTrainRequest, IMapper mapper)
        => mapper.Map<PowerTrain>(electricPowerTrainRequest);
    public static PowerTrain ToPowerTrain(this HybridPowerTrainRequest hybridPowerTrainRequest, IMapper mapper)
        => mapper.Map<PowerTrain>(hybridPowerTrainRequest);
    public static PowerTrainResponse ToPowerTrainResponse(this PowerTrain powerTrain, IMapper mapper)
        => mapper.Map<PowerTrainResponse>(powerTrain);
    public static List<PowerTrainResponse> ToPowerTrainResponses(this IEnumerable<PowerTrain> powerTrains, IMapper mapper)
        => mapper.Map<List<PowerTrainResponse>>(powerTrains);

    //Feature
    public static Feature ToFeature(this FeatureRequest featureRequest, IMapper mapper)
        => mapper.Map<Feature>(featureRequest);
    public static FeatureResponse ToFeatureResponse(this Feature feature, IMapper mapper)
        => mapper.Map<FeatureResponse>(feature);
    public static List<FeatureResponse> ToFeatureResponses(this IEnumerable<Feature> features, IMapper mapper)
        => mapper.Map<List<FeatureResponse>>(features);

    //FuelType
    public static FuelType ToFuelType(this FuelTypeRequest fuelTypeRequest, IMapper mapper)
        => mapper.Map<FuelType>(fuelTypeRequest);
    public static FuelTypeResponse ToFuelTypeResponse(this FuelType fuelType, IMapper mapper)
        => mapper.Map<FuelTypeResponse>(fuelType);
    public static List<FuelTypeResponse> ToFuelTypeResponses(this IEnumerable<FuelType> fuelTypes, IMapper mapper)
        => mapper.Map<List<FuelTypeResponse>>(fuelTypes);

    //Make
    public static Make ToMake(this MakeRequest makeRequest, IMapper mapper)
        => mapper.Map<Make>(makeRequest);
    public static MakeResponse ToMakeResponse(this Make make, IMapper mapper)
        => mapper.Map<MakeResponse>(make);
    public static List<MakeResponse> ToMakeResponses(this IEnumerable<Make> makes, IMapper mapper)
        => mapper.Map<List<MakeResponse>>(makes);

    //Model
    public static Model ToModel(this ModelRequest modelRequest, IMapper mapper)
        => mapper.Map<Model>(modelRequest);
    public static ModelResponse ToModelResponse(this Model model, IMapper mapper)
        => mapper.Map<ModelResponse>(model);
    public static List<ModelResponse> ToModelResponses(this IEnumerable<Model> models, IMapper mapper)
        => mapper.Map<List<ModelResponse>>(models);

    //TransmissionType
    public static TransmissionType ToTransmissionType(this TransmissionTypeRequest transmissionTypeRequest, IMapper mapper)
        => mapper.Map<TransmissionType>(transmissionTypeRequest);
    public static TransmissionTypeResponse ToTransmissionTypeResponse(this TransmissionType transmissionType, IMapper mapper)
        => mapper.Map<TransmissionTypeResponse>(transmissionType);
    public static List<TransmissionTypeResponse> ToTransmissionTypeResponses(this IEnumerable<TransmissionType> transmissionTypes, IMapper mapper)
        => mapper.Map<List<TransmissionTypeResponse>>(transmissionTypes);

    //VehicleFeatureMapping
    public static VehicleFeature ToVehicleFeature(this VehicleFeatureRequest vehicleFeatureRequest, IMapper mapper)
        => mapper.Map<VehicleFeature>(vehicleFeatureRequest);
    public static VehicleFeatureResponse ToVehicleFeatureResponse(this VehicleFeature vehicleFeature, IMapper mapper)
        => mapper.Map<VehicleFeatureResponse>(vehicleFeature);

    //VehicleMapping
    public static Vehicle ToVehicle(this VehicleRequest vehicleRequest, IMapper mapper)
        => mapper.Map<Vehicle>(vehicleRequest);
    public static BriefVehicleResponse ToBriefVehicleResponse(this Vehicle vehicle, IMapper mapper)
        => mapper.Map<BriefVehicleResponse>(vehicle);
    public static List<BriefVehicleResponse> ToBriefVehicleResponses(this IEnumerable<Vehicle> vehicles, IMapper mapper)
        => mapper.Map<List<BriefVehicleResponse>>(vehicles);

    public static VehicleStatusResponse ToVehicleStatusResponse(this Vehicle vehicle)
        => new VehicleStatusResponse(vehicle.VehicleStatus);

    //Maintenance
    public static Maintenance ToMaintenance(this MaintenanceRequest maintenanceRequest, IMapper mapper)
        => mapper.Map<Maintenance>(maintenanceRequest);
    public static MaintenanceResponse ToMaintenanceResponse(this Maintenance maintenance, IMapper mapper)
        => mapper.Map<MaintenanceResponse>(maintenance);
    public static List<MaintenanceResponse> ToMaintenanceResponses(this IEnumerable<Maintenance> maintenances, IMapper mapper)
        => mapper.Map<List<MaintenanceResponse>>(maintenances);

    //Payment
    public static Payment ToPayment(this PaymentRequest paymentRequest, IMapper mapper)
        => mapper.Map<Payment>(paymentRequest);
    public static PaymentResponse ToPaymentResponse(this Payment payment, IMapper mapper)
        => mapper.Map<PaymentResponse>(payment);
    public static List<PaymentResponse> ToPaymentResponses(this IEnumerable<Payment> payments, IMapper mapper)
        => mapper.Map<List<PaymentResponse>>(payments);

    //RentVehicle
    public static RentVehicle ToRentVehicle(this RentVehicleRequest rentVehicleRequest, IMapper mapper)
        => mapper.Map<RentVehicle>(rentVehicleRequest);
    public static RentVehicle ToRentVehicle(this StopRentVehicleRequest stopRentVehicleRequest, IMapper mapper)
        => mapper.Map<RentVehicle>(stopRentVehicleRequest);
    public static RentVehicleResponse ToRentVehicleResponse(this RentVehicle rentVehicle, IMapper mapper)
        => mapper.Map<RentVehicleResponse>(rentVehicle);
    public static List<RentVehicleResponse> ToRentVehicleResponses(this IEnumerable<RentVehicle> rentVehicles, IMapper mapper)
        => mapper.Map<List<RentVehicleResponse>>(rentVehicles);

    //Tag
    public static List<TagResponse> ToTagResponses(this IEnumerable<Tag> tags, IMapper mapper)
        => mapper.Map<List<TagResponse>>(tags);

    //Booking
    public static Booking ToBookingVehicle(this BookingVehicleRequest bookingVehicleRequest, IMapper mapper)
    => mapper.Map<Booking>(bookingVehicleRequest);
    public static BookingVehicleResponse ToBookingResponse(this Booking booking, IMapper mapper)
        => mapper.Map<BookingVehicleResponse>(booking);
    public static List<BookingVehicleResponse> ToBookingResponses(this IEnumerable<Booking> bookings, IMapper mapper)
        => mapper.Map<List<BookingVehicleResponse>>(bookings);
    
    //Customer
    public static Customer ToCustomer(this CustomerRequest  customerRequest, IMapper mapper)
    => mapper.Map<Customer>(customerRequest);
    public static CustomerResponse ToCustomerResponse(this Customer customer, IMapper mapper)
        => mapper.Map<CustomerResponse>(customer);
    public static List<CustomerResponse> ToCustomerResponses(this IEnumerable<Customer> customers, IMapper mapper)
        => mapper.Map<List<CustomerResponse>>(customers);
    public static IQueryable<CustomerResponse> ToCustomerResponses(this IQueryable<Customer> customers, IMapper mapper, bool flag)
        => mapper.Map<IQueryable<CustomerResponse>>(customers);

    //SellVehicle
    public static SellVehicle ToSellVehicle(this SellVehicleRequest sellVehicleRequest, IMapper mapper)
        => mapper.Map<SellVehicle>(sellVehicleRequest);
    public static SellVehicleResponse ToSellVehicleResponse(this SellVehicle sellVehicle, IMapper mapper)
        => mapper.Map<SellVehicleResponse>(sellVehicle);
    public static List<SellVehicleResponse> ToSellVehicleResponses(this IEnumerable<SellVehicle> sellVehicles, IMapper mapper)
        => mapper.Map<List<SellVehicleResponse>>(sellVehicles);

    //Image
    public static Image ToImage(this ImageRequest imageRequest, IMapper mapper)
        => mapper.Map<Image>(imageRequest);
    public static ImageResponse ToImageResponse(this Image image, IMapper mapper)
        => mapper.Map<ImageResponse>(image);
    public static List<ImageResponse> ToImageResponses(this IEnumerable<Image> images, IMapper mapper)
        => mapper.Map<List<ImageResponse>>(images);

    //FuelDelivery
    public static FuelDelivery ToFuelDelivery(this FuelDeliveryRequest fuelDeliveryRequest, IMapper mapper)
        => mapper.Map<FuelDelivery>(fuelDeliveryRequest);
    public static FuelDeliveryResponse ToFuelDeliveryResponse(this FuelDelivery fuelDelivery, IMapper mapper)
        => mapper.Map<FuelDeliveryResponse>(fuelDelivery);

    //Aspiration
    public static Aspiration ToAspiration(this AspirationRequest aspirationRequest, IMapper mapper)
        => mapper.Map<Aspiration>(aspirationRequest);
    public static AspirationResponse ToAspirationResponse(this Aspiration aspiration, IMapper mapper)
        => mapper.Map<AspirationResponse>(aspiration);

    //ChargePort
    public static ChargePort ToChargePort(this ChargePortRequest chargePortRequest, IMapper mapper)
    => mapper.Map<ChargePort>(chargePortRequest);
    public static ChargePortResponse ToChargePortResponse(this ChargePort chargePort, IMapper mapper)
        => mapper.Map<ChargePortResponse>(chargePort);

}


