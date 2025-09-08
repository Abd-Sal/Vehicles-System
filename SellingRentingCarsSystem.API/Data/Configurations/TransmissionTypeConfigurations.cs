namespace SellingRentingCarsSystem.API.Data.Configurations;

public class TransmissionTypeConfigurations : IEntityTypeConfiguration<TransmissionType>
{
    public void Configure(EntityTypeBuilder<TransmissionType> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedNever();

        builder.Property(x => x.TypeName)
            .HasMaxLength(200);

        builder.HasIndex(x => x.TypeName).IsUnique();

        builder.ToTable($"{nameof(TransmissionType)}s");

        builder.HasData(DefaultTransmissionTypes.TransmissionTypes);
    }
}
