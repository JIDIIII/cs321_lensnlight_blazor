namespace LensNLight.Blazor.Models;

public enum CameraAvailability
{
    Available,
    Maintenance,
    Unavailable
}

public sealed class CameraItem
{
    public required string Id { get; init; }
    public required string Slug { get; init; }
    public required string Name { get; init; }
    public required string Brand { get; init; }
    public required string Model { get; init; }
    public required string Category { get; init; }
    public required string Description { get; init; }
    public CameraAvailability Status { get; init; }
    public decimal StartingPrice { get; init; }
    public decimal SecurityDeposit { get; init; }
    public bool IsFeatured { get; init; }
    public IReadOnlyList<CameraImage> Images { get; init; } = [];
    public IReadOnlyList<PricingTier> PricingTiers { get; init; } = [];
    public IReadOnlyDictionary<string, string> Specifications { get; init; }
        = new Dictionary<string, string>();
    public IReadOnlyList<string> Features { get; init; } = [];
    public IReadOnlyList<string> Accessories { get; init; } = [];
}
