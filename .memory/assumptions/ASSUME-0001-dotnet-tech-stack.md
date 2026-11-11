---
id: ASSUME-0001
title: Use .NET 10 and ASP.NET Core Minimal APIs
component: greeting-api
domain: architecture
tags:
- dotnet
- aspnetcore
- minimal-api
status: unresolved
created: '2026-11-11'
updated: '2026-11-11'
---

## Description
The Customer Greetings Service API will use .NET 10 and ASP.NET Core Minimal APIs with built-in OpenAPI documentation.

## Rationale
The repository contains a .NET gitignore file and the host environment has .NET SDK 10.0 installed. ASP.NET Core Minimal APIs provide high performance and low memory overhead for microservice APIs.

## Impact if Wrong
If a different runtime or framework is required (such as Node.js or Python), all API models and endpoints must be rewritten.

## Validation Method
Confirm runtime requirements with technical stakeholders during early sprint architecture review.