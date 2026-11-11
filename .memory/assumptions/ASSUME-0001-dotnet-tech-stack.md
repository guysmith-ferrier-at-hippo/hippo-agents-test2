---
id: ASSUME-0001
title: Use .NET 10 and ASP.NET Core Minimal APIs
component: greeting-api
domain: architecture
tags:
- dotnet
- aspnetcore
- minimal-api
status: validated
created: '2026-11-11'
updated: '2026-11-12'
depends_on: []
supported_by: []
---

## Assumption

The Customer Greetings Service API uses the .NET 10 runtime and ASP.NET Core Minimal APIs.

## Context

The repository contains a .NET configuration. The host environment provides the .NET 10 SDK. ASP.NET Core Minimal APIs provide low latency and high throughput.

## Resolution

The assumption is validated. The team implemented the solution on .NET 10 using ASP.NET Core Minimal APIs. All unit and integration tests compile and pass.
