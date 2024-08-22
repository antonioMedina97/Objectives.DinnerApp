using MHTester.Domain.Common.Models;
using MHTester.Domain.MenuAggregate.ValueObjects;

namespace MHTester.Domain.MenuAggregate;

public class Menu(MenuId id) : AggregateRoot<MenuId>(id)
{
    
}