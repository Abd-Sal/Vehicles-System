namespace SellingRentingCarsSystem.API.Data.Configurations;

public class RentVehicleConfigurations : IEntityTypeConfiguration<RentVehicle>
{
    public void Configure(EntityTypeBuilder<RentVehicle> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedNever();

        builder.Property(x => x.DamageDescription)
            .HasMaxLength(4000);

        builder.ToTable($"{nameof(RentVehicle)}s");
    }
}
