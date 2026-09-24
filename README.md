# LENS N' LIGHT Blazor Prototype

## Purpose

This repository is an independent C# and ASP.NET Core Blazor frontend reimplementation of the LENS N' LIGHT site. The original Next.js application at `/Users/johndavidvelos/Documents/LENS N' LIGHT` was used only as read-only visual and structural reference material and was not modified by this work.

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
- `/book/{slug}` — date selection, renter details, and booking review
- `/payment/{bookingNumber}` — local payment instructions and confirmation preview
- `/track-booking` — mock booking lookup and status tracker
- `/track` — compatibility alias for the current Next.js tracking route
- `/privacy` and `/terms` — customer legal pages
- `/admin/login`, `/admin/items`, `/admin/booking`, `/admin/settings` — admin frontend previews
- `/admin` — opens the admin item inventory

Sample camera route: `/cameras/panasonic-lumix-tz99`

## Current Scope

- Customer catalog and camera details
- Booking dates, personal information, review, payment, and tracking flow
- Privacy and terms pages
- Admin login, inventory, bookings, and settings views
- Responsive layouts for mobile, tablet, laptop, and desktop
- Friendly camera-not-found, booking-not-found, missing-image, and empty-search states

## Mock Functionality

The camera catalog and tracking demo use local mock services. Booking, payment, and admin actions are presentation-only: no booking is created, files are uploaded, or inventory/settings are saved. No Supabase, Google Drive, payment provider, authentication, email, or notification service is called.

Use `LNL-DEMO-001` on the Track Booking page to display the mock booking result. The booking-to-payment flow uses this same demo reference so the tracking link works end to end.

## Assets

Public presentation assets were copied—not moved—from the original application's public/static output into:

- `LensNLight.Blazor/wwwroot/images/branding/`
- `LensNLight.Blazor/wwwroot/images/backgrounds/`
- `LensNLight.Blazor/wwwroot/images/cameras/`

The copied set contains the public customer logo, homepage studio background, and public-facing camera renders already cached by the original website. No `.env` files, OAuth credentials, Drive tokens, Supabase keys, customer uploads, IDs, payment proofs, or private records were copied.

## Architecture

- `Features/Catalog/` — catalog pages, camera components, models, and mock catalog service
- `Features/Booking/` — booking flow screens
- `Features/Payments/` — payment preview screens
- `Features/Tracking/` — tracking page, timeline component, model, and mock tracking service
- `Features/Admin/` — admin pages and the shared admin shell
- `Features/Legal/` — privacy and terms pages
- `Components/Navigation/` and `Components/Layout/` — shared site shell and app layout
- `wwwroot/` — CSS and public visual assets

## Future Migration

Backend integrations can be added feature by feature while preserving the current frontend boundaries. Keep real booking availability, server-side pricing, payment verification, authentication, private uploads, and notification delivery out of this presentation-only prototype until separately requested.
