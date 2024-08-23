using MHTester.Domain.Common.Models;

namespace MHTester.Domain.MenuAggregate.ValueObjects;

public sealed class MenuSectionId(Guid value) : ValueObject
{
    private Guid Value { get; } = value;

    public static MenuSectionId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return this.Value;
    }
}