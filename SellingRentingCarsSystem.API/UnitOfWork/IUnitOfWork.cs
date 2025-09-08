namespace SellingRentingCarsSystem.API.UnitOfWork;

public interface IUnitOfWork
{
    public IVehicleServices VehicleServices { get; }
    public IVehicleDetailsServices VehicleDetailsServices { get; }
    public ICustomerServices CustomerServices { get; }
    public IBookingServices BookingServices { get; }
    public IPaymentServices PaymentServices { get; }
    public IRentServices RentServices { get; }
    public ISellServices SellServices { get; }
    public IAuthServices AuthServices { get; }
    public IMaintenanceServices MaintenanceServices { get; }
    public INotificationSender NotificationSender { get; }
}
