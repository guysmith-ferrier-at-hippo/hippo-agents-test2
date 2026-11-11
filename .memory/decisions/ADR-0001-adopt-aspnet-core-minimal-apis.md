---
id: ADR-0001
title: Adopt ASP.NET Core Minimal APIs for Customer Greetings Service API
component: api-gateway
domain: architecture
tags:
- dotnet
- aspnetcore
- minimal-apis
- openapi
status: accepted
created: '2026-11-11'
updated: '2026-11-11'
---

# ADR-0001: Adopt ASP.NET Core Minimal APIs for Customer Greetings Service API

## Context
The Customer Greetings Service API is a microservice designed to produce fast, personalized, and localized greeting responses for client applications. We must choose an API architecture framework within the .NET ecosystem that balances developer productivity, low latency, and modern OpenAPI documentation support.

## Decision
We will build the service using ASP.NET Core Minimal APIs on .NET 10.
- Endpoints are mapped directly using route handlers.
- Built-in OpenAPI document generators (`Microsoft.AspNetCore.OpenApi`) provide live API schemas.
- Interactive Swagger UI is hosted directly from the application.

## Consequences
### Positive
- High throughput and minimal allocation overhead compared to controller-based MVC pipelines.
- Direct endpoint mapping reduces boilerplate code.
- Native integration with modern .NET dependency injection and OpenAPI tooling.

### Negative
- Very large APIs can become unstructured if endpoints are not properly modularized via extension methods.

## Options Considered
1. **ASP.NET Core Minimal APIs:** Selected for speed, simplicity, and low memory footprint.
2. **ASP.NET Core MVC Controllers:** Rejected due to unnecessary MVC pipeline overhead for a simple greeting service.
3. **FastEndpoints:** Considered, but built-in Minimal APIs are fully supported out-of-the-box in .NET 10 without external dependencies.