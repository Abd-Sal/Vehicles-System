namespace SellingRentingCarsSystem.API.Data.Configurations;

public class ModelConfigurations : IEntityTypeConfiguration<Model>
{
    public void Configure(EntityTypeBuilder<Model> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedNever();

        builder.Property(x => x.ModelName)
            .HasMaxLength(200);
        
        builder.ToTable($"{nameof(Model)}s");

        var allModels = new List<Model>();
        allModels.AddRange(DefaultModels.Mercedes_Models);
        allModels.AddRange(DefaultModels.Audi_Models);
        allModels.AddRange(DefaultModels.BMW_Models);
        allModels.AddRange(DefaultModels.Porche);
        allModels.AddRange(DefaultModels.Volkswagen_Models);
        allModels.AddRange(DefaultModels.Ford_Models);

        builder.HasData(allModels);
    }
}
