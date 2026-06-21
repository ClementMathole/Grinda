using System;
using Domain.SeedWork;

namespace Domain.Events;

public record ProductPublishedEvent(Guid ProductId, DateTime OccuredOn) : IDomainEvent
{
    DateTime IDomainEvent.OccurredOn => OccuredOn;
}