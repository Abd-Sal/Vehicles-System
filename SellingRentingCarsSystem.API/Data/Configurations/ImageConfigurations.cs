namespace SellingRentingCarsSystem.API.Data.Configurations;

public class ImageConfigurations : IEntityTypeConfiguration<Image>
{
    public void Configure(EntityTypeBuilder<Image> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedNever();

        builder.Property(x => x.ImageName)
            .HasMaxLength(500);
        
        builder.Property(x => x.Caption)
            .HasMaxLength(500);

        builder.HasIndex(x => x.ImageName).IsUnique();

        builder.ToTable($"{nameof(Image)}s");
    }
}
