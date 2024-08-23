using MHTester.Domain.Common.Models;

namespace MHTester.Domain.DinnerAggregate.ValueObjects;

public sealed class DinnerId(Guid value) : ValueObject
{
    private Guid Value { get; } = value;

    public static DinnerId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}