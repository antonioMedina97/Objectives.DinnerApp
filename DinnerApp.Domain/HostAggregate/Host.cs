﻿using DinnerApp.Domain.Common.Models;
using DinnerApp.Domain.DinnerAggregate.ValueObjects;
using DinnerApp.Domain.HostAggregate.ValueObjects;
using DinnerApp.Domain.MenuAggregate.ValueObjects;
using DinnerApp.Domain.UserAggregate.ValueObjects;

namespace DinnerApp.Domain.HostAggregate;

public class Host(
    HostId id,
    string firstName,
    string lastName,
    string profileImage,
    float averageRating,
    UserId userId) : AggregateRoot<HostId>(id)
{
    private readonly List<MenuId> _menuIds = [];
    private readonly List<DinnerId> _dinnerIds = [];

    public string FirstName { get; } = firstName;
    
    public string LastName { get; } = lastName;
    
    public string ProfileImage { get; } = profileImage;
    
    public float AverageRating { get; } = averageRating;

    public UserId UserId { get; } = userId;

    public IReadOnlyList<MenuId> MenuIds => this._menuIds.AsReadOnly();
    
    public IReadOnlyList<DinnerId> DinnerIds => this._dinnerIds.AsReadOnly();
    
    public DateTime CreatedDateTime { get; private set; }

    public DateTime UpdatedDateTime { get; private set; }
    
    public void AddDinnerId(DinnerId dinnerId)
    {
        this._dinnerIds.Add(dinnerId);
    }
    
    public void AddMenuId(MenuId menuId)
    {
        this._menuIds.Add(menuId);
    }

    public static Host Create(
        string firstName,
        string lastName,
        string profileImage,
        float averageRating,
        UserId userId)
    {
        return new(
            HostId.CreateUnique(),
            firstName,
            lastName,
            profileImage,
            averageRating,
            userId);
    }
}