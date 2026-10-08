# Current-state class diagram

This diagram reflects the classes and dependencies currently implemented in the Blazor prototype. The catalog and tracking data are mock-backed. Booking and admin settings are scoped in-memory preview state; the application has no persisted `Booking`, `Customer`, or `Payment` entity.

```mermaid
classDiagram
    direction LR

    class CameraItem {
        +string Id
        +string Slug
        +string Name
        +string Brand
        +string Model
        +string Category
        +string Description
        +CameraAvailability Status
        +decimal StartingPrice
        +decimal SecurityDeposit
        +bool IsFeatured
        +IReadOnlyList~CameraImage~ Images
        +IReadOnlyList~PricingTier~ PricingTiers
        +IReadOnlyDictionary Specifications
        +IReadOnlyList~string~ Features
        +IReadOnlyList~string~ Accessories
    }

    class CameraImage {
        +string Url
        +string Alt
    }

    class PricingTier {
        +string Label
        +decimal DailyRate
    }

    class CameraAvailability {
        <<enumeration>>
        Available
        Maintenance
        Unavailable
    }

    class ICameraCatalogService {
        <<interface>>
        +GetAll() IReadOnlyList~CameraItem~
        +Search(query) IReadOnlyList~CameraItem~
        +GetBySlug(slug) CameraItem
        +GetFeatured() CameraItem
    }

    class MockCameraCatalogService {
        +GetAll() IReadOnlyList~CameraItem~
        +Search(query) IReadOnlyList~CameraItem~
        +GetBySlug(slug) CameraItem
        +GetFeatured() CameraItem
    }

    class BookingPreviewState {
        +string Slug
        +string BookingNumber
        +DateTime StartDate
        +DateTime EndDate
        +string PickupTime
        +string ReturnTime
        +string RenterName
        +string Email
        +string Phone
        +string FacebookUrl
        +string Address
        +bool TermsAccepted
        +string PaymentMethod
        +string PaymentReference
        +string ProofFileName
        +bool PaymentSubmitted
        +BeginFor(slug)
    }

    class FrontendPreviewSettings {
        +string FeaturedItemSlug
        +string BookingBuffer
        +string MinimumRental
        +string BusinessName
        +string SupportEmail
        +string RentalTerms
        +List~PreviewPaymentMethod~ PaymentMethods
        +int MinimumRentalDays
    }

    class PreviewPaymentMethod {
        +string Id
        +string Name
        +string Details
    }

    class BookingTrackingResult {
        +string BookingNumber
        +string RenterName
        +string ItemName
        +DateTime StartAt
        +DateTime EndAt
        +string Duration
        +string DeliveryMode
        +string Status
        +IReadOnlyList~BookingTrackingStep~ Steps
    }

    class BookingTrackingStep {
        +string Label
        +BookingStepState State
    }

    class BookingStepState {
        <<enumeration>>
        Complete
        Active
        Upcoming
    }

    class IBookingTrackingService {
        <<interface>>
        +Find(bookingNumber) BookingTrackingResult
    }

    class MockBookingTrackingService {
        +Find(bookingNumber) BookingTrackingResult
    }

    class HomePage {
        <<component>>
    }
    class CameraDetailsPage {
        <<component>>
    }
    class BookPage {
        <<component>>
    }
    class PaymentPage {
        <<component>>
    }
    class TrackBookingPage {
        <<component>>
    }
    class BookingTracker {
        <<component>>
    }
    class RatingsPage {
        <<component>>
    }
    class ItemsPage {
        <<component>>
    }
    class SettingsPage {
        <<component>>
    }

    CameraItem "1" *-- "0..*" CameraImage : Images
    CameraItem "1" *-- "0..*" PricingTier : PricingTiers
    CameraItem ..> CameraAvailability : Status
    ICameraCatalogService <|.. MockCameraCatalogService
    ICameraCatalogService ..> CameraItem : returns

    FrontendPreviewSettings "1" *-- "0..*" PreviewPaymentMethod : PaymentMethods
    BookingTrackingResult "1" *-- "0..*" BookingTrackingStep : Steps
    BookingTrackingStep ..> BookingStepState : State
    IBookingTrackingService <|.. MockBookingTrackingService
    IBookingTrackingService ..> BookingTrackingResult : returns

    HomePage ..> ICameraCatalogService : uses
    HomePage ..> FrontendPreviewSettings : uses
    CameraDetailsPage ..> ICameraCatalogService : uses
    BookPage ..> ICameraCatalogService : uses
    BookPage ..> BookingPreviewState : uses
    BookPage ..> FrontendPreviewSettings : uses
    PaymentPage ..> ICameraCatalogService : uses
    PaymentPage ..> BookingPreviewState : uses
    PaymentPage ..> FrontendPreviewSettings : uses
    TrackBookingPage ..> IBookingTrackingService : uses
    TrackBookingPage ..> BookingPreviewState : uses
    TrackBookingPage ..> ICameraCatalogService : uses
    TrackBookingPage ..> BookingTrackingResult : creates preview result
    BookingTracker ..> BookingTrackingResult : displays
    RatingsPage ..> ICameraCatalogService : uses
    ItemsPage ..> ICameraCatalogService : uses
    SettingsPage ..> FrontendPreviewSettings : uses

    note for MockCameraCatalogService "Singleton mock catalog registered in Program.cs"
    note for MockBookingTrackingService "Singleton mock tracking data registered in Program.cs"
    note for BookingPreviewState "Scoped to a Blazor circuit; no backend persistence"
    note for FrontendPreviewSettings "Scoped to a Blazor circuit; no backend persistence"
```

## Existing model commits

The catalog models (`CameraItem`, `CameraImage`, `PricingTier`) and tracking models were already committed in `94b6a18` (`feat(blazor): organize frontend into feature slices`). The preview state used by the booking and admin flows was committed in `92cb82e` (`Checkpoint: connect Blazor preview interactions`). No duplicate model classes were added.
