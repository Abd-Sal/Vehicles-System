namespace SellingRentingCarsSystem.API.Data.Configurations;

public class PowerTrainConfigurations : IEntityTypeConfiguration<PowerTrain>
{
    public void Configure(EntityTypeBuilder<PowerTrain> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedNever();

        builder.Property(x => x.PowerTrainType)
            .HasMaxLength(200);

        builder.HasIndex(x => x.HashCode).IsUnique();
        
        builder.ToTable($"{nameof(PowerTrain)}s");
    }
}
