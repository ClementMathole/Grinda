using Domain.SeedWork;

namespace Domain.Aggregates;

public class RefreshToken : Entity
{
    public Guid UserId { get; private set; }
    public string Token { get; private set; }
    public DateTime ExpiresAt { get; private set; }
    public bool IsRevoked { get; private set; }

    public RefreshToken(Guid id, Guid userId, string token, DateTime expiresAt)
    {
        Id = id;
        UserId = userId;
        ExpiresAt = expiresAt;
        IsRevoked = false;
    }

    public void Revoke()
        => IsRevoked = true;
}