namespace SellingRentingCarsSystem.API.Data.Configurations;

public class ChargePortConfigurations : IEntityTypeConfiguration<ChargePort>
{
    public void Configure(EntityTypeBuilder<ChargePort> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedNever();

        builder.Property(x => x.PortName)
            .HasMaxLength(200);
        
        builder.HasIndex(x => x.PortName).IsUnique();

        builder.ToTable($"{nameof(ChargePort)}s");

        builder.HasData(DefaultChargePort.ChargePorts);
    }
}
