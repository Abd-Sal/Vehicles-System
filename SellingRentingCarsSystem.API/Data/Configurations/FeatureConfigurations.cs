namespace SellingRentingCarsSystem.API.Data.Configurations;

public class FeatureConfigurations : IEntityTypeConfiguration<Feature>
{
    public void Configure(EntityTypeBuilder<Feature> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedNever();

        builder.Property(x => x.FeatureName)
            .HasMaxLength(200);

        builder.Property(x => x.Category)
            .HasMaxLength(200);

        builder.HasIndex(x => new { x.FeatureName, x.Category }).IsUnique();

        builder.ToTable($"{nameof(Feature)}s");

        var allFeatures = new List<Feature>();
        allFeatures.AddRange(DefaultFeatures.FeaturesConvenience);
        allFeatures.AddRange(DefaultFeatures.FeaturesCargoPracticality);
        allFeatures.AddRange(DefaultFeatures.FeaturesSafetyDriverAssistance);
        allFeatures.AddRange(DefaultFeatures.FeaturesInfotainmentTechnology);
        allFeatures.AddRange(DefaultFeatures.FeaturesInteriorComfort);
        allFeatures.AddRange(DefaultFeatures.FeaturesExteriorFeatures);
        allFeatures.AddRange(DefaultFeatures.FeaturesPerformanceDrivetrain);

        builder.HasData(allFeatures.ToArray());
    }
}
