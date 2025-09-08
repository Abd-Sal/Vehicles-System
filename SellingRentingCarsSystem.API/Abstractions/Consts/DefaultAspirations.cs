namespace SellingRentingCarsSystem.API.Abstractions.Consts;

public class DefaultAspirations
{
    public static Aspiration Aspiration_Forced_Induction = new Aspiration
    {
        Id = "0198c34a-8ba0-7089-a560-47aa3acdb58a",
        TypeName = "Forced Induction"
    };

    public static Aspiration Aspiration_Naturally_Aspirated = new Aspiration
    {
        Id = "0198c34a-8ba0-7089-a560-47abace73521",
        TypeName = "Naturally Aspirated"
    };

    public static Aspiration[] Aspirations =
        [
            Aspiration_Forced_Induction,
            Aspiration_Naturally_Aspirated
        ];
}
