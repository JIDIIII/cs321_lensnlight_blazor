using LensNLight.Blazor.Components;
using LensNLight.Blazor.Features.Catalog.Services;
using LensNLight.Blazor.Features.Booking.Services;
using LensNLight.Blazor.Features.Admin.Services;
using LensNLight.Blazor.Features.Tracking.Services;
using Microsoft.AspNetCore.DataProtection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddDataProtection()
    .PersistKeysToFileSystem(new DirectoryInfo(
        Path.Combine(builder.Environment.ContentRootPath, ".data-protection")));
builder.Services.AddSingleton<ICameraCatalogService, MockCameraCatalogService>();
builder.Services.AddSingleton<IBookingTrackingService, MockBookingTrackingService>();
builder.Services.AddScoped<BookingPreviewState>();
builder.Services.AddScoped<FrontendPreviewSettings>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
