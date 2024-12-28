using DinnerApp.Domain.Common.Models;
using DinnerApp.Domain.DinnerAggregate.ValueObjects;
using DinnerApp.Domain.HostAggregate.ValueObjects;
using DinnerApp.Domain.MenuAggregate.Entities;
using DinnerApp.Domain.MenuAggregate.ValueObjects;
using DinnerApp.Domain.MenuReviewAggregate.ValueObjects;

namespace DinnerApp.Domain.MenuAggregate;

public class Menu(
    MenuId id,
    string name,
    string description,
    float averageRating,
    HostId hostId,
    List<MenuSection>? sections = null) : AggregateRoot<MenuId>(id)
{
    private readonly List<MenuSection> _sections = sections ?? [];
    private readonly List<DinnerId> _dinnerIds = [];
    private readonly List<MenuReviewId> _menuReviewIds = [];

    public string Name { get; } = name;

    public string Description { get; } = description;

    public float AverageRating { get; } = averageRating;

    public IReadOnlyList<MenuSection> Sections => this._sections.AsReadOnly();

    public HostId HostId { get; } = hostId;

    public IReadOnlyList<DinnerId> DinnerIds => this._dinnerIds.AsReadOnly();

    public IReadOnlyList<MenuReviewId> MenuReviewIds => this._menuReviewIds.AsReadOnly();

    public DateTime CreatedDateTime { get; private set; }

    public DateTime UpdatedDateTime { get; private set; }

    public static Menu Create(
        string name,
        string description,
        float averageRating,
        HostId hostId,
        List<MenuSection>? sections = null)
    {
        return new(
            MenuId.CreateUnique(),
            name,
            description,
            averageRating,
            hostId,
            sections ?? new());
    }

    public void AddDinnerId(DinnerId dinnerId)
    {
        this._dinnerIds.Add(dinnerId);
    }
}