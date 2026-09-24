using LensNLight.Blazor.Features.Tracking.Models;

namespace LensNLight.Blazor.Features.Tracking.Services;

public interface IBookingTrackingService
{
    BookingTrackingResult? Find(string bookingNumber);
}
