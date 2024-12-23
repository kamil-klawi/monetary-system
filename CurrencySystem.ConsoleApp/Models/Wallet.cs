using CurrencySystem.ConsoleApp.Helpers;
using CurrencySystem.CurrencyLibrary.Models;

namespace CurrencySystem.ConsoleApp.Models;

public class Wallet
{
    public Guid Id { get; }
    public Dictionary<string, decimal> Balances { get; set; }
    public string DefaultCurrency { get; }
    public DateTime CreatedAt { get; }
    public DateTime LastModified { get; set; }
    public List<Transaction> Transactions { get; }

    private Wallet(Guid id, Dictionary<string, decimal> balances, string defaultCurrency, DateTime createdAt, DateTime lastModified)
    {
        Id = id;
        Balances = balances;
        DefaultCurrency = defaultCurrency;
        CreatedAt = createdAt;
        LastModified = lastModified;
        Transactions = [];
    }

    public static Wallet CreateWallet(Guid id, Dictionary<string, decimal> balances, string defaultCurrency,
        DateTime createdAt, DateTime lastModified)
    {
        if (WalletValidation.IsValidGuid(id))
            throw new ArgumentException("Invalid id");
        
        if (WalletValidation.IsValidDefaultCurrency(defaultCurrency))
            throw new ArgumentException("Invalid default currency");
        
        if (WalletValidation.IsValidDateTime(createdAt))
            throw new ArgumentException("Invalid created at");
        
        if (WalletValidation.IsValidDateTime(lastModified))
            throw new ArgumentException("Invalid last modified");
        
        return new Wallet(id, balances, defaultCurrency, createdAt, lastModified);
    }
}