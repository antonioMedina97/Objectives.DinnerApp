using DinnerApp.Domain.Common.Models;

namespace DinnerApp.Domain.HostAggregate.ValueObjects;

public sealed class HostId(Guid value) : ValueObject
{
    private Guid Value { get; } = value;

    public static HostId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}