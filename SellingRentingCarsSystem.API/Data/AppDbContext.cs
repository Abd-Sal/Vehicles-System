namespace SellingRentingCarsSystem.API.Data;

public class AppDbContext : IdentityDbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
        
    }
    public DbSet<BodyType> BodyTypes { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Feature> Features { get; set; }
    public DbSet<FuelType> FuelTypes { get; set; }
    public DbSet<Image> Images { get; set; }
    public DbSet<Make> Makes { get; set; }
    public DbSet<Model> Models { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<PowerTrain> PowerTrains { get; set; }
    public DbSet<RentVehicle> RentVehicles { get; set; }
    public DbSet<SellVehicle> SellVehicles { get; set; }
    public DbSet<TransmissionType> TransmissionTypes { get; set; }
    public DbSet<Vehicle> Vehicles { get; set; }
    public DbSet<VehicleFeature> VehicleFeatures { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<VehicleTags> VehileTags { get; set; }
    public DbSet<Booking> Bookings { get; set; }
    public DbSet<Maintenance> Maintenances { get; set; }
    public DbSet<FuelDelivery> FuelDeliveries { get; set; }
    public DbSet<Aspiration> Aspirations { get; set; }
    public DbSet<ChargePort> ChargePorts { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

        var _FKs = modelBuilder.Model
            .GetEntityTypes()
            .SelectMany(t => t.GetForeignKeys())
            .Where(fk => fk.DeleteBehavior == DeleteBehavior.Cascade &&
                !fk.IsOwnership);

        foreach (var fk in _FKs)
            fk.DeleteBehavior = DeleteBehavior.Restrict;
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.ConfigureWarnings(warnings =>
            warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
    }
}


