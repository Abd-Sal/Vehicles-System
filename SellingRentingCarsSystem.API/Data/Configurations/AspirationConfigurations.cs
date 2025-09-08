namespace SellingRentingCarsSystem.API.Data.Configurations;

public class AspirationConfigurations : IEntityTypeConfiguration<Aspiration>
{
    public void Configure(EntityTypeBuilder<Aspiration> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedNever();

        builder.Property(x => x.TypeName)
            .HasMaxLength(200);
        
        builder.HasIndex(x => x.TypeName).IsUnique();

        builder.ToTable($"{nameof(Aspiration)}s");


        builder.HasData(DefaultAspirations.Aspirations);

    }
}
