using DinnerApp.Domain.Common.Models;

namespace DinnerApp.Domain.MenuAggregate.ValueObjects;

public sealed class MenuId(Guid value) : ValueObject
{
    private Guid Value { get; } = value;

    public static MenuId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return this.Value;
    }
}