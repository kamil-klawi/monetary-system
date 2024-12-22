using CurrencySystem.CurrencyLibrary.Interfaces;
using CurrencySystem.CurrencyLibrary.Models;

namespace CurrencySystem.CurrencyLibrary.Utilities;

public class CurrencyConverter : ICurrencyConverter
{
    public decimal Convert(Currency fromCurrency, Currency toCurrency, decimal fromCurrencyAmount)
    {
        if (fromCurrency.CurrencyCode == toCurrency.CurrencyCode)
            return fromCurrencyAmount;

        var exchangeRate = toCurrency.ExchangeRate / fromCurrency.ExchangeRate;
        return fromCurrencyAmount * exchangeRate;
    }
}