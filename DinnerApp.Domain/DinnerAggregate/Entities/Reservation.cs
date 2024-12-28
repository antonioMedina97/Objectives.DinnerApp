using DinnerApp.Domain.BillAggregate.ValueObjects;
using DinnerApp.Domain.Common.Models;
using DinnerApp.Domain.DinnerAggregate.Enums;
using DinnerApp.Domain.DinnerAggregate.ValueObjects;
using DinnerApp.Domain.GuestAggregate.ValueObjects;

namespace DinnerApp.Domain.DinnerAggregate.Entities;

public class Reservation(ReservationId id) : Entity<ReservationId>(id)
{
    private Reservation(ReservationId id, int guestCount, ReservationStatus reservationStatus, GuestId guestId, BillId billId, DateTime arrivalDateTime) 
        : this(id)
    {
        GuestCount = guestCount;
        ReservationStatus = reservationStatus;
        GuestId = guestId;
        BillId = billId;
        ArrivalDateTime = arrivalDateTime;
    }

    public int GuestCount { get; }

    public ReservationStatus ReservationStatus { get; }
    
    public GuestId GuestId { get; }
    
    public BillId BillId { get; }
    
    public DateTime ArrivalDateTime { get; }
    
    public DateTime CreatedDateTime { get; }
    
    public DateTime UpdatedDateTime { get; }

    public static Reservation Create(
        int guestCount,
        ReservationStatus reservationStatus,
        GuestId guestId,
        BillId billId,
        DateTime arrivalDateTime)
    {
        return new(ReservationId.CreateUnique(), guestCount, reservationStatus, guestId, billId, arrivalDateTime);
    }
}

