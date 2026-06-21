using System;
using Domain.SeedWork;

namespace Domain.Events;

public record PaymentSucceeded(Guid PaymentId, Guid OrderId, DateTime OccuredOn) : IDomainEvent
{
    DateTime IDomainEvent.OccurredOn => OccuredOn;
}