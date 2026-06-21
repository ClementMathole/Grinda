using System;
using Domain.SeedWork;

namespace Domain.Events;

public record StoreCreatedEvent(Guid StoreId, DateTime OccuredOn) : IDomainEvent
{
    DateTime IDomainEvent.OccurredOn => OccuredOn;
}