using MHTester.Domain.Common.Models;
using MHTester.Domain.DinnerAggregate.ValueObjects;
using MHTester.Domain.HostAggregate.ValueObjects;
using MHTester.Domain.MenuAggregate.Entities;
using MHTester.Domain.MenuAggregate.ValueObjects;
using MHTester.Domain.MenuReviewAggregate.ValueObjects;

namespace MHTester.Domain.MenuAggregate;

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