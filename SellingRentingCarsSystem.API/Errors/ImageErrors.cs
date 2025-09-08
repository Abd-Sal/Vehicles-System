namespace SellingRentingCarsSystem.API.Errors;

public class ImageErrors
{
    public static readonly Error NullImage =
        new("Image.Null",
            description: "ImageRequest is required",
            statusCode: StatusCodes.Status400BadRequest);

    public static readonly Error NotFoundImage =
        new("Image.NotFound",
            description: "Image is not found",
            statusCode: StatusCodes.Status404NotFound);

    public static readonly Error DuplicatedImage =
        new("Image.Duplicated",
            description: "Image is already exist",
            statusCode: StatusCodes.Status409Conflict);

    public static Error SizeImageError(int minSize, int maxSize) =>
        new("Image.SizeImageError",
            description: $"Image size should be between {minSize} and {maxSize}",
            statusCode: StatusCodes.Status400BadRequest);

    public static Error ImageExtensionError(string alloedExtensions) =>
        new("Image.Duplicated",
            description: $"Image allowed extensions {alloedExtensions}",
            statusCode: StatusCodes.Status400BadRequest);

    public static Error ImagePathError =
        new("Image.Duplicated",
            description: $"Image path is wrong",
            statusCode: StatusCodes.Status400BadRequest);
}
