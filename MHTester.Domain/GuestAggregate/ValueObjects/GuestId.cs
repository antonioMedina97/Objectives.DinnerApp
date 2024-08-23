using MHTester.Domain.Common.Models;

namespace MHTester.Domain.GuestAggregate.ValueObjects;

public sealed class GuestId(Guid value) : ValueObject
{
    private Guid Value { get; } = value;

    public static GuestId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}