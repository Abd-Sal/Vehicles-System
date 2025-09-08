namespace SellingRentingCarsSystem.API.Data.Configurations;

public class MaintenanceConfigurations : IEntityTypeConfiguration<Maintenance>
{
    public void Configure(EntityTypeBuilder<Maintenance> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedNever();

        builder.Property(x => x.Title)
            .HasMaxLength(500);

        builder.Property(x => x.Description)
            .HasMaxLength(4000);

        builder.ToTable($"{nameof(Maintenance)}s");
    }
}
