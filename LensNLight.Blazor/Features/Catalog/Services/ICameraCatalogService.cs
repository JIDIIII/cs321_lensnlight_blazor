using LensNLight.Blazor.Features.Catalog.Models;

namespace LensNLight.Blazor.Features.Catalog.Services;

public interface ICameraCatalogService
{
    IReadOnlyList<CameraItem> GetAll();
    IReadOnlyList<CameraItem> Search(string? query);
    CameraItem? GetBySlug(string slug);
    CameraItem? GetFeatured();
}
