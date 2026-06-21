using Domain.SeedWork;

namespace Domain.Aggregates;

public class EmailVerificationToken : Entity
{
    public Guid UserId { get; private set; }
    public string Token { get; private set; }
    public DateTime ExpiresAt { get; private set; }
    public bool IsUsed { get; private set; }

    public EmailVerificationToken(Guid id, Guid userId, string token, DateTime expiresAt)
    {
        Id = id;
        UserId = userId;
        Token = token;
        ExpiresAt = expiresAt;
        IsUsed = false;
    }
    
    public void MarkAsUsed()
        => IsUsed = true;
}