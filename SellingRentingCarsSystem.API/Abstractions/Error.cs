namespace SellingRentingCarsSystem.API.Abstractions;

public class Error
{
    public static Error None = new Error(string.Empty, string.Empty, null);

    public Error(string code, string description, int? statusCode)
    {
        Code = code;
        Description = description;
        StatusCode = statusCode;
    }

    public string Code { get; }
    public string Description { get; }
    public int? StatusCode { get; } = null;

}
