using System;
using Domain.SeedWork;

namespace Domain.Events;

public record UserRegisteredEvent(Guid UserId, DateTime OccuredOn) : IDomainEvent
{
    DateTime IDomainEvent.OccurredOn => OccuredOn;
}