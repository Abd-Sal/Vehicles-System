namespace SellingRentingCarsSystem.API.HelpExtensions;

public class HelpToolsExtensions
{
    public static bool PasswordFormat(string password)
        => password.Trim().Length >= 8 &&
           password.Any(c => "ABCDEFGHIJKLMNOPQRSTUVWXYZ".Contains(c)) &&
           password.Any(c => "abcdefghijklmnopqrstuvwxyz".Contains(c)) &&
           password.Any(c => "123456789".Contains(c)) &&
           password.Any(c => "*#&@!%$^()_-+=[]{}:;'\"\\/|<>?".Contains(c));
}
