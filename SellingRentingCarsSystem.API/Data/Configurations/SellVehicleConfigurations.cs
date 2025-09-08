namespace SellingRentingCarsSystem.API.Data.Configurations;

public class SellVehicleConfigurations : IEntityTypeConfiguration<SellVehicle>
{
    public void Configure(EntityTypeBuilder<SellVehicle> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedNever();

        builder.ToTable($"{nameof(SellVehicle)}s");
    }
}
