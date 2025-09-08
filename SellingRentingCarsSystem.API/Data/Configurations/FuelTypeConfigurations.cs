namespace SellingRentingCarsSystem.API.Data.Configurations;

public class FuelTypeConfigurations : IEntityTypeConfiguration<FuelType>
{
    public void Configure(EntityTypeBuilder<FuelType> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedNever();

        builder.Property(x => x.TypeName)
            .HasMaxLength(200);

        builder.HasIndex(x => x.TypeName).IsUnique();

        builder.ToTable($"{nameof(FuelType)}s");

        builder.HasData(DefaultFuelTypes.FuelTypes);
    }
}
