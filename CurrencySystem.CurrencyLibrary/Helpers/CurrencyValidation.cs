using CurrencySystem.CurrencyLibrary.Enums;

namespace CurrencySystem.CurrencyLibrary.Helpers;

public static class CurrencyValidation
{
    public static bool IsValidCurrencyName(string currencyName)
    {
        return IsValidStringInput(currencyName);
    }
    
    public static bool IsValidCurrencyCode(string input, CurrencyType currencyType)
    {
        return IsValidStringInput(input) && input.Length is >= 3 and <= 4 && !IsAlphaNumeric(input) && currencyType != CurrencyType.COMMODITY;
    }
    
    public static bool IsValidCurrencySymbol(string currencySymbol)
    {
        return IsValidStringInput(currencySymbol);
    }

    public static bool IsValidCurrencyCountry(string currencyCountry)
    {
        return IsValidStringInput(currencyCountry);
    }
    
    public static bool IsValidMinorUnit(int minorUnit)
    {
        return IsPositiveValue(minorUnit);
    }
    
    public static bool IsValidExchangeRate(decimal exchangeRate)
    {
        return IsPositiveValue(exchangeRate);
    }

    private static bool IsPositiveValue<T>(T value) where T : IComparable<T>
    {
        return value.CompareTo(default(T)) <= 0;
    }
    
    private static bool IsValidStringInput(string input)
    {
        return string.IsNullOrWhiteSpace(input);
    }
    
    private static bool IsAlphaNumeric(string currencyCode)
    {
        return currencyCode.All(letter => char.IsLetterOrDigit(letter));
    }
}