using ErrorOr;

using MHTester.Domain.Common.Models;

namespace MHTester.Domain.DinnerAggregate.ValueObjects;

public class Price : ValueObject
{
    public Price(decimal amount, string currency)
    {
        Amount = amount;
        Currency = currency;
    }

    public decimal Amount { get; }
    
    public string Currency { get; }

    public static Price Created(decimal amount, string currency)
    {
        return new(amount, currency);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Amount;

        yield return Currency;
    }
}