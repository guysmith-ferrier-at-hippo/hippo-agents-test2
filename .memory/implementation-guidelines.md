# Implementation Guidelines

## 1. Minimal API Endpoint Organization
- Group route handlers by feature into extension methods in `Endpoints/`.
- Name extension methods with the pattern `Map{Feature}Endpoints`.
- Call endpoint mapping methods from `Program.cs`.
- Add OpenAPI metadata to all endpoints with `WithName`, `WithSummary`, and `WithDescription`.
- Explicitly declare response status codes and MIME types with `Produces`.

## 2. Domain and Response Models
- Define response models as immutable records in `Domain/`.
- Use explicit `JsonPropertyName` attributes to guarantee camelCase JSON serialization.
- Provide static instances for static or diagnostic responses to prevent memory allocations.

## 3. Diagnostic and Health Endpoints
- Map diagnostic endpoints to both root and versioned routes (e.g., `/hello-world` and `/api/v1/hello-world`).
- Return static responses without database or external template lookups.
- Ensure that unexpected query parameters do not cause errors or change responses.
- Reject unsupported HTTP methods with HTTP 405 Method Not Allowed.
