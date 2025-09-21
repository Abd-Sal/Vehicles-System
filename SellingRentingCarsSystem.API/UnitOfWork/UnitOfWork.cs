namespace SellingRentingCarsSystem.API.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    public UnitOfWork(AppDbContext appDbContext, IMapper mapper,
        UserManager<ApplicationUser> userManager, IJwtProvider jwtProvider,
        IOptionsMonitor<ImagesProperties> imageOptions, IWebHostEnvironment webHostEnvironment,
        IOptions<EmailConfigurationsOptions> emailOptions,
        ILogger<NotificationSender> notificationLogger,
        ILogger<PaymentServices> paymentLogger,
        ILogger<CustomerServices> customerLogger,
        ILogger<BookingService> bookingLogger,
        ILogger<SellServices> sellLogger,
        ILogger<RentServices> rentLogger,
        ILogger<AuthServices> authLogger,
        ILogger<MaintenanceServices> maintenanceLogger
        )
    {
        VehicleDetailsAspirationServices = new VehicleDetailsAspirationServices(appDbContext, mapper);
        VehicleDetailsBodyTypeServices = new VehicleDetailsBodyTypeServices(appDbContext, mapper);
        VehicleDetailsChargePortServices = new VehicleDetailsChargePortServices(appDbContext, mapper);
        VehicleDetailsFeatureServices = new VehicleDetailsFeatureServices(appDbContext, mapper);
        VehicleDetailsFuelDeliveryServices = new VehicleDetailsFuelDeliveryServices(appDbContext, mapper);
        VehicleDetailsFuelTypeServices = new VehicleDetailsFuelTypeServices(appDbContext, mapper);
        VehicleDetailsMakeServices = new VehicleDetailsMakeServices(appDbContext, mapper);
        VehicleDetailsModelServices = new VehicleDetailsModelServices(appDbContext, mapper);
        VehicleDetailsPowerTrainServices = new VehicleDetailsPowerTrainServices(appDbContext, mapper);
        VehicleDetailsTransmissionTypeServices = new VehicleDetailsTransmissionTypeServices(appDbContext, mapper);
        NotificationSender = new NotificationSender(emailOptions, notificationLogger);
        PaymentServices = new PaymentServices(appDbContext, mapper, paymentLogger);
        CustomerServices = new CustomerServices(appDbContext, mapper, customerLogger);
        VehicleServices = new VehicleServices(appDbContext, mapper, PaymentServices, imageOptions, webHostEnvironment);
        BookingServices = new BookingService(appDbContext, mapper, NotificationSender, bookingLogger);
        SellServices = new SellServices(appDbContext, mapper, PaymentServices, BookingServices, sellLogger);
        RentServices = new RentServices(appDbContext, mapper, BookingServices, PaymentServices, NotificationSender, rentLogger);
        AuthServices = new AuthServices(userManager, jwtProvider, NotificationSender, authLogger);
        MaintenanceServices = new MaintenanceServices(appDbContext, mapper, PaymentServices, BookingServices, maintenanceLogger);
    }

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
