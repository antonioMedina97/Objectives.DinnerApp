using MHTester.Domain.Common.Models;
using MHTester.Domain.MenuAggregate.ValueObjects;

namespace MHTester.Domain.MenuAggregate.Entities;

public class MenuSection(MenuSectionId id, string name, string description) : Entity<MenuSectionId> (id)
{
    private readonly List<SectionItem> _sectionItems = [];

    public string Name { get; } = name;

    public string Description { get; } = description;


    public static MenuSection Create(string name, string description)
    {
        return new(MenuSectionId.CreateUnique(), name, description);
    }

    public IReadOnlyList<SectionItem> Items => this._sectionItems.AsReadOnly();
}