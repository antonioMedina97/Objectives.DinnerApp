using MHTester.Domain.Common.Models;

namespace MHTester.Domain.MenuAggregate.ValueObjects;

public sealed class MenuId(Guid value) : ValueObject
{
    public Guid value { get; } = value;

    public static MenuId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        throw new NotImplementedException();
    }
}