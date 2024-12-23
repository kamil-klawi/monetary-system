namespace CurrencySystem.ConsoleApp.Helpers;

public static class AddressValidation
{
    public static bool IsValidGuid(Guid id)
    {
        return id == Guid.Empty;
    }
    
    public static bool IsValidCountry(string country)
    {
        return IsValidStringInput(country);
    }

    public static bool IsValidCity(string city)
    {
        return IsValidStringInput(city);
    }

    public static bool IsValidStreet(string street)
    {
        return IsValidStringInput(street);
    }

    public static bool IsValidZipCode(string zipCode)
    {
        return IsValidStringInput(zipCode);
    }

    private static bool IsValidStringInput(string input)
    {
        return string.IsNullOrWhiteSpace(input);
    }
}