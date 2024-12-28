using DinnerApp.Domain.Common.Models;

namespace DinnerApp.Domain.UserAggregate.ValueObjects;

public sealed class UserId(Guid value) : ValueObject
{
    private Guid Value { get; } = value;

    public static UserId CreateUnique()
    {
        return new(Guid.NewGuid());
    }
    
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return this.Value;
    }
}