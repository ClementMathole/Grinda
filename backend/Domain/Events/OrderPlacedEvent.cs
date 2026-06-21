using System;
using Domain.SeedWork;

namespace Domain.Events;

public record OrderPlacedEvent(Guid OrderId, DateTime OccuredOn) : IDomainEvent
{
    DateTime IDomainEvent.OccurredOn => OccuredOn;
}