using Domain.SeedWork;
using Domain.ValueObjects;
using Domain.Enums;
using Domain.Exceptions;
using Domain.Events;

namespace Domain.Aggregates;

public class User : AggregateRoot
{
    public EmailAddress Email { get; private set; }
    public string PasswordHash { get; private set; }
    public bool IsEmailVerified { get; private set; }
    public DateTime? PopiaConsentTimestamp { get; private set; }
    public bool IsDeleted { get; private set; }

    private readonly List<Role> _roles = new();
    public IReadOnlyCollection<Role> Roles => _roles.AsReadOnly();

    private readonly List<Permission> _permissions = new();
    public IReadOnlyCollection<Permission> Permissions => _permissions.AsReadOnly();

    private readonly List<RefreshToken> _refreshTokens = new();
    public IReadOnlyCollection<RefreshToken> RefreshTokens => _refreshTokens.AsReadOnly();

    private readonly List<EmailVerificationToken> _emailVerificationTokens = new();
    public IReadOnlyCollection<EmailVerificationToken> EmailVerificationTokens => _emailVerificationTokens.AsReadOnly();

    private readonly List<PasswordResetToken> _passwordResetToken = new();
    public IReadOnlyCollection<PasswordResetToken> PasswordResetTokens => _passwordResetToken.AsReadOnly();

    public User(Guid id, EmailAddress email, string passwordHash)
    {
        Id = id;
        Email = email;
        PasswordHash = passwordHash;
        IsEmailVerified = false;
        IsDeleted = false;
        AddDomainEvent(new UserRegisteredEvent(Id, DateTime.UtcNow));
    }

    public void ProvidePopiaConsent()
    {
        PopiaConsentTimestamp = DateTime.UtcNow;
    }

    public void VerifyEmail(string token)
    {
        if (!PopiaConsentTimestamp.HasValue)
            throw new PopiaConsentMissingException();
        var validationToken = _emailVerificationTokens
                                    .FirstOrDefault(t => t.Token == token && !t.IsUsed && t.ExpiresAt > DateTime.UtcNow);
        if (validationToken == null)
            throw new DomainException("Invalid or expired verification token.");
        
        validationToken.MarkAsUsed();
        IsEmailVerified = true;
        AddDomainEvent(new EmailVerifiedEvent(Id, DateTime.UtcNow));
    }

    public void AddRefreshToken(RefreshToken token)
        => _refreshTokens.Add(token);
    public void AddEmailVerificationToken(EmailVerificationToken token)
        => _emailVerificationTokens.Add(token);
    public void AddPasswordResetToken(PasswordResetToken token)
        => _passwordResetToken.Add(token);
    public void SoftDelete()
        => IsDeleted = true;
}