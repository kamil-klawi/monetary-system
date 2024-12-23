using System.Globalization;
using CurrencySystem.ConsoleApp.Helpers;

namespace CurrencySystem.ConsoleApp.Models;

public class User
{
    public Guid Id { get; }
    public string FirstName { get; }
    public string LastName { get; }
    public string Email { get; }
    public Address Address { get; }
    public DateTime DateBirth { get; }
    public Wallet Wallet { get; }

    private User(Guid id, string firstName, string lastName, string email, DateTime dateBirth, Address address, Wallet wallet)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Address = address;
        DateBirth = dateBirth;
        Wallet = wallet;
    }

    public static User CreateUser(Guid id, string firstName, string lastName, string email, DateTime dateBirth,
        Address address, Wallet wallet)
    {
        if (UserValidation.IsValidGuid(id))
            throw new ArgumentException("Invalid user id");
        
        if (UserValidation.IsValidFirstName(firstName))
            throw new ArgumentException("Invalid first name");
        
        if (UserValidation.IsValidLastName(lastName))
            throw new ArgumentException("Invalid last name");
        
        if (!UserValidation.IsValidEmail(email))
            throw new ArgumentException("Invalid email");
        
        if (UserValidation.IsValidDateBirth(dateBirth))
            throw new ArgumentException("Invalid date birth");
        
        return new User(id, firstName, lastName, email, dateBirth, address, wallet);
    }

    public override string ToString()
    {
        return $"{FirstName} {LastName} | {Email} | {Address} | {DateBirth.ToString(CultureInfo.CurrentCulture)}";
    }
}