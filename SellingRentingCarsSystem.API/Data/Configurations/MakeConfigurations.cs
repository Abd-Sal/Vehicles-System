namespace SellingRentingCarsSystem.API.Data.Configurations;

public class MakeConfigurations : IEntityTypeConfiguration<Make>
{
    public void Configure(EntityTypeBuilder<Make> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedNever();

        builder.Property(x => x.MakeName)
            .HasMaxLength(200);
        
        builder.Property(x => x.CountryOfOrigin)
            .HasMaxLength(200);

        builder.HasIndex(x => new { x.MakeName, x.CountryOfOrigin }).IsUnique();

        builder.ToTable($"{nameof(Make)}s");

        var allMakes = new List<Make>();
        allMakes.AddRange(DefaultMakes.MakeFrance);
        allMakes.AddRange(DefaultMakes.MakeUnitedKingdom);
        allMakes.AddRange(DefaultMakes.MakeSweden);
        allMakes.AddRange(DefaultMakes.MakeSouthKorea);
        allMakes.AddRange(DefaultMakes.MakeGermany);
        allMakes.AddRange(DefaultMakes.MakeItaly);
        allMakes.AddRange(DefaultMakes.MakeUS);
        allMakes.AddRange(DefaultMakes.MakeJapan);

        builder.HasData(allMakes);
    }
}
