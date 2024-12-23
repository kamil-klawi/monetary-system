namespace CurrencySystem.ConsoleApp.Helpers;

public static class WalletValidation
{
    public static bool IsValidGuid(Guid id)
    {
        return id == Guid.Empty;
    }
    
    public static bool IsValidDefaultCurrency(string firstName)
    {
        return IsValidStringInput(firstName);
    }

    public static bool IsValidDateTime(DateTime dateTime)
    {
        return dateTime > DateTime.Now;
    }

    private static bool IsValidStringInput(string input)
    {
        return string.IsNullOrWhiteSpace(input);
    }
}