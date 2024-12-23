using static System.Console;
using System.Text;
using CurrencySystem.ConsoleApp.Enums;
using CurrencySystem.ConsoleApp.Models;
using CurrencySystem.ConsoleApp.Utilities;
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
            var bitcoin = Currency.CreateOrUpdateCurrency("Bitcoin", "BTN", "BTN", "International", 2, 28000m, CurrencyType.CRYPTO);
            var dogeCoin = Currency.CreateOrUpdateCurrency("Dogecoin", "DOGE", "DOGE", "International", 2, 0.065m, CurrencyType.CRYPTO);
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

            var johnBalances = new Dictionary<string, decimal>()
            {
                { "USD", 200m },
                { "EUR", 200m },
            };
            
            var john = User.CreateUser(Guid.NewGuid(), "John", "Doe", "john@doe.com", DateTime.Now, 
                Address.CreateAddress(Guid.NewGuid(), "United States", "Los Angeles", "Street", "12-432"),
                Wallet.CreateWallet(Guid.NewGuid(), johnBalances, "USD", DateTime.Now, DateTime.Now));
            
            var walletManager = new WalletManager();
            var transaction = Transaction.CreateTransaction("USD", 25m, TransactionType.DEPOSIT);
            var transaction2 = Transaction.CreateTransaction("USD", 50m, TransactionType.EXCHANGE);
            walletManager.AddTransaction(john.Wallet, currencyManager.GetCurrency("USD"), currencyManager.GetCurrency("EUR"), transaction);
            walletManager.GetWalletStatus(john.Wallet);
            WriteLine();
            walletManager.AddTransaction(john.Wallet, currencyManager.GetCurrency("USD"), currencyManager.GetCurrency("PLN"), transaction2);
            walletManager.GetWalletStatus(john.Wallet);
        }
    }
}