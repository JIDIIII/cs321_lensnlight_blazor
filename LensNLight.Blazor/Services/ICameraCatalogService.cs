using LensNLight.Blazor.Models;

namespace LensNLight.Blazor.Services;

public interface ICameraCatalogService
{
    IReadOnlyList<CameraItem> GetAll();
    IReadOnlyList<CameraItem> Search(string? query);
    CameraItem? GetBySlug(string slug);
    CameraItem? GetFeatured();
}
