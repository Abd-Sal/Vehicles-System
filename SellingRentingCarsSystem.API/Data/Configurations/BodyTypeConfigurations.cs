namespace SellingRentingCarsSystem.API.Data.Configurations;

public class BodyTypeConfigurations : IEntityTypeConfiguration<BodyType>
{
    public void Configure(EntityTypeBuilder<BodyType> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedNever();

        builder.Property(x => x.TypeName)
            .HasMaxLength(200);

        builder.HasIndex(x => new {x.TypeName, x.DoorCount}).IsUnique();

        builder.ToTable($"{nameof(BodyType)}s");

        builder.HasData(
            DefaultBodyTypes.BodyTypes
        );
    }
}
