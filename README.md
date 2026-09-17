# LENS N' LIGHT Blazor Prototype

## Purpose

This repository is an independent C# and ASP.NET Core Blazor reimplementation of selected customer-facing LENS N' LIGHT screens. The original Next.js application at `/Users/johndavidvelos/Documents/LENS N' LIGHT` was used only as read-only visual and structural reference material and was not modified by this work.

## Requirements

- .NET 10 LTS SDK (`10.0.401` was used for this prototype)
- A modern browser

The workspace includes an isolated SDK under `.dotnet/` for this machine. That folder is ignored by Git and is not part of the application source.

## Running

From this repository root, with a normal system .NET 10 installation:

```bash
dotnet restore
dotnet run --project LensNLight.Blazor/LensNLight.Blazor.csproj
```

Using the isolated SDK installed for this workspace:

```bash
DOTNET_CLI_HOME="$PWD/.dotnet-home" ./.dotnet/dotnet restore
DOTNET_CLI_HOME="$PWD/.dotnet-home" ./.dotnet/dotnet run --project LensNLight.Blazor/LensNLight.Blazor.csproj
```

The development profile serves the application at `http://localhost:5190` by default.

## Routes

- `/` — homepage, featured camera, search, and rental catalog
- `/cameras` — alternate catalog entry route
- `/cameras/{slug}` — camera details and local image gallery
- `/items/{slug}` — compatibility alias for the current Next.js item route shape
- `/track-booking` — mock booking lookup and status tracker
- `/track` — compatibility alias for the current Next.js tracking route

Sample camera route: `/cameras/panasonic-lumix-tz99`

## Current Scope

- Homepage
- Camera/item details
- Track Booking
- Responsive layouts for mobile, tablet, laptop, and desktop
- Friendly camera-not-found, booking-not-found, missing-image, and empty-search states

## Mock Functionality

Camera catalog details and booking tracking are supplied by local singleton services in `Services/`. No Supabase, Google Drive, payment provider, authentication, email, or notification service is called.

Use `LNL-DEMO-001` on the Track Booking page to display the mock booking result. The Book Now control intentionally shows a prototype notice and does not create a booking.

## Assets

Public presentation assets were copied—not moved—from the original application's public/static output into:

- `LensNLight.Blazor/wwwroot/images/branding/`
- `LensNLight.Blazor/wwwroot/images/backgrounds/`
- `LensNLight.Blazor/wwwroot/images/cameras/`

The copied set contains the public customer logo, homepage studio background, and public-facing camera renders already cached by the original website. No `.env` files, OAuth credentials, Drive tokens, Supabase keys, customer uploads, IDs, payment proofs, or private records were copied.

## Architecture

- `Components/Navigation/` — site header and footer
- `Components/Cameras/` — camera cards, featured camera, status badge, and image gallery
- `Components/Booking/` — booking status tracker
- `Components/Pages/` — routable Blazor screens
- `Models/` — camera, pricing, image, and tracking models
- `Services/` — local catalog and booking tracking service abstractions
- `wwwroot/` — CSS and public visual assets

## Future Migration

Logical next phases are the booking date/time flow, customer validation, payment submission, authenticated administration, database-backed catalog and availability, private upload handling, and server-side notification delivery. Those integrations should be migrated separately, with their current security and business contracts preserved.
