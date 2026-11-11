# Customer Greetings Service API — Design Guidelines

## Design Principles & Vibe

The Customer Greetings Service API provides clean, accessible developer documentation and high-quality greeting content. The visual theme for the interactive OpenAPI documentation is professional, modern, and uncluttered. Developer documentation prioritizes high readability and clear contrast.

Key principles:
- **Clarity:** Display endpoints, parameters, and example JSON payloads with simple formatting.
- **Consistency:** Maintain uniform JSON response naming conventions (camelCase) and HTTP status codes.
- **Accessibility:** Ensure all documentation interfaces meet accessibility standards for keyboard navigation and screen readers.

## Design System & Tooling

- **Storybook:** No (backend API service).
- **External Design System:** OpenAPI / Swagger UI standard theme with custom high-contrast CSS overrides.
- **API Specification Standard:** OpenAPI 3.0 / JSON Schema.

## UI Constraints

### Color Palette

| Name | Hex/CSS Variable | Usage |
| :--- | :--- | :--- |
| Brand Primary | `#0F172A` | Primary headers, navigation background, and key brand elements |
| Accent Action | `#2563EB` | Interactive links, endpoint method badges, and call-to-action buttons |
| Background Canvas | `#FFFFFF` | Primary documentation content canvas |
| Background Alt | `#F8FAFC` | Code blocks, schema parameter tables, and card backgrounds |
| Text Primary | `#0F172A` | Primary body text and headings |
| Text Muted | `#475569` | Secondary descriptions, timestamps, and schema hints |
| Success State | `#16A34A` | HTTP 200/201 response indicators and health status badges |
| Error State | `#DC2626` | HTTP 4xx/5xx error badges and validation failure alerts |

### Typography

- **Primary Font:** Inter, system-ui, -apple-system, Segoe UI, Roboto, sans-serif.
- **Monospace Font (Code & JSON):** JetBrains Mono, Fira Code, Consolas, monospace.
- **Headings:**
  - H1: Semi-bold (600), 32px, line-height 1.25.
  - H2: Semi-bold (600), 24px, line-height 1.3.
  - H3: Medium (500), 18px, line-height 1.4.
- **Body Text:** Regular (400), 15px, line-height 1.5.

### Spacing & Layout

- **Grid/Layout System:** Flexbox and CSS Grid layout for OpenAPI documentation layouts.
- **Spacing Scale:** Standard 4px baseline scale (4px, 8px, 12px, 16px, 24px, 32px, 48px).
- **Breakpoints:**
  - Mobile: < 640px
  - Tablet: 640px to 1023px
  - Desktop: >= 1024px

## Content Strategy

- **Tone of Voice:** Direct, welcoming, professional, and clear. Avoid robotic phrasing and unnecessary jargon.
- **Terminology:**
  - Use "Customer" instead of "User" or "Client" when referring to the person receiving greetings.
  - Use "Consumer" or "Client Application" when referring to systems calling the API.
  - Use "Locale" for language-culture identifier (e.g., `en-GB`).
- **Grammar & Formatting:**
  - Use sentence case for all titles, headings, and descriptions.
  - Use standard ISO 8601 formatting for date and time fields (`YYYY-MM-DDTHH:mm:ssZ`).
  - Use camelCase for all JSON property names.

## Accessibility (a11y)

- **Standard:** WCAG 2.1 Level AA compliance across all OpenAPI web pages.
- **Contrast Ratios:** Minimum 4.5:1 for normal text and 3:1 for large text or graphical controls.
- **Focus States:** High-visibility 2px solid blue (`#2563EB`) focus ring with 2px offset for all interactive inputs and buttons.
- **Keyboard Operability:** Complete keyboard operability for all interactive Swagger UI endpoints, copy buttons, and dropdowns.

## Component Behaviors

- **Endpoint Accordions:** Expand and collapse smoothly without layout jump.
- **Try It Out Execution:** Show a visible loading spinner while the interactive test request is in flight.
- **Copy Buttons:** Provide clear visual feedback ("Copied!") when a user copies an example payload or curl command.
- **Error Badges:** Render error codes with distinct icons and high-contrast red styling for immediate recognition.
