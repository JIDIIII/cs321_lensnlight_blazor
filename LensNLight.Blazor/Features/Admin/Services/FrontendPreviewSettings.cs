namespace LensNLight.Blazor.Features.Admin.Services;

/// <summary>
/// Per-circuit settings shared by the admin and customer preview screens.
/// Values live in memory only and are never persisted to a backend.
/// </summary>
public sealed class FrontendPreviewSettings
{
    public string FeaturedItemSlug { get; set; } = "panasonic-lumix-tz99";
    public string BookingBuffer { get; set; } = "2 hours";
    public string MinimumRental { get; set; } = "1 day";
    public string BusinessName { get; set; } = "LENS N' LIGHT Camera Rental";
    public string SupportEmail { get; set; } = string.Empty;
    public string RentalTerms { get; set; } = "Please handle all equipment with care. Return equipment and listed accessories at the agreed date and time. A security deposit is collected for each rental and returned after inspection.";
    public List<PreviewPaymentMethod> PaymentMethods { get; } =
    [
        new("gcash", "GCash", "0917 123 4567 · LENS N' LIGHT Camera Rental"),
        new("bank", "Bank transfer", "BDO · 0123 456 789")
    ];

    public int MinimumRentalDays => MinimumRental.StartsWith("2", StringComparison.Ordinal) ? 2 : 1;
}

public sealed record PreviewPaymentMethod(string Id, string Name, string Details);
