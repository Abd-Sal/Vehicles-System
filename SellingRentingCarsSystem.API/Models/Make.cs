namespace SellingRentingCarsSystem.API.Models;

public class Make
{
    public string Id { get; set; } = Guid.CreateVersion7().ToString();
    public string MakeName { get; set; } = string.Empty;
    public string CountryOfOrigin { get; set; } = string.Empty;

    public ICollection<Model> Models { get; set; } = 
        new List<Model>();
}
