using DinnerApp.Domain.Common.Models;
using DinnerApp.Domain.DinnerAggregate.Entities;
using DinnerApp.Domain.DinnerAggregate.ValueObjects;
using DinnerApp.Domain.HostAggregate.ValueObjects;
using DinnerApp.Domain.MenuAggregate.ValueObjects;

namespace DinnerApp.Domain.DinnerAggregate;

public class Dinner(DinnerId id) : AggregateRoot<DinnerId>(id)
{
    private List<Reservation> _reservations { get; }

    public string Name { get; }
    public string Description { get; }
    public DateTime StartDateTime { get; }
    public DateTime EndDateTime { get; }
    public DateTime StartedDateTime { get; }
    public DateTime EndedDateTime { get; }
    public string Status { get; }
    public bool IsPublic { get; }
    public int MaxGuests { get; }
    public Price Price { get; }
    public HostId HostId { get; }
    public MenuId MenuId { get; }
    public string ImageUrl { get; }
    public Location Location { get; }
    public IReadOnlyList<Reservation> Reservations => _reservations.AsReadOnly();

    public DateTime CreatedDateTime { get; private set; }

    public DateTime UpdatedDateTime { get; private set; }
}