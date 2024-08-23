using MHTester.Domain.Common.Models;
using MHTester.Domain.MenuAggregate.ValueObjects;

namespace MHTester.Domain.MenuAggregate.Entities;

public class SectionItem(SectionItemId id, string name, string description) : Entity<SectionItemId>(id)
{
    public string Name { get; } = name;

    public string Description { get; } = description;

    public SectionItem Create(string name, string description)
    {
        return new(SectionItemId.CreateUnique(), name, description);
    }
}