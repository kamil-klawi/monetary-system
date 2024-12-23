using System.Text.RegularExpressions;

namespace CurrencySystem.ConsoleApp.Helpers;

public static class UserValidation
{
    public static bool IsValidGuid(Guid id)
    {
        return id == Guid.Empty;
    }
    
    public static bool IsValidFirstName(string firstName)
    {
        return IsValidStringInput(firstName);
    }

    public static bool IsValidLastName(string lastName)
    {
        return IsValidStringInput(lastName);
    }
    
    public static bool IsValidEmail(string email)
    {
        var regex = new Regex("^[a-zA-Z0-9.!$%&*+_-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$");
        var match = regex.Match(email);
        return match.Success;
    }

    public static bool IsValidDateBirth(DateTime dateTime)
    {
        return dateTime > DateTime.Now || dateTime < new DateTime(1900, 1, 1);
    }

    private static bool IsValidStringInput(string input)
    {
        return string.IsNullOrWhiteSpace(input);
    }
}