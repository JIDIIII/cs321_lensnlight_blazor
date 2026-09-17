using LensNLight.Blazor.Models;

namespace LensNLight.Blazor.Services;

public interface IBookingTrackingService
{
    BookingTrackingResult? Find(string bookingNumber);
}
