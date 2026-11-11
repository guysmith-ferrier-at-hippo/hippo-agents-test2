---
id: KB-0006
title: Static Diagnostic Endpoint Implementation Pattern
component: API/Endpoints
domain: API Design
tags:
- api-design
- diagnostic
- endpoints
- latency
status: validated
created: '2026-11-12'
updated: '2026-11-12'
depends_on: []
supported_by: []
---

## What Happened

Client developers needed a diagnostic endpoint to verify network connectivity and JSON payload formatting. The service required fast responses without dependencies on database queries or localization logic.

## Key points

Implement diagnostic endpoints as static routes that return pre-allocated response instances. Map both root paths and versioned paths for consumer convenience. Ignore unexpected query parameters without errors. Return HTTP status 405 Method Not Allowed for unsupported HTTP verbs.

## Why It Matters

Diagnostic endpoints with external dependencies fail when downstream systems are unavailable. Pre-allocated static responses achieve P95 latency below 10 milliseconds and eliminate garbage collection overhead.

## Applies When

Apply this pattern to connectivity, ping, or health check endpoints in ASP.NET Core Minimal APIs.
