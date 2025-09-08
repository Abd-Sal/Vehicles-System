namespace SellingRentingCarsSystem.API.Data.Configurations;

public class CustomerConfigurations : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedNever();

        builder.Property(x => x.FirstName)
            .HasMaxLength(100);

        builder.Property(x => x.LastName)
            .HasMaxLength(100);

        builder.Property(x => x.PhoneNumber)
            .HasMaxLength(50);

        builder.Property(x => x.NID)
            .HasMaxLength(50);

        builder.Property(x => x.Address)
            .HasMaxLength(450);

        builder.Property(x => x.Email)
            .HasMaxLength(450)
            .IsRequired(false);

        builder.HasIndex(x => x.NID).IsUnique();
        builder.HasIndex(x => x.PhoneNumber).IsUnique();
        builder.HasIndex(x => x.Email).IsUnique();

        builder.ToTable($"{nameof(Customer)}s");
    }
}
