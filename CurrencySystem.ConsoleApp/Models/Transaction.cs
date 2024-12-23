using CurrencySystem.ConsoleApp.Enums;
using CurrencySystem.ConsoleApp.Helpers;

namespace CurrencySystem.ConsoleApp.Models;

public class Transaction
{
    public string Currency { get; }
    public decimal Amount { get; }
    public TransactionType Type { get; set; }

    private Transaction(string currency, decimal amount, TransactionType type)
    {
        Currency = currency;
        Amount = amount;
        Type = type;
    }

    public static Transaction CreateTransaction(string currency, decimal amount, TransactionType type)
    {
        if (TransactionValidation.IsValidCurrency(currency))
            throw new ArgumentException("Invalid currency");
        
        if (TransactionValidation.IsValidAmount(amount))
            throw new ArgumentException("Invalid amount");
        
        return new Transaction(currency, amount, type);
    }
}