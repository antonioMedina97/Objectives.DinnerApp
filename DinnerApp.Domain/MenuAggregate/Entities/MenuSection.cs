using DinnerApp.Domain.Common.Models;
using DinnerApp.Domain.MenuAggregate.ValueObjects;

namespace DinnerApp.Domain.MenuAggregate.Entities;

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