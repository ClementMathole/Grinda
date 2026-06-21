using System;
using Domain.SeedWork;

namespace Domain.Events;

public record EmailVerifiedEvent(Guid UserId, DateTime OccuredOn) : IDomainEvent
{
    DateTime IDomainEvent.OccurredOn => OccuredOn;
}