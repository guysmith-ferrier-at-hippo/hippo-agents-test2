---
id: ASSUME-0003
title: Hello-World Endpoint is Static
component: API/Endpoints
domain: API Design
tags:
- hello-world
- static
- endpoint
status: validated
created: '2026-11-11'
updated: '2026-11-12'
depends_on: []
supported_by: []
---

## Assumption

The "hello-world" endpoint is a diagnostic tool for API clients. It returns a static, unpersonalized JSON greeting.

## Context

The feature request asks for a hello-world endpoint that returns a JSON greeting. The product team confirmed that hello-world endpoints are static.

## Resolution

The assumption is validated. ADR-0002 accepted a static endpoint. The implementation returns a static JSON payload without personalization or localization.
