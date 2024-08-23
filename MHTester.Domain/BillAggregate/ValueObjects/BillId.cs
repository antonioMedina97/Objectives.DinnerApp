using MHTester.Domain.Common.Models;

namespace MHTester.Domain.BillAggregate.ValueObjects;

public class BillId(Guid value) : ValueObject
{
    private Guid Value { get; } = value;

    public static BillId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}