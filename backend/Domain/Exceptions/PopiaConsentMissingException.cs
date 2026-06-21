namespace Domain.Exceptions;

public class PopiaConsentMissingException : DomainException
{
    public PopiaConsentMissingException() : base("User account cannot activate without explicit POPIA consent.") {}
}