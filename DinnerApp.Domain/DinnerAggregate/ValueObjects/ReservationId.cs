using DinnerApp.Domain.Common.Models;

namespace DinnerApp.Domain.DinnerAggregate.ValueObjects;

public class ReservationId(Guid value) : ValueObject
{
    private Guid Value { get; } = value;

    public static ReservationId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}