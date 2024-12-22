using CurrencySystem.CurrencyLibrary.Enums;
using CurrencySystem.CurrencyLibrary.Helpers;

namespace CurrencySystem.CurrencyLibrary.Models;

public class Currency
{
    public string Name { get; }
    public string CurrencyCode { get; }
    public string CurrencySymbol { get; }
    public string Country { get; }
    public int MinorUnit { get; }
    public decimal ExchangeRate { get; }
    public CurrencyType CurrencyType { get; }

    private Currency(string name, string currencyCode, string currencySymbol, string country, int minorUnit, decimal exchangeRate, CurrencyType currencyType)
    {
        Name = name;
        CurrencyCode = currencyCode;
        CurrencySymbol = currencySymbol;
        Country = country;
        MinorUnit = minorUnit;
        ExchangeRate = exchangeRate;
        CurrencyType = currencyType;
    }

    public static Currency CreateOrUpdateCurrency(string name, string currencyCode, string currencySymbol, string country, int minorUnit, decimal exchangeRate, CurrencyType currencyType)
    {
        if (CurrencyValidation.IsValidCurrencyName(name))
            throw new ArgumentException("Currency cannot be null or whitespace.", nameof(name));
        
        if (CurrencyValidation.IsValidCurrencyCode(currencyCode, currencyType))
            throw new ArgumentException("Currency code must be a 3-character alphanumeric code.", nameof(currencyCode));
        
        if (CurrencyValidation.IsValidCurrencySymbol(currencySymbol))
            throw new ArgumentException("Currency symbol cannot be null or whitespace.", nameof(currencySymbol));
        
        if (CurrencyValidation.IsValidCurrencyCountry(country))
            throw new ArgumentException("Country cannot be null or whitespace.", nameof(country));
        
        if (CurrencyValidation.IsValidMinorUnit(minorUnit))
            throw new ArgumentException("Minor unit must be a positive integer.", nameof(minorUnit));
        
        if (CurrencyValidation.IsValidExchangeRate(exchangeRate))
            throw new ArgumentException("Exchange rate must be a positive decimal value.", nameof(exchangeRate));
        
        return new Currency(name, currencyCode, currencySymbol, country, minorUnit, exchangeRate, currencyType);
    }
}
