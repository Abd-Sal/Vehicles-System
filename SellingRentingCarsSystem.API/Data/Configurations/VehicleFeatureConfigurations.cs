namespace SellingRentingCarsSystem.API.Data.Configurations;

public class VehicleFeatureConfigurations : IEntityTypeConfiguration<VehicleFeature>
{
    public void Configure(EntityTypeBuilder<VehicleFeature> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedNever();

        builder.ToTable($"{nameof(VehicleFeature)}s");
    }
}
