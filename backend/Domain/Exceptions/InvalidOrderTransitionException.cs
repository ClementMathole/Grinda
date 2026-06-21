namespace Domain.Exceptions;

public class InvalidOrderTransitionException : DomainException
{
    public InvalidOrderTransitionException(string message) : base(message) {}
}