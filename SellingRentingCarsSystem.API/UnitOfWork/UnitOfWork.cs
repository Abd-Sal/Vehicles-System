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
        NotificationSender = new NotificationSender(emailOptions, notificationLogger);
        VehicleDetailsServices = new VehicleDetailsServices(appDbContext, mapper);
        PaymentServices = new PaymentServices(appDbContext, mapper, paymentLogger);
        CustomerServices = new CustomerServices(appDbContext, mapper, customerLogger);
        VehicleServices = new VehicleServices(appDbContext, mapper, VehicleDetailsServices, PaymentServices, imageOptions, webHostEnvironment);
        BookingServices = new BookingService(appDbContext, mapper, NotificationSender, bookingLogger);
        SellServices = new SellServices(appDbContext, mapper, PaymentServices, BookingServices, sellLogger);
        RentServices = new RentServices(appDbContext, mapper, BookingServices, PaymentServices, NotificationSender, rentLogger);
        AuthServices = new AuthServices(userManager, jwtProvider, NotificationSender, authLogger);
        MaintenanceServices = new MaintenanceServices(appDbContext, mapper, PaymentServices, BookingServices, maintenanceLogger);
    }
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
