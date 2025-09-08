namespace SellingRentingCarsSystem.API.Errors;

public class BookingErrors
{
    public static readonly Error NullBooking =
        new(code: "Booking.Null",
            description: "Booking is required",
            statusCode: StatusCodes.Status400BadRequest);

    public static readonly Error NotFoundBooking =
        new(code: "Booking.NotFound",
            description: "Booking is not found",
            statusCode: StatusCodes.Status404NotFound);
    
    public static readonly Error CanceledBooking =
        new(code: "Booking.Canceled",
            description: "Booking is canceled",
            statusCode: StatusCodes.Status400BadRequest);
    
    public static Error TooLateStartDate(DateTime dateTime) =>
        new(code: "Booking.TooLate",
            description: $"Booking start date should be start <= {dateTime.Date}",
            statusCode: StatusCodes.Status400BadRequest);

}
public class NotificationErrors
{
    public static Error NotNotificationCauseEmailNull =
        new(code: "Notification.NotNotification",
            description: "Notification not sent because the customer doesn't have email",
            statusCode: StatusCodes.Status400BadRequest);

}
