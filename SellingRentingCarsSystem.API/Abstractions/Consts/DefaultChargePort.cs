namespace SellingRentingCarsSystem.API.Abstractions.Consts;

public class DefaultChargePort
{
    public static ChargePort ChargePort_CCS = new ChargePort
    {
        Id = "0198c34a-8ba0-7089-a560-479ec048048e",
        PortName = "CCS (Combined Charging System)"
    };

    public static ChargePort ChargePort_CHAdeMO = new ChargePort
    {
        Id = "0198c34a-8ba0-7089-a560-479fd7feef0b",
        PortName = "CHAdeMO"
    };

    public static ChargePort ChargePort_GB_T = new ChargePort
    {
        Id = "0198c34a-8ba0-7089-a560-47a09b2b2ce9",
        PortName = "GB/T"
    };

    public static ChargePort ChargePort_J1772 = new ChargePort
    {
        Id = "0198c34a-8ba0-7089-a560-47a1e5ec96c5",
        PortName = "J1772"
    };

    public static ChargePort ChargePort_Mennekes_AC_Charging = new ChargePort
    {
        Id = "0198c34a-8ba0-7089-a560-47a2c8a011dd",
        PortName = "Mennekes - AC Charging"
    };

    public static ChargePort ChargePort_Tesla_Connector_NACS = new ChargePort
    {
        Id = "0198c34a-8ba0-7089-a560-47a3a8bca916",
        PortName = "Tesla Connector NACS"
    };

    public static ChargePort[] ChargePorts = [
        ChargePort_CCS,
        ChargePort_CHAdeMO,
        ChargePort_GB_T,
        ChargePort_J1772,
        ChargePort_Mennekes_AC_Charging,
        ChargePort_Tesla_Connector_NACS
    ];
}
