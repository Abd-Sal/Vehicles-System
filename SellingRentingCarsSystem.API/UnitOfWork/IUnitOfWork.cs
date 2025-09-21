namespace SellingRentingCarsSystem.API.UnitOfWork;

public interface IUnitOfWork
{
    public IVehicleDetailsAspirationServices VehicleDetailsAspirationServices { get; }
    public IVehicleDetailsFeatureServices VehicleDetailsFeatureServices { get; }
    public IVehicleDetailsChargePortServices VehicleDetailsChargePortServices { get; }
    public IVehicleDetailsBodyTypeServices VehicleDetailsBodyTypeServices { get; }
    public IVehicleDetailsFuelDeliveryServices VehicleDetailsFuelDeliveryServices { get; }
    public IVehicleDetailsFuelTypeServices VehicleDetailsFuelTypeServices { get; }
    public IVehicleDetailsModelServices VehicleDetailsModelServices { get; }
    public IVehicleDetailsMakeServices VehicleDetailsMakeServices { get; }
    public IVehicleDetailsTransmissionTypeServices VehicleDetailsTransmissionTypeServices { get; }
    public IVehicleDetailsPowerTrainServices VehicleDetailsPowerTrainServices { get; }
    public IVehicleServices VehicleServices { get; }
    public ICustomerServices CustomerServices { get; }
    public IBookingServices BookingServices { get; }
    public IPaymentServices PaymentServices { get; }
    public IRentServices RentServices { get; }
    public ISellServices SellServices { get; }
    public IAuthServices AuthServices { get; }
    public IMaintenanceServices MaintenanceServices { get; }
    public INotificationSender NotificationSender { get; }
}
