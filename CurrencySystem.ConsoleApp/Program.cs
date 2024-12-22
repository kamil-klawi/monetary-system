using static System.Console;
using System.Text;
using CurrencySystem.CurrencyLibrary.Enums;
using CurrencySystem.CurrencyLibrary.Exceptions;
using CurrencySystem.CurrencyLibrary.Models;
using CurrencySystem.CurrencyLibrary.Utilities;

namespace CurrencySystem.ConsoleApp
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            OutputEncoding = Encoding.UTF8;
            
            var usd = Currency.CreateOrUpdateCurrency("U.S. Dollar", "USD", "$", "United States", 2, 1m, CurrencyType.FIAT);
            var eur = Currency.CreateOrUpdateCurrency("Euro", "EUR", "\u20ac", "Europe Union", 2, 0.92m, CurrencyType.FIAT);
            var pln = Currency.CreateOrUpdateCurrency("Polish Zloty", "PLN", "zł", "Poland", 2, 4m, CurrencyType.FIAT);
            var gold = Currency.CreateOrUpdateCurrency("Gold", "", "Au", "International", 2, 1900m, CurrencyType.COMMODITY);
            var bitcoin = Currency.CreateOrUpdateCurrency("Bitcoin", "BTN", "BTN", "International", 2, 28000m, CurrencyType.COMMODITY);
            var dogeCoin = Currency.CreateOrUpdateCurrency("Dogecoin", "DOGE", "DOGE", "International", 2, 0.065m, CurrencyType.COMMODITY);
            var currencyManager = new CurrencyManager();
            
            try
            {
                currencyManager.AddCurrency(usd);
                currencyManager.AddCurrency(eur);
                currencyManager.AddCurrency(pln);
                currencyManager.AddCurrency(gold);
                currencyManager.AddCurrency(bitcoin);
                currencyManager.AddCurrency(dogeCoin);
            }
            catch (CurrencyException ex)
            {
                WriteLine($"Error: {ex.Message} for currency code: {ex.CurrencyCode}");
            }
            
            var currencyConverter = new CurrencyConverter();
            var fromCurrencyAmountUsd = 100m;
            var convertedAmountToPln = currencyConverter.Convert(usd, pln, fromCurrencyAmountUsd);
            var convertedAmountToEur = currencyConverter.Convert(usd, eur, fromCurrencyAmountUsd);
            
            WriteLine($"{fromCurrencyAmountUsd:N2}{usd.CurrencySymbol} is {convertedAmountToPln:N2}{pln.CurrencySymbol}");
            WriteLine($"{fromCurrencyAmountUsd:N2}{usd.CurrencySymbol} is {convertedAmountToEur:N2}{eur.CurrencySymbol}");

            foreach (var currency in currencyManager.GetCurrencies())
            {
                WriteLine($"{currency.Value.Name} [{currency.Value.CurrencySymbol}]");
            }

            try
            {
                currencyManager.RemoveCurrency("EUR");
            }
            catch (CurrencyException ex)
            {
                WriteLine($"Error: {ex.Message} for currency code: {ex.CurrencyCode}");
            }
        }
    }
}