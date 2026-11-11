---
id: ADR-0003
title: Static Hello World Endpoint
component: API/Endpoints
domain: API Design
tags:
- hello-world
- static
- endpoint
status: accepted
created: '2026-11-12'
updated: '2026-11-12'
depends_on: []
supported_by: []
---

## Context

The `hello-world` endpoint is required for client developers to verify network connectivity and examine the basic JSON response shape of the Customer Greetings Service API. There was an open question regarding whether this endpoint should support localization or personalization. 

## Options Considered

* **Option 1: Static Endpoint.** Return a hardcoded JSON response without personalization or localization.
* **Option 2: Localized Endpoint.** Accept standard locale and name query parameters, similar to the main domain endpoints.

## Evaluation

### Option 1: Static Endpoint
* **Pros:**
    * Extremely fast and reliable.
    * Serves its primary purpose as a simple diagnostic and connectivity check.
* **Cons:**
    * Does not demonstrate the full capability of the API.

### Option 2: Localized Endpoint
* **Pros:**
    * Demonstrates actual business logic.
* **Cons:**
    * Unnecessary complexity for a basic connectivity check.

## Decision

We will implement the `hello-world` endpoint as a static endpoint that does not require or process localization or personalization parameters. It will return a standard, hardcoded JSON response.

## Consequences

### Positive
* The endpoint will have negligible performance overhead.
* It will be highly reliable for basic connectivity checks.

### Negative
* Developers must test other endpoints to verify localization and personalization features.