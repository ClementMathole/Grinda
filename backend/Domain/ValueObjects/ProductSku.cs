namespace Domain.ValueObjects;

public record ProductSku
{
    public string Value { get; }

    public ProductSku(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Product SKU is required", nameof(value));
        Value = value.ToUpperInvariant();
    }
}