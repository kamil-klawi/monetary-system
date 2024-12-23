using CurrencySystem.ConsoleApp.Helpers;

namespace CurrencySystem.ConsoleApp.Models;

public class Address
{
    public Guid Id { get; }
    public string Country { get; }
    public string City { get; }
    public string Street { get; }
    public string ZipCode { get; }

    private Address(Guid id, string country, string city, string street, string zipCode)
    {
        Id = id;
        Country = country;
        City = city;
        Street = street;
        ZipCode = zipCode;
    }

    public static Address CreateAddress(Guid id, string country, string city, string street, string zipCode)
    {
        if (AddressValidation.IsValidGuid(id))
            throw new ArgumentException($"Invalid id: {id}, expected pattern: xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx");
        
        if (AddressValidation.IsValidCountry(country))
            throw new ArgumentException($"Country {country} is not valid");
        
        if (AddressValidation.IsValidCity(city))
            throw new ArgumentException($"City {city} is not valid");
        
        if (AddressValidation.IsValidStreet(street))
            throw new ArgumentException($"Street {street} is not valid");
        
        if (AddressValidation.IsValidZipCode(zipCode))
            throw new ArgumentException($"Zip code {zipCode} is not valid");
        
        return new Address(id, country, city, street, zipCode);
    }

    public override string ToString()
    {
        return $"{Country}, {City}, {Street}, {ZipCode}";
    }
}