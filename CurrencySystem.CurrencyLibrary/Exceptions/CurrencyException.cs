namespace CurrencySystem.CurrencyLibrary.Exceptions;

public class CurrencyException : Exception
{
    public string CurrencyCode { get; }
    
    public CurrencyException(string message, string currencyCode) : base(message)
    {
        CurrencyCode = currencyCode;
    }
}