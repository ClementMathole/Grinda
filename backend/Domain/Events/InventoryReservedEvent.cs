using System;
using Domain.SeedWork;

namespace Domain.Events;

public record InventoryReservedEvent(Guid ProductId, int Quantity, DateTime OccuredOn) : IDomainEvent
{
    DateTime IDomainEvent.OccurredOn => OccuredOn;
}