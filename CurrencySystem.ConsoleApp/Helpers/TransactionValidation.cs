namespace CurrencySystem.ConsoleApp.Helpers;

public static class TransactionValidation
{
    public static bool IsValidCurrency(string currency)
    {
        return IsValidStringInput(currency);
    }

    public static bool IsValidAmount(decimal amount)
    {
        return amount <= 0;
    }
    
    private static bool IsValidStringInput(string input)
    {
        return string.IsNullOrWhiteSpace(input);
    }
}