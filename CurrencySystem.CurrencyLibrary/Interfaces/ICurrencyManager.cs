using CurrencySystem.CurrencyLibrary.Models;

namespace CurrencySystem.CurrencyLibrary.Interfaces;

public interface ICurrencyManager
{
    void AddCurrency(Currency currency);
    void RemoveCurrency(string currencyCode);
    void UpdateCurrency(string currencyCode, decimal exchangeRate);
    Currency GetCurrency(string currencyCode);
    Dictionary<string, Currency> GetCurrencies();
}