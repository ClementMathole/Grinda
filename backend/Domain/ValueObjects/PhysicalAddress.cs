namespace Domain.ValueObjects;

public record PhysicalAddress
(
    string Street,
    string City,
    string Province,
    string PostalCode,
    string Country
);