namespace Domain.ValueObjects;

public record StoreSlug
{
    public string Value { get; }

    public StoreSlug(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Store slug is required", nameof(value));
        Value = value.ToLowerInvariant();
    }
}