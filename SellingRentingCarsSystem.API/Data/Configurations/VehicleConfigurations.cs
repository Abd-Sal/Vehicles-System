namespace SellingRentingCarsSystem.API.Data.Configurations;

public class VehicleConfigurations : IEntityTypeConfiguration<Vehicle>
{
    public void Configure(EntityTypeBuilder<Vehicle> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedNever();

        builder.Property(x => x.InteriorColor)
            .HasMaxLength(200);

        builder.Property(x => x.ExteriorColor)
            .HasMaxLength(200);

        builder.Property(x => x.VehicleStatus)
            .HasMaxLength(200);

        builder.HasIndex(x => x.VIN);

        builder.ToTable($"{nameof(Vehicle)}s");
    }
}
