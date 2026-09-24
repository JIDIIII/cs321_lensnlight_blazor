using LensNLight.Blazor.Features.Tracking.Models;

namespace LensNLight.Blazor.Features.Tracking.Services;

public sealed class MockBookingTrackingService : IBookingTrackingService
{
    private static readonly BookingTrackingResult DemoResult = new()
    {
        BookingNumber = "LNL-DEMO-001",
        RenterName = "J*** D***",
        ItemName = "PANASONIC - LUMIX TZ99",
        StartAt = new DateTime(2026, 9, 20, 8, 0, 0),
        EndAt = new DateTime(2026, 9, 22, 8, 0, 0),
        Duration = "2 days (48h)",
        DeliveryMode = "Pickup",
        Status = "In Use",
        Steps =
        [
            new("Pending", BookingStepState.Complete),
            new("Booked", BookingStepState.Complete),
            new("Picked Up", BookingStepState.Complete),
            new("In Use", BookingStepState.Active),
            new("Returned", BookingStepState.Upcoming)
        ]
    };

    public BookingTrackingResult? Find(string bookingNumber) =>
        bookingNumber.Trim().Equals(DemoResult.BookingNumber, StringComparison.OrdinalIgnoreCase)
            ? DemoResult
            : null;
}
