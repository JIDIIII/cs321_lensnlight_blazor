using LensNLight.Blazor.Features.Catalog.Models;

namespace LensNLight.Blazor.Features.Catalog.Services;

public sealed class MockCameraCatalogService : ICameraCatalogService
{
    private static readonly IReadOnlyList<CameraItem> Items =
    [
        new()
        {
            Id = "cam-panasonic-tz99",
            Slug = "panasonic-lumix-tz99",
            Name = "PANASONIC - LUMIX TZ99",
            Brand = "Panasonic",
            Model = "Lumix TZ99",
            Category = "Digital Cameras",
            Description = "The Panasonic Lumix TZ99 is a pocket-sized travel camera with a powerful 30x optical zoom lens and a 20.3-megapixel sensor.",
            Status = CameraAvailability.Available,
            StartingPrice = 440m,
            SecurityDeposit = 500m,
            IsFeatured = true,
            Images =
            [
                new("/images/cameras/panasonic-lumix-tz99-1.webp", "Panasonic Lumix TZ99 sample gallery collage"),
                new("/images/cameras/panasonic-lumix-tz99-2.webp", "Panasonic Lumix TZ99 event sample portraits"),
                new("/images/cameras/panasonic-lumix-tz99-3.webp", "Panasonic Lumix TZ99 portrait sample"),
                new("/images/cameras/panasonic-lumix-tz99-4.webp", "Panasonic Lumix TZ99 event coverage sample")
            ],
            PricingTiers =
            [
                new("1 day", 440m),
                new("2–4 days", 425m),
                new("5+ days", 350m)
            ],
            Specifications = new Dictionary<string, string>
            {
                ["Sensor"] = "20.3 MP MOS",
                ["Lens"] = "24–720 mm equivalent",
                ["Video"] = "4K at 30 fps",
                ["Connectivity"] = "Wi-Fi, Bluetooth, USB-C"
            },
            Features =
            [
                "30x optical zoom for a versatile 24–720 mm equivalent range",
                "3-inch tilting touchscreen that flips up for selfies",
                "4K video recording at 30 frames per second",
                "Built-in Wi-Fi, Bluetooth, and USB-C charging"
            ],
            Accessories =
            ["Camera", "Camera bag", "Camera case", "Multi-function card reader", "128 GB SD card", "Charger"]
        },
        new()
        {
            Id = "cam-canon-r50",
            Slug = "canon-eos-r50",
            Name = "CANON - EOS R50",
            Brand = "Canon",
            Model = "EOS R50",
            Category = "Mirrorless Cameras",
            Description = "A lightweight mirrorless camera prepared as local prototype catalog data for portraits, events, and everyday content creation.",
            Status = CameraAvailability.Available,
            StartingPrice = 650m,
            SecurityDeposit = 800m,
            Images =
            [
                new("/images/cameras/canon-eos-r50-1.webp", "White Canon mirrorless camera with kit lens"),
                new("/images/cameras/canon-eos-r50-2.webp", "Canon mirrorless camera angled view")
            ],
            PricingTiers =
            [
                new("1 day", 650m),
                new("2–4 days", 600m),
                new("5+ days", 540m)
            ],
            Specifications = new Dictionary<string, string>
            {
                ["Type"] = "Mirrorless camera",
                ["Lens"] = "Interchangeable kit lens",
                ["Use"] = "Portraits and content creation",
                ["Delivery"] = "Pickup or delivery"
            },
            Features =
            [
                "Compact, lightweight body",
                "Interchangeable lens system",
                "Responsive autofocus for people and moving subjects",
                "Flexible stills and video shooting"
            ],
            Accessories = ["Camera", "Kit lens", "Camera strap", "Battery", "Charger", "Camera bag"]
        }
    ];

    public IReadOnlyList<CameraItem> GetAll() => Items;

    public CameraItem? GetBySlug(string slug) => Items.FirstOrDefault(item =>
        item.Slug.Equals(slug, StringComparison.OrdinalIgnoreCase));

    public CameraItem? GetFeatured() => Items.FirstOrDefault(item => item.IsFeatured) ?? Items.FirstOrDefault();

    public IReadOnlyList<CameraItem> Search(string? query)
    {
        if (string.IsNullOrWhiteSpace(query))
        {
            return Items;
        }

        var normalized = query.Trim();
        return Items.Where(item =>
            item.Name.Contains(normalized, StringComparison.OrdinalIgnoreCase) ||
            item.Brand.Contains(normalized, StringComparison.OrdinalIgnoreCase) ||
            item.Model.Contains(normalized, StringComparison.OrdinalIgnoreCase) ||
            item.Category.Contains(normalized, StringComparison.OrdinalIgnoreCase)).ToArray();
    }
}
