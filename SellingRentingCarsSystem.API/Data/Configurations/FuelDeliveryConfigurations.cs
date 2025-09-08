namespace SellingRentingCarsSystem.API.Data.Configurations;

public class FuelDeliveryConfigurations : IEntityTypeConfiguration<FuelDelivery>
{
    public void Configure(EntityTypeBuilder<FuelDelivery> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedNever();

        builder.Property(x => x.TypeName)
            .HasMaxLength(200);
        
        builder.HasIndex(x => x.TypeName).IsUnique();

        builder.ToTable("FuelDeliveries");

        builder.HasData(DefaultFuelDeliveries.FuelDeliveries);
    }
}
