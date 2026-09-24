namespace LensNLight.Blazor.Features.Tracking.Models;

public enum BookingStepState
{
    Complete,
    Active,
    Upcoming
}

public sealed record BookingTrackingStep(string Label, BookingStepState State);

public sealed class BookingTrackingResult
{
    public required string BookingNumber { get; init; }
    public required string RenterName { get; init; }
    public required string ItemName { get; init; }
    public required DateTime StartAt { get; init; }
    public required DateTime EndAt { get; init; }
    public required string Duration { get; init; }
    public required string DeliveryMode { get; init; }
    public required string Status { get; init; }
    public IReadOnlyList<BookingTrackingStep> Steps { get; init; } = [];
}
