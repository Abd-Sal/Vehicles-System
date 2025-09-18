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
    public static FullPowerTrainResponse ToFullPowerTrain(this PowerTrain powerTrain, IMapper mapper)
        => new FullPowerTrainResponse(
            powerTrain.Id, powerTrain.PowerTrainType, powerTrain.HorsePower,
            powerTrain.Torque, powerTrain.CombinedRangeMiles, powerTrain.ElectricOnlyRangeMiles,
            powerTrain.ChargePort != null ? powerTrain.ChargePort.ToChargePortResponse(mapper) : null,
            powerTrain.BatteryCapacityKWh,
            powerTrain.FuelDelivery != null ? powerTrain.FuelDelivery.ToFuelDeliveryResponse(mapper) : null,
            powerTrain.FuleType != null ? powerTrain.FuleType.ToFuelTypeResponse(mapper) : null,
            powerTrain.Aspiration != null ? powerTrain.Aspiration.ToAspirationResponse(mapper) : null,
            powerTrain.EngineSize, powerTrain.Cylinders);
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
    public static IQueryable<FullPowerTrainResponse> ToFullPowerTrain(this IQueryable<PowerTrain> powerTrains, IMapper mapper)
        => powerTrains.AsNoTracking()
            .Include(x => x.ChargePort)
            .Include(x => x.FuleType)
            .Include(x => x.FuelDelivery)
            .Include(x => x.Aspiration)
            .Select(x => new FullPowerTrainResponse(
                x.Id, x.PowerTrainType, x.HorsePower, x.Torque, x.CombinedRangeMiles,
                x.ElectricOnlyRangeMiles, x.ChargePort != null ? x.ChargePort.ToChargePortResponse(mapper) : null,
                x.BatteryCapacityKWh, x.FuelDelivery != null ? x.FuelDelivery.ToFuelDeliveryResponse(mapper) : null,
                x.FuleType != null ? x.FuleType.ToFuelTypeResponse(mapper) : null,
                x.Aspiration != null ? x.Aspiration.ToAspirationResponse(mapper) : null,
                x.EngineSize, x.Cylinders
            ));

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
    public static FullModelResponse ToFullModel(this Model model, IMapper mapper)
        => new FullModelResponse(model.Id, model.Make.ToMakeResponse(mapper), model.ModelName, model.ProductionYear);
    public static ModelResponse ToModelResponse(this Model model, IMapper mapper)
        => mapper.Map<ModelResponse>(model);
    public static List<ModelResponse> ToModelResponses(this IEnumerable<Model> models, IMapper mapper)
        => mapper.Map<List<ModelResponse>>(models);
    public static IQueryable<FullModelResponse> ToFullModellResponse(this IQueryable<Model> models, IMapper mapper)
        => models.AsNoTracking()
            .Include(x => x.Make)
            .Select(x => new FullModelResponse(x.Id, x.Make.ToMakeResponse(mapper), x.ModelName, x.ProductionYear));

    //TransmissionType
    public static TransmissionType ToTransmissionType(this TransmissionTypeRequest transmissionTypeRequest, IMapper mapper)
        => mapper.Map<TransmissionType>(transmissionTypeRequest);
    public static TransmissionTypeResponse ToTransmissionTypeResponse(this TransmissionType transmissionType, IMapper mapper)
        => mapper.Map<TransmissionTypeResponse>(transmissionType);
    public static List<TransmissionTypeResponse> ToTransmissionTypeResponses(this IEnumerable<TransmissionType> transmissionTypes, IMapper mapper)
        => mapper.Map<List<TransmissionTypeResponse>>(transmissionTypes);

    //VehicleFeature
    public static VehicleFeature ToVehicleFeature(this VehicleFeatureRequest vehicleFeatureRequest, IMapper mapper)
        => mapper.Map<VehicleFeature>(vehicleFeatureRequest);
    public static VehicleFeatureResponse ToVehicleFeatureResponse(this VehicleFeature vehicleFeature, IMapper mapper)
        => mapper.Map<VehicleFeatureResponse>(vehicleFeature);

    //Vehicle
    public static VehicleResponse ToFullVehicleResponse(this Vehicle vehicle, IMapper mapper)
        => new VehicleResponse(
                vehicle.Id, vehicle.VIN, vehicle.Model.ToFullModel(mapper),
                vehicle.AddDate, vehicle.RangeMiles, vehicle.InteriorColor, vehicle.ExteriorColor,
                vehicle.VehicleStatus, vehicle.BodyType.ToBodyTypeResponse(mapper),
                vehicle.TransmissionType.ToTransmissionTypeResponse(mapper), vehicle.PassengerCount,
                vehicle.PowerTrain.ToFullPowerTrain(mapper), vehicle.VehiclePrice
            );
    public static Vehicle ToVehicle(this VehicleRequest vehicleRequest, IMapper mapper)
        => mapper.Map<Vehicle>(vehicleRequest);
    public static BriefVehicleResponse ToBriefVehicleResponse(this Vehicle vehicle, IMapper mapper)
        => mapper.Map<BriefVehicleResponse>(vehicle);
    public static List<BriefVehicleResponse> ToBriefVehicleResponses(this IEnumerable<Vehicle> vehicles, IMapper mapper)
        => mapper.Map<List<BriefVehicleResponse>>(vehicles);
    public static IQueryable<VehicleResponse> ToVehicleResponse(this IQueryable<Vehicle> vehicles, IMapper mapper)
        => vehicles.AsNoTracking()
            .Include(x => x.BodyType)
            .Include(x => x.Model)
            .Include(x => x.Model.Make)
            .Include(x => x.TransmissionType)
            .Include(x => x.PowerTrain)
            .Include(x => x.PowerTrain.ChargePort)
            .Include(x => x.PowerTrain.FuelDelivery)
            .Include(x => x.PowerTrain.FuleType)
            .Include(x => x.PowerTrain.Aspiration)
        .Select(x => new VehicleResponse(
            x.Id, x.VIN, x.Model.ToFullModel(mapper), x.AddDate,
            x.RangeMiles, x.InteriorColor, x.ExteriorColor, x.VehicleStatus, x.BodyType.ToBodyTypeResponse(mapper),
            x.TransmissionType.ToTransmissionTypeResponse(mapper), x.PassengerCount, x.PowerTrain.ToFullPowerTrain(mapper),
            x.VehiclePrice
        ));
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
    public static IQueryable<FullRentVehicleResponse> ToFullRentVehicleResponses(this IQueryable<RentVehicle> rentVehicles, IMapper mapper)
        => rentVehicles.AsNoTracking()
            .Include(x => x.Customer)
            .Include(x => x.Payment)
            .Include(x => x.Vehicle)
            .Include(x => x.Vehicle.BodyType)
            .Include(x => x.Vehicle.TransmissionType)
            .Include(x => x.Vehicle.Model)
            .Include(x => x.Vehicle.Model.Make)
            .Include(x => x.Vehicle.PowerTrain)
            .Include(x => x.Vehicle.PowerTrain.ChargePort)
            .Include(x => x.Vehicle.PowerTrain.FuleType)
            .Include(x => x.Vehicle.PowerTrain.FuelDelivery)
            .Include(x => x.Vehicle.PowerTrain.Aspiration)
        .Select(x => new FullRentVehicleResponse(
            x.Id,
            x.Vehicle.ToFullVehicleResponse(mapper),
            x.Customer.ToCustomerResponse(mapper),
            x.StartAtMile,
            x.EndAtMile != null ? (int)x.EndAtMile : default,
            x.StartRentDate,
            x.ExpectedEndRentDate,
            x.ActualEndRentDate != null ? (DateTime)x.ActualEndRentDate : default,
            x.ExpectedAmount,
            x.DamageAmount,
            x.DamageDescription,
            x.Amount != null ? (int)x.Amount : default,
            x.PayLater,
            x.Payment!.ToPaymentResponse(mapper)
        ));

    public static IQueryable<FullRentedVehicleResponse> ToFullRentedVehicleResponses(this IQueryable<RentVehicle> rentVehicles, IMapper mapper)
        => rentVehicles.AsNoTracking()
            .Include(x => x.Customer)
            .Include(x => x.Vehicle)
            .Include(x => x.Vehicle.Model)
            .Include(x => x.Vehicle.Model.Make)
            .Include(x => x.Vehicle.TransmissionType)
            .Include(x => x.Vehicle.BodyType)
            .Include(x => x.Vehicle.PowerTrain)
            .Include(x => x.Vehicle.PowerTrain.ChargePort)
            .Include(x => x.Vehicle.PowerTrain.FuleType)
            .Include(x => x.Vehicle.PowerTrain.FuelDelivery)
            .Include(x => x.Vehicle.PowerTrain.Aspiration)
            .Select(x => new FullRentedVehicleResponse(
                x.Id,
                x.Vehicle.ToFullVehicleResponse(mapper),
                x.Customer.ToCustomerResponse(mapper),
                x.StartRentDate,
                x.ExpectedEndRentDate,
                x.ExpectedAmount
            ));
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
    public static IQueryable<FullBookingVehicleResponse> ToFullBookingResponse(this IQueryable<Booking> bookings, IMapper mapper)
        => bookings.AsNoTracking()
            .Include(x => x.Customer)
            .Include(x => x.Vehicle)
            .Include(x => x.Vehicle.Model)
            .Include(x => x.Vehicle.Model.Make)
            .Include(x => x.Vehicle.BodyType)
            .Include(x => x.Vehicle.TransmissionType)
            .Include(x => x.Vehicle.PowerTrain)
            .Include(x => x.Vehicle.PowerTrain.ChargePort)
            .Include(x => x.Vehicle.PowerTrain.FuleType)
            .Include(x => x.Vehicle.PowerTrain.FuelDelivery)
            .Include(x => x.Vehicle.PowerTrain.Aspiration)
            .Select(x => new FullBookingVehicleResponse(
                x.Id,
                x.Vehicle.ToFullVehicleResponse(mapper),
                x.Customer.ToCustomerResponse(mapper),
                x.StartDate,
                x.EndDate,
                x.ExpectedAmount
            ));

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
    public static IQueryable<FullSellVehicleResponse> ToFullSellVehicleResponses(this IQueryable<SellVehicle> sellVehicles, IMapper mapper)
        => sellVehicles.AsNoTracking()
            .Include(x => x.Customer)
            .Include(x => x.Payment)
            .Include(x => x.Vehicle)
            .Include(x => x.Vehicle.BodyType)
            .Include(x => x.Vehicle.Model)
            .Include(x => x.Vehicle.Model.Make)
            .Include(x => x.Vehicle.TransmissionType)
            .Include(x => x.Vehicle.PowerTrain)
            .Include(x => x.Vehicle.PowerTrain.ChargePort)
            .Include(x => x.Vehicle.PowerTrain.FuleType)
            .Include(x => x.Vehicle.PowerTrain.FuelDelivery)
            .Include(x => x.Vehicle.PowerTrain.Aspiration)
            .Select(x => new FullSellVehicleResponse(
                x.Id,
                x.Vehicle.ToFullVehicleResponse(mapper),
                x.Customer.ToCustomerResponse(mapper),
                x.SellDate,
                x.Payment.ToPaymentResponse(mapper)
            ));

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


