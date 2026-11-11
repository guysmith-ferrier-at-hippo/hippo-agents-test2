# Customer Greetings Service API — Test Strategy

## Overview

This document defines the test strategy for the Customer Greetings Service API. The strategy ensures that greeting generation, localization logic, OpenAPI contracts, and performance meet strict quality standards before release.

## Test Environments & Access

- **Environments:**
  - **Local:** Developer machines executing tests through the .NET CLI (`dotnet test`).
  - **CI:** Automated build runners in continuous integration on every pull request.
  - **Staging:** Cloud staging environment for verification and load testing.
  - **Production:** Live environment for active consumers.
- **Access Needs:** No external credentials required for local or unit testing; staging environment requires standard service team network access.
- **Data Management:** Test fixtures and greeting template seeds run entirely in-memory with isolated test lifecycles to avoid state leakage.
- **CI/CD Integration:** Every pull request runs static analysis, unit tests, integration tests, and security scans. Merging to the main branch triggers deployment to staging.

## Testing Approach

| Level | Scope / Objective | Tools / Frameworks | Success Criteria | Responsibilities |
|---|---|---|---|---|
| **Unit** | Domain entities, time-of-day logic, and greeting formatting in isolation. | xUnit, FluentAssertions | Minimum 85% line coverage; all unit tests pass. | Developers |
| **Component (Web)** | OpenAPI UI and Swagger specification generation. | Microsoft.AspNetCore.OpenApi, Swagger CLI | OpenAPI schema complies with OpenAPI 3.0 specification without errors. | Developers |
| **Contract** | API schema validation and client consumption contracts. | Pact .NET / OpenAPI schema validation | 100% contract compliance with client schemas. | Developers, QA |
| **Integration (Mocked)** | Endpoint route handling and service orchestration using in-memory test host. | Microsoft.AspNetCore.Mvc.Testing (WebApplicationFactory) | All API routes return expected status codes and Problem Details. | Developers, QA |
| **Integration (API / Events)** | Verification of deployed endpoints in staging environment. | curl / Postman CLI / REST Client | Health check returns HTTP 200 Healthy; greeting endpoint succeeds. | Developers, QA |
| **Acceptance (Functional)** | Verification of greeting rules against business acceptance criteria. | xUnit, WebApplicationFactory | All business scenario acceptance tests pass. | QA, Developers |
| **End-to-End (E2E)** | Full customer greeting flow from client request to response. | Playwright / HTTP Client automation | Critical user journeys pass across simulated client request scenarios. | QA, Developers |
| **Performance (API)** | Load, latency, and throughput testing under peak load. | k6 | P95 latency is less than 50ms at 1,000 requests per second. | QA, DevOps, Developers |
| **Performance (Web)** | Load speed and bundle size of the OpenAPI documentation interface. | Lighthouse | Lighthouse Performance score is 90 or greater. | Developers |
| **Security** | Static code analysis, vulnerability scanning, and dependency review. | `dotnet audit`, Snyk, SonarQube | Zero Critical and zero High severity vulnerabilities. | Security, Developers |
| **Accessibility** | WCAG compliance and keyboard navigation of OpenAPI Swagger UI. | axe-core, manual keyboard testing | WCAG 2.1 Level AA compliance verified. | QA, UX, Developers |

## Risk & Mitigation

| Risk | Mitigation |
|---|---|
| Time zone and clock drift during test execution | Use injectable `TimeProvider` or mock clock interfaces instead of `DateTime.UtcNow`. |
| OpenAPI schema drift from actual implementation | Run automated contract verification tests against generated swagger JSON during CI builds. |
| Test data contamination across parallel runs | Use isolated dependency injection scopes and independent test instances for each test method. |
| Performance degradation under unexpected traffic spikes | Run automated k6 load tests as part of release qualification pipelines. |

## Reviewed by

| Name | Role | Approved | Date |
|---|---|---|---|
| Quality Engineer | Test Lead | [x] | 2026-11-11 |
| guysmith-ferrier-at-hippo | Tech Lead | [x] | 2026-11-11 |
| Product Lead | Product Manager | [x] | 2026-11-11 |
