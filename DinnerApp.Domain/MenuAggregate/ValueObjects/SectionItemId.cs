using DinnerApp.Domain.Common.Models;

namespace DinnerApp.Domain.MenuAggregate.ValueObjects;

public sealed class SectionItemId(Guid value) : ValueObject
{
    private Guid Value { get; } = value;
    
    public static SectionItemId CreateUnique()
    {
        return new(Guid.NewGuid());
    }
    
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}