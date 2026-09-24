namespace LensNLight.Blazor.Features.Booking.Services;

/// <summary>
/// Keeps a booking draft inside the current Blazor circuit so the frontend-only flow
/// can carry its preview values between the booking, payment, and tracking screens.
/// Nothing is persisted or sent to an external service.
/// </summary>
public sealed class BookingPreviewState
{
    public string Slug { get; private set; } = string.Empty;
    public string BookingNumber { get; set; } = "LNL-DEMO-001";
    public DateTime StartDate { get; set; } = DateTime.Today.AddDays(1);
    public DateTime EndDate { get; set; } = DateTime.Today.AddDays(3);
    public string PickupTime { get; set; } = "10:00 AM";
    public string ReturnTime { get; set; } = "10:00 AM";
    public string RenterName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string FacebookUrl { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public bool TermsAccepted { get; set; }
    public string PaymentMethod { get; set; } = "GCash";
    public string PaymentReference { get; set; } = string.Empty;
    public string ProofFileName { get; set; } = string.Empty;
    public bool PaymentSubmitted { get; set; }

    public void BeginFor(string slug)
    {
        if (Slug.Equals(slug, StringComparison.OrdinalIgnoreCase)) return;

        Slug = slug;
        BookingNumber = "LNL-DEMO-001";
        StartDate = DateTime.Today.AddDays(1);
        EndDate = DateTime.Today.AddDays(3);
        PickupTime = ReturnTime = "10:00 AM";
        RenterName = Email = Phone = FacebookUrl = Address = string.Empty;
        TermsAccepted = false;
        PaymentMethod = "GCash";
        PaymentReference = ProofFileName = string.Empty;
        PaymentSubmitted = false;
    }
}
