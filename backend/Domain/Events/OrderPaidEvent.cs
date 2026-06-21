using System;
using Domain.SeedWork;

namespace Domain.Events;

public record OrderPaidEvent(Guid OrderId, DateTime OccuredOn) : IDomainEvent
{
    DateTime IDomainEvent.OccurredOn => OccuredOn;
}