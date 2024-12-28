using DinnerApp.Domain.Common.Models;

namespace DinnerApp.Domain.MenuReviewAggregate.ValueObjects;

public sealed class MenuReviewId(Guid value) : ValueObject
{
    private Guid Value { get; } = value;

    public static MenuReviewId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}