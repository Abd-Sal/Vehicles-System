using System.ComponentModel.DataAnnotations;

namespace SellingRentingCarsSystem.API.HelpExtensions;

public class JwtOptions
{
    public static readonly string SectionName = "Jwt";

    [Required]
    public string Key { get; set; } = string.Empty;
    [Required]
    public string Issure { get; set; } = string.Empty;
    [Required]
    public string Audience { get; set; } = string.Empty;
    [Range(1, int.MaxValue)]
    public int ExpireMinutes { get; set; }
}
