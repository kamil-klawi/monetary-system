using CurrencySystem.ConsoleApp.Enums;
using CurrencySystem.ConsoleApp.Models;
using CurrencySystem.CurrencyLibrary.Models;
using CurrencySystem.CurrencyLibrary.Utilities;

namespace CurrencySystem.ConsoleApp.Utilities;

public class WalletManager
{
    public decimal GetBalance(Wallet wallet, Currency currency)
    {
        return wallet.Balances.ContainsKey(currency.CurrencyCode) ? wallet.Balances[currency.CurrencyCode] : 0;
    }
    
    public void GetWalletStatus(Wallet wallet)
    {
        foreach (var currency in wallet.Balances)
            if (wallet.Balances.ContainsKey(currency.Key))
                Console.WriteLine($"{currency.Key}: {wallet.Balances[currency.Key]:N2}");
    }
    
    public void AddTransaction(Wallet wallet, Currency fromCurrency, Currency toCurrency, Transaction transaction)
    {
        wallet.Transactions.Add(transaction);
        
        switch (transaction.Type)
        {
            case TransactionType.DEPOSIT:
                SubstractBalance(wallet, transaction.Currency, transaction.Amount);
                break;
            case TransactionType.WITHDRAWN:
                AddBalance(wallet, transaction.Currency, transaction.Amount);
                break;
            case TransactionType.EXCHANGE:
                ExchangeBalance(wallet, fromCurrency, toCurrency, transaction.Amount);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    
        wallet.LastModified = DateTime.Now;
    }
    
    private static void AddBalance(Wallet wallet, string currency, decimal amount)
    {
        if (wallet.Balances.ContainsKey(currency))
            wallet.Balances[currency] += amount;
        else
            wallet.Balances[currency] = amount;
    }
    
    private static void SubstractBalance(Wallet wallet, string currency, decimal amount)
    {
        if (wallet.Balances.ContainsKey(currency))
            wallet.Balances[currency] -= amount;
    }

    private static void ExchangeBalance(Wallet wallet, Currency fromCurrency, Currency toCurrency, decimal amount)
    {
        var currencyConverter = new CurrencyConverter();
        var convertedAmount = currencyConverter.Convert(fromCurrency, toCurrency, amount);
        AddBalance(wallet, toCurrency.CurrencyCode, convertedAmount);
        SubstractBalance(wallet, fromCurrency.CurrencyCode, amount);
    }
}