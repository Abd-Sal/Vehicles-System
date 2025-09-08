using System.ComponentModel.DataAnnotations;

namespace SellingRentingCarsSystem.API.HelpExtensions;

public class ImagesProperties
{
    public static readonly string SectionName = "Images";

    [Required]
    public string Path { get; set; } = string.Empty;
    [Required]
    public string AllowedExtensions { get; set; } = string.Empty;
    [Required]
    public int MaxSizeInByte { get; set; }
    [Required]
    public int MinSizeInByte { get; set; }

}
