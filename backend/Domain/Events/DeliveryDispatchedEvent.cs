using System;
using Domain.SeedWork;

namespace Domain.Events;

public record DeliveryDispatchedEvent(Guid DeliveryId, string TrackingNumber, DateTime OccuredOn) : IDomainEvent
{
    DateTime IDomainEvent.OccurredOn => OccuredOn;
}