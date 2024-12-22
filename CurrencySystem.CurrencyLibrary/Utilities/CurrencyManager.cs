using CurrencySystem.CurrencyLibrary.Exceptions;
using CurrencySystem.CurrencyLibrary.Interfaces;
using CurrencySystem.CurrencyLibrary.Models;

namespace CurrencySystem.CurrencyLibrary.Utilities;

public class CurrencyManager : ICurrencyManager
{
    private readonly Dictionary<string, Currency> _currencies;

    public CurrencyManager()
    {
        _currencies = new Dictionary<string, Currency>();
    }

    public void AddCurrency(Currency currency)
    {
        if (_currencies.ContainsKey(currency.CurrencyCode))
            throw new CurrencyException($"Currency already exists.", currency.CurrencyCode);

        _currencies[currency.CurrencyCode] = currency;
    }

    public void RemoveCurrency(string currencyCode)
    {
        if (!_currencies.ContainsKey(currencyCode))
            throw new CurrencyException($"Currency not found.", currencyCode);
        
        _currencies.Remove(currencyCode);
    }
    
    public void UpdateCurrency(string currencyCode, decimal exchangeRate)
    {
        if (!_currencies.ContainsKey(currencyCode))
            throw new CurrencyException($"Currency not found.", currencyCode);
        
        var currency = _currencies[currencyCode];
        _currencies[currency.CurrencyCode] = Currency.CreateOrUpdateCurrency(
            currency.Name,
            currency.CurrencyCode,
            currency.CurrencySymbol,
            currency.Country,
            currency.MinorUnit,
            exchangeRate,
            currency.CurrencyType
        );
    }
    
    public Currency GetCurrency(string currencyCode)
    {
        if (!_currencies.ContainsKey(currencyCode))
            throw new CurrencyException($"Currency not found.", currencyCode);
        
        return _currencies[currencyCode];
    }

    public Dictionary<string, Currency> GetCurrencies()
    {
        return _currencies;
    }
}