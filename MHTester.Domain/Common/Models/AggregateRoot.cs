namespace MHTester.Domain.Common.Models;

public class AggregateRoot<TId>(TId id) : Entity<TId>(id)
    where TId : notnull;