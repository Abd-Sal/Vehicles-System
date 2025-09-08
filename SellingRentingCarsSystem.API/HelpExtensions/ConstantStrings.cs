namespace SellingRentingCarsSystem.API.HelpExtensions;

public class ConstantStrings
{
    public static string Origin = "https://localhost:5000";

    public static string AllowedOrigin = "AllowedOrigins";

    //Emails

    //Cancel Booking
    public static readonly string SubjectForCancelBooking = "Eagle For Cars Trading : Cancel Booking";
    public static string BodyForCancelBooking(Customer customer, Vehicle vehicle) =>
        $"Hi {customer.FirstName} {customer.LastName}," +
        $"\nthe booking for ({vehicle.Model.Make.MakeName} {vehicle.Model.ModelName} {vehicle.Model.ProductionYear})" +
        $" was canceled At {DateTime.UtcNow.ToString()}\n";

    //Update Booking
    public static readonly string SubjectForUpdateBooking = "Eagle For Cars Trading : Update Booking Date";
    public static string BodyForUpdateBooking(Customer customer, Vehicle vehicle, UpdateBookingVehicleRequest updatedBookingDate) =>
        $"Hi {customer.FirstName} {customer.LastName}," +
        $"\nthe booking date for({vehicle.Model.Make.MakeName} {vehicle.Model.ModelName} {vehicle.Model.ProductionYear})" +
        $" was updated at {DateTime.UtcNow.ToString()}\nthe new date ({updatedBookingDate.StartDate} => {updatedBookingDate.EndDate})\n" +
        $"Amount : {updatedBookingDate.ExpectedAmount}";

    //Booking Vehicle
    public static readonly string SubjectForBooking = "Eagle For Cars Trading : Booking A Vehicle";
    public static string BodyForBooking(Customer customer, Vehicle vehicle, Booking booking) =>
        $"Hi {customer.FirstName} {customer.LastName}," +
        $"\nthank you for booking from our garage\n" +
        $"Vehicle : {vehicle.Model.Make.MakeName} {vehicle.Model.ModelName} {vehicle.Model.ProductionYear}\n" +
        $"Date : {booking.StartDate} => {booking.EndDate}\n" +
        $"Amount : {booking.ExpectedAmount}";

    //Renting Start Renting
    public static readonly string SubjectForStartRenting = "Eagle For Cars Trading : Renting Is Ended";
    public static string BodyForStartRenting(Customer customer, Vehicle vehicle, RentVehicle rentVehicle) =>
        $"Hi {customer.FirstName} {customer.LastName},\n" +
        $"the renting is started for ({vehicle.Model.Make.MakeName} {vehicle.Model.ModelName} {vehicle.Model.ProductionYear})\n" +
        $"Date : {rentVehicle.StartRentDate} => {rentVehicle.ExpectedEndRentDate}" +
        $"Amount : {rentVehicle.ExpectedAmount}";

    //Renting Stop Renting
    public static readonly string SubjectForStopRenting = "Eagle For Cars Trading : Renting Is Ended";
    public static string BodyForStopRenting(Customer customer, Vehicle vehicle, RentVehicle rentVehicle) =>
        $"Hi {customer.FirstName} {customer.LastName},\n" +
        $"the renting is ended for ({vehicle.Model.Make.MakeName} {vehicle.Model.ModelName} {vehicle.Model.ProductionYear})\n" +
        $"Date : {rentVehicle.StartRentDate} => {rentVehicle.ActualEndRentDate}" +
        $"Amount : {rentVehicle.Amount}";

    //Reset Password
    public static readonly string SubjecyForResetPassword = "Eagle For Cars Trading : Reset Password";
    public static string BodyForResetPassword(string code) =>
        $"the confirmation code : {code}";

}
