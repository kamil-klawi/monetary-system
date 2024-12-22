using CurrencySystem.CurrencyLibrary.Models;

namespace CurrencySystem.CurrencyLibrary.Interfaces;

public interface ICurrencyConverter
{
    decimal Convert(Currency fromCurrency, Currency toCurrency, decimal fromCurrencyAmount);
}